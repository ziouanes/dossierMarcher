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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2
{
    public partial class publication : DevExpress.XtraEditors.XtraForm
    {

        int id2 = 0;
        int validate = 0;

        public publication(int id2,  string aoo, DateTime celldateJornal, DateTime celldateconvocation,DateTime cellDatePortail,DateTime celldateOverture ,  int validate)
        {

            InitializeComponent();

           


            string[] digits = Regex.Split(aoo, @"\D");

            //select only first item in string 

            foreach (string value in digits)
            {
                int number;
                if (int.TryParse(value, out number))
                {
                    textEditAop.Text = value.ToString();
                    break;
                }
            }
            string[] digits2 = Regex.Split(aoo, @"\D");


            //select only seconde item in string 
            foreach (string value in digits)
            {
                int number;
                if (int.TryParse(value, out number))
                {
                    textEditaoodate.Text ="/" + value.ToString() + "/BR" ;
                    continue;
                }
            }

            this.id2 = id2;
            //textEditAop.EditValue = aoo; 
            textEditJornal.EditValue = celldateJornal ;
            textEditconvocation.EditValue = celldateconvocation;
            textEditportai.EditValue = cellDatePortail;
            dateEditop.EditValue = celldateOverture;
            this.validate = validate;


            try
            {


                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                {
                    SqlCommand cmd = Program.sql_con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "select e.objet from etude e inner join fk f on e.id1 = f.id1 inner join publication p on f.id2 = p.id2 where p.id2 = "+ id2+" ";

                    DataTable table = new DataTable();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                       
                        comboBoxObject.Text = row["objet"].ToString();
                        

                    }
                   // MessageBox.Show(id2.ToString());

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

        string aop = "";
        public publication()
        {
            InitializeComponent();
            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                {
                    SqlCommand cmd = Program.sql_con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "select top 1 Aop  from publication order by Aop desc";

                    DataTable table = new DataTable();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {

                        aop = row["Aop"].ToString();


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

        private void ExecuteQueryobjects()
        {
            if (id2 == 0)
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
        }

            

        private void layoutControlItem4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textEditJornal_EditValueChanged(object sender, EventArgs e)
        {
            if(id2 == 0)
            {
            try
            {

            //DateTime dt = (DateTime)textEditJornal.EditValue ;
            //dt = dt.AddDays(23);
            //dateEditop.EditValue = dt ;





           // textEditportai.EditValue = textEditJornal.EditValue;


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


            if (id2 == 0)
            {

                //date today
                int i = 1;
            double year = DateTime.Now.Year;
            string this_Year = "/" + year.ToString() + "/BR" ;
            textEditaoodate.Text = this_Year;
            
                //select only first item in string 
            string[] digits = Regex.Split(aop, @"\D");

            foreach (string value in digits)
            {
                int number;
                if (int.TryParse(value, out number))
                {
                        i += int.Parse(value.ToString());
                    break;
                }
            }
                    textEditAop.Text = i.ToString();

            }

            ////
            if (validate == 1)
            {
                comboBoxObject.Enabled = false;
            }
        }

        private void textEditconvocation_EditValueChanged(object sender, EventArgs e)
        {

           

        }

        private void dateEditop_EditValueChanged(object sender, EventArgs e)
        {
            if(id2 == 0)
            {
            DateTime dt = (DateTime)dateEditop.EditValue;
            dt = dt.AddDays(-8);
            textEditconvocation.EditValue = dt;


            DateTime dt2 = (DateTime)dateEditop.EditValue;
            dt2 = dt2.AddDays(-21);
            textEditportai.EditValue = dt2;

            }

        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {

            WindowsUIButton btn = e.Button as WindowsUIButton;

            if (e.Button == windowsUIButtonPanelMain.Buttons[0])
            {

                try
                {


                    
                   

                    
                    

                        if (id2 == 0)
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
                            Program.sql_cmd.Parameters.AddWithValue("@Aop", textEditAop.Text + textEditaoodate.Text);
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
                            toastNotificationsManager1.ShowNotification("677ae63a-96ce-4b84-bb50-c3feef4564ce");


                            // toastNotificationsManager1.ShowNotification("1d00270b-1651-4ed4-a139-bd59d5d8cf8e");
                            this.Close();

                        }




                    }
                        else
                        {

                        if ( textEditAop.Text == "" || textEditconvocation.Text == "" || textEditJornal.Text == "" || textEditportai.Text == "" || dateEditop.Text == "")
                        {
                            XtraMessageBox.Show("champs obligatoires");

                        }
                        else
                        {
                            DateTime dtconvocation = Convert.ToDateTime(textEditconvocation.EditValue);
                            DateTime dtjORNAL = Convert.ToDateTime(textEditJornal.EditValue);
                            DateTime dtpORTAIL = Convert.ToDateTime(textEditportai.EditValue);
                            DateTime dtop = Convert.ToDateTime(dateEditop.EditValue);


                            string sql = "update  [publication] set [Aop]  = @Aop ,[date_jornal] =  @date_jornal ,[date_portail]  = @date_portail,[date_convocation]  = @date_convocation ,[date_op]  = @date_op where id2 = @id2";


                            Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                            Program.sql_cmd.Parameters.AddWithValue("@Aop", textEditAop.Text + textEditaoodate.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@date_jornal", dtjORNAL);
                            Program.sql_cmd.Parameters.AddWithValue("@date_portail", dtpORTAIL);
                            Program.sql_cmd.Parameters.AddWithValue("@date_convocation", dtconvocation);
                            Program.sql_cmd.Parameters.AddWithValue("@date_op", dtop);
                            Program.sql_cmd.Parameters.AddWithValue("@id2", id2);




                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                            Program.sql_cmd.ExecuteNonQuery();
                            Program.sql_con.Close();





                            toastNotificationsManager1.ShowNotification("63e40279-d885-4efa-91fd-073fbda47ee2");
                           

                            this.Close();
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

            if (e.Button == windowsUIButtonPanelMain.Buttons[1])
            {
                try
                {








                    if (id2 == 0)
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
                            Program.sql_cmd.Parameters.AddWithValue("@Aop", textEditAop.Text + textEditaoodate.Text);
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

                            toastNotificationsManager1.ShowNotification("677ae63a-96ce-4b84-bb50-c3feef4564ce");



                            // toastNotificationsManager1.ShowNotification("1d00270b-1651-4ed4-a139-bd59d5d8cf8e");
                            id2 = 0 ;
                            comboBoxObject.SelectedIndex = -1;
                            textEditAop.Text = "";
                            textEditconvocation.Text = "";
                            textEditJornal.Text = "";
                            textEditportai.Text = "";
                            dateEditop.Text = "";

                        }




                    }
                    else
                    {

                        if (textEditAop.Text == "" || textEditconvocation.Text == "" || textEditJornal.Text == "" || textEditportai.Text == "" || dateEditop.Text == "")
                        {
                            XtraMessageBox.Show("champs obligatoires");

                        }
                        else
                        {
                            DateTime dtconvocation = Convert.ToDateTime(textEditconvocation.EditValue);
                            DateTime dtjORNAL = Convert.ToDateTime(textEditJornal.EditValue);
                            DateTime dtpORTAIL = Convert.ToDateTime(textEditportai.EditValue);
                            DateTime dtop = Convert.ToDateTime(dateEditop.EditValue);


                            string sql = "update  [publication] set [Aop]  = @Aop ,[date_jornal] =  @date_jornal ,[date_portail]  = @date_portail,[date_convocation]  = @date_convocation ,[date_op]  = @date_op where id2 = @id2";


                            Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                            Program.sql_cmd.Parameters.AddWithValue("@Aop", textEditAop.Text + textEditaoodate.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@date_jornal", dtjORNAL);
                            Program.sql_cmd.Parameters.AddWithValue("@date_portail", dtpORTAIL);
                            Program.sql_cmd.Parameters.AddWithValue("@date_convocation", dtconvocation);
                            Program.sql_cmd.Parameters.AddWithValue("@date_op", dtop);
                            Program.sql_cmd.Parameters.AddWithValue("@id2", id2);




                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                            Program.sql_cmd.ExecuteNonQuery();
                            Program.sql_con.Close();





                            toastNotificationsManager1.ShowNotification("63e40279-d885-4efa-91fd-073fbda47ee2");
                            ExecuteQueryobjects();
                            comboBoxObject.SelectedIndex = -1;
                            textEditAop.Text = "";
                            textEditconvocation.Text = "";
                            textEditJornal.Text = "";
                            textEditportai.Text = "";
                            dateEditop.Text = "";
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
            if (e.Button == windowsUIButtonPanelMain.Buttons[2])
            {
                textEditAop.Text = "";
                textEditconvocation.Text = "";
                textEditJornal.Text = "";
                textEditportai.Text = "";
                dateEditop.Text = "";
            }

        }
    }
}