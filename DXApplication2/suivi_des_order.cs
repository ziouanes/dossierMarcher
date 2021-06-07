using Dapper;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2
{
    public partial class suivi_des_order : DevExpress.XtraEditors.XtraForm
    {
        int order_service;
        DateTime dts;
        int etat;
        DateTime lastdate;

        public suivi_des_order(int id_Overture)
        {

            InitializeComponent();

            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                {
                    SqlCommand cmd = Program.sql_con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = " select  v.[num_Marcher] , e.id_etat , o.date_orderService , o.Etat , o.délai_Initial , o.délai_restant, o.id_order   from SIMPLE_overture v  inner join order_service o  on o.id_Overture = v.id3 inner join Etat_order  e on e.order_service = o.id_order  where o.id_Overture = " + id_Overture + " ";

                    DataTable table = new DataTable();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        id_Overture = int.Parse(row["id_etat"].ToString());

                         dts = Convert.ToDateTime(row["date_orderService"].ToString());


                      

                        textEditdelaiinit.Text = row["délai_Initial"].ToString();

                        textEditdelairestant.Text = row["délai_restant"].ToString();

                        etat = int.Parse(row["Etat"].ToString());

                        order_service = int.Parse(row["id_order"].ToString());

                        textEditnummarche.Text = row["num_Marcher"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                //this.Dispose();
            }

            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                {
                    SqlCommand cmd = Program.sql_con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = " select TOP  1 date_deffet , etat_objet   from Etat_order    where order_service = " + order_service + " order by date_deffet desc ";

                    DataTable table = new DataTable();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        lastdate = Convert.ToDateTime(row["date_deffet"].ToString());


                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                //this.Dispose();
            }

            RunStoredProc();

        }

        private void suivi_des_order_Load(object sender, EventArgs e)
        {
          //  RunStoredProc();

            select_Etat_Data();

            this.dateorderservice.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateorderservice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateorderservice.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateorderservice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            dateorderservice.DateTime = dts;

            if (etat == -1)
            {
                textEditetat.Text = "order de commencement";
            }
            else if (etat == 0)
            {
                textEditetat.Text = "order d'arrêt";
            }else if(etat == 1)
            {

                textEditetat.Text = "order de reprise";


            }
            else if(etat == 2)
            {
                textEditetat.Text = "réception provisoire";

            }else if(etat == 3)
            {
                textEditetat.Text = "réception définitive";
                simpleButton1.Enabled = false;
            }

           // MessageBox.Show(lastdate.ToString());

        }


        //call procedure

        public void RunStoredProc()
        {

           //MessageBox.Show(lastdate.ToString());
            //error here
            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                SqlCommand cmd = new SqlCommand("dbo.suivi_delai", Program.sql_con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Etat", etat);
                cmd.Parameters.AddWithValue("@dateEffet", lastdate);
                cmd.Parameters.AddWithValue("@id_order", order_service);

                //output
                SqlParameter param = new SqlParameter("@etatR", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);







                cmd.ExecuteNonQuery();
               
                textEditdelairestant.Text = param.Value.ToString();


            }
            finally
            {
                if (Program.sql_con != null)
                {
                    Program.sql_con.Close();
                }
                if (Program.db != null)
                {
                    Program.db.Close();
                }
            }
        }

        private void select_Etat_Data()
        {
            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"  select  o.[id_order] , f.[date_deffet] , f.[etat_objet]  , o.[délai_restant] from   order_service o   inner join Etat_order f on   f.order_service = o.id_order where o.[id_order] = "+ order_service + " ";
                classEtatOrderBindingSource.DataSource = Program.sql_con.Query<class_EtatOrder>(query, commandType: CommandType.Text);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //this.Dispose();
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var row2 = gridView1.FocusedRowHandle;
            int cellid_order;
            cellid_order = int.Parse(gridView1.GetRowCellValue(row2, "id_order").ToString());


            change_Operation change_ = new change_Operation(cellid_order);
            change_.ShowDialog();
            select_Etat_Data();
        }
    }
}