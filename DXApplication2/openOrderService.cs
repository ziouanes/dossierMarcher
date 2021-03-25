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
    public partial class openOrderService : DevExpress.XtraEditors.XtraForm
    {
        int _id_overt;
        public openOrderService(int id_Overture, int délai_dexecution)
        {
            InitializeComponent();
            textEditdelai_initail.Text = délai_dexecution.ToString();
            _id_overt = id_Overture;



        }

        private void openOrderService_Load(object sender, EventArgs e)
        {
            this.dateeditorderservice.DateTime = DateTime.Now;
            this.dateeditorderservice.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateeditorderservice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateeditorderservice.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateeditorderservice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;


            //int dayrestant;
            //DateTime dt = dateeditorderservice.DateTime;
            //int delai = int.Parse(textEditdelai_initail.Text);
            //dayrestant =  delai - (DateTime.Now - dt).Days;

        }

        private void dateeditorderservice_EditValueChanged(object sender, EventArgs e)
        {
            int dayrestant;
            DateTime dt = dateeditorderservice.DateTime;
            int delai = int.Parse(textEditdelai_initail.Text);
            if (dt <= DateTime.Now)
            {

                dayrestant = delai - (DateTime.Now - dt).Days;
                textEditdelai_restant.Text = dayrestant.ToString();
            }

        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button == windowsUIButtonPanelMain.Buttons[0])
            {
                try
                {
                    string sql = "insert into [order_service](date_orderService ,[délai_Initial],[délai_restant],[Etat],[id_Overture] ) VALUES(@date_orderService,@délai_Initial,@délai_restant , @Etat , @id_Overture  )";


                    Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                    Program.sql_cmd.Parameters.AddWithValue("@date_orderService", dateeditorderservice.Text);
                    Program.sql_cmd.Parameters.AddWithValue("@délai_Initial", textEditdelai_initail.Text);
                    Program.sql_cmd.Parameters.AddWithValue("@délai_restant", textEditdelai_restant.Text);
                    Program.sql_cmd.Parameters.AddWithValue("@Etat", "0");
                    Program.sql_cmd.Parameters.AddWithValue("@id_Overture", _id_overt);


                    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                    Program.sql_cmd.ExecuteNonQuery();
                    Program.sql_con.Close();
                    XtraMessageBox.Show("good");

                   

                        using (SqlCommand deleteCommand = new SqlCommand("update SIMPLE_overture set valide_order_service = 1 WHERE id3 = @id", Program.sql_con))
                        {


                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                            deleteCommand.Parameters.AddWithValue("@id", _id_overt);

                            deleteCommand.ExecuteNonQuery();



                        }

                   

                    toastNotificationsManager1.ShowNotification("1b695207-79a7-48d8-9452-76499dcc43ca");
                    this.Close();



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
        }
    }
}