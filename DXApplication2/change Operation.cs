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
    public partial class change_Operation : DevExpress.XtraEditors.XtraForm
    {
        int _order_service;
        int Etat;
        int new_Etat;

        public change_Operation()
        {
            InitializeComponent();

        }

        public change_Operation(int order_service)
        {
            _order_service = order_service;
            InitializeComponent();
            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                {
                    SqlCommand cmd = Program.sql_con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = " select TOP  1 date_deffet , etat_objet   from Etat_order    where order_service = " + _order_service + " order by id_etat desc ";

                    DataTable table = new DataTable();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Etat = int.Parse(row["etat_objet"].ToString());


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
        }

        private void change_Operation_Load(object sender, EventArgs e)
        {
            this.date_change.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.date_change.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_change.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.date_change.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;


            textEdit_etat.SelectedIndex = 0;

            if(Etat == 0) 
            {
                textEdit_etat.Properties.Items.Add(("order de reprise"));
            }
            else if(Etat == 1)
            {
                textEdit_etat.Properties.Items.Add(("order d'arrêt"));
                textEdit_etat.Properties.Items.Add(("réception provisoire"));


            }
            else if(Etat == 2)
            {
                textEdit_etat.Properties.Items.Add(("réception définitive"));
            }


        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = " insert into Etat_order  (date_deffet , etat_objet , order_service) VALUES(@date_deffet,@etat_objet,@order_service )";


                Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                Program.sql_cmd.Parameters.AddWithValue("@date_deffet", date_change.Text);
                Program.sql_cmd.Parameters.AddWithValue("@etat_objet", new_Etat);
                Program.sql_cmd.Parameters.AddWithValue("@order_service", _order_service);


                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                Program.sql_cmd.ExecuteNonQuery();
                Program.sql_con.Close();
                XtraMessageBox.Show("good");
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                //this.Dispose();
            }
        }

        private void textEdit_etat_SelectedValueChanged(object sender, EventArgs e)
        {
            if(textEdit_etat.Text  == "order de reprise")
            {
                new_Etat = 1;

            }
            else if (textEdit_etat.Text == "order d'arrêt")
            {
                new_Etat = 0;
            }else if (textEdit_etat.Text == "réception provisoire")
            {
                new_Etat = 2;
            }else if(textEdit_etat.Text == "réception définitive")
            {
                new_Etat = 3;
            }
        }
    }
}