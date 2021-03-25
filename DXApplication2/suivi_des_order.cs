﻿using Dapper;
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
                        
                        dateorderservice.Text = row["date_orderService"].ToString();

                        textEditdelaiinit.Text = row["délai_Initial"].ToString();

                        textEditdelairestant.Text = row["délai_restant"].ToString();

                        textEditetat.Text = row["Etat"].ToString();

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

        }

        private void suivi_des_order_Load(object sender, EventArgs e)
        {
            this.dateorderservice.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateorderservice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateorderservice.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateorderservice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            select_Etat_Data();
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
    }
}