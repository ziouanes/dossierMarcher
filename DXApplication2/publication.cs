using DevExpress.XtraBars.Docking2010;
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
    public partial class publication : DevExpress.XtraEditors.XtraForm
    {
        public publication()
        {
            InitializeComponent();
        }

        private void ExecuteQueryobjects()
        {
            try
            {

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                Program.sql_cmd = Program.sql_con.CreateCommand();
                Program.sql_cmd.CommandType = CommandType.Text;
                Program.sql_cmd.CommandText = " select id1 , objet  from [etude]  where validate  = 1 and id1  not in ( select id1  from fk ) ";
                Program.sql_cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                Program.adapter = new SqlDataAdapter(Program.sql_cmd);
                Program.adapter.Fill(dt);
                comboBoxObject.DataSource = dt;
                comboBoxObject.ValueMember = "id1";
                comboBoxObject.DisplayMember = "objet";
                //comboBox1.SelectedIndex = -1;





                Program.sql_con.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                //this.Dispose();
            }


            comboBoxObject.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void layoutControlItem4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textEditJornal_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

            DateTime dt = (DateTime)textEditJornal.EditValue ;
            dt = dt.AddDays(23);
            dateEditop.EditValue = dt ;





            textEditportai.EditValue = textEditJornal.EditValue;


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

        private void publication_Load(object sender, EventArgs e)
        {
            ExecuteQueryobjects();


            this.dateEditop.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditop.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditop.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditop.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;


            this.textEditJornal.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.textEditJornal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEditJornal.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.textEditJornal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;


            this.textEditconvocation.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.textEditconvocation.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEditconvocation.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.textEditconvocation.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;


            this.textEditportai.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.textEditportai.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEditportai.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.textEditportai.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

        }

        private void textEditconvocation_EditValueChanged(object sender, EventArgs e)
        {

           

        }

        private void dateEditop_EditValueChanged(object sender, EventArgs e)
        {
            DateTime dt = (DateTime)dateEditop.EditValue;
            dt = dt.AddDays(-8);
            textEditconvocation.EditValue = dt;
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {

            WindowsUIButton btn = e.Button as WindowsUIButton;

            if (e.Button == windowsUIButtonPanelMain.Buttons[0])
            {

                try
                {


                    if (comboBoxObject.SelectedIndex == -1 || textEditAop.Text == "" || textEditconvocation.Text == "" || textEditJornal.Text == "" || textEditportai.Text == "" || dateEditop.Text == "")
                    {
                        XtraMessageBox.Show("champs obligatoires");

                    }
                    else

                    
                    {

                        DateTime dtconvocation = Convert.ToDateTime(textEditconvocation.EditValue);
                        DateTime dtjORNAL = Convert.ToDateTime(textEditJornal.EditValue);
                        DateTime dtpORTAIL = Convert.ToDateTime(textEditportai.EditValue);
                        DateTime dtop = Convert.ToDateTime(dateEditop.EditValue);


                        string sql = "insert into [publication]([Aop] ,[date_jornal],[date_portail],[date_convocation],[date_op] ) VALUES(@Aop,@date_jornal,@date_portail , @date_convocation , @date_op )";


                        Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                        Program.sql_cmd.Parameters.AddWithValue("@Aop", textEditAop.EditValue);
                        Program.sql_cmd.Parameters.AddWithValue("@date_jornal", dtjORNAL);
                        Program.sql_cmd.Parameters.AddWithValue("@date_portail", dtpORTAIL);
                        Program.sql_cmd.Parameters.AddWithValue("@date_convocation", dtconvocation);
                        Program.sql_cmd.Parameters.AddWithValue("@date_op", dtop);



                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                        Program.sql_cmd.ExecuteNonQuery();
                        Program.sql_con.Close();
                     

                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                        Program.sql_cmd = new SqlCommand("SELECT TOP 1 id2 FROM [publication] ORDER BY id2 DESC ", Program.sql_con);
                        string id = "";
                        Program.db = Program.sql_cmd.ExecuteReader();
                        if (Program.db.HasRows)
                        {


                            Program.db.Read();


                            id = Program.db[0].ToString();

                        }

                        string sql2 = "insert into [fk](id1 ,id2 ) VALUES(@id1,@id2) ";


                        Program.sql_cmd = new SqlCommand(sql2, Program.sql_con);
                        Program.sql_cmd.Parameters.AddWithValue("@id1", comboBoxObject.SelectedValue.ToString());
                        Program.sql_cmd.Parameters.AddWithValue("@id2", id);
                       



                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                        Program.sql_cmd.ExecuteNonQuery();
                        Program.sql_con.Close();
                        XtraMessageBox.Show("good");


                        // toastNotificationsManager1.ShowNotification("1d00270b-1651-4ed4-a139-bd59d5d8cf8e");
                        this.Close();


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

        }
    }
}