﻿using DevExpress.XtraBars.Docking2010;
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
    public partial class overt : DevExpress.XtraEditors.XtraForm
    {

        int idOvert = 0;

        public overt(int id3 ,string attributaire, string Montant, string num_Marcher, int délai_dexecution, int caution_return, int caution_definitif, DateTime date_Visa,  DateTime date_approbation, DateTime datenotifiy, DateTime date_caution)
        {
            idOvert = id3;
            
        }

        public overt()
        {
            InitializeComponent();
        }

        private void Montant_EditValueChanged(object sender, EventArgs e)
        {
            if (Montant.Text != "")
            {



                float montant = float.Parse(Montant.Text);
                var roundedA = Math.Ceiling(((montant * 3) / 100) + .00); // Output: 1

                textEditdefinitif.Text = roundedA.ToString();
                caution_return.Text = ((montant * 7) / 100).ToString();

            }
            else
            {
                textEditdefinitif.Text = "";
                caution_return.Text = "";
            }


        }

        private void ExecuteQueryoVERTURE()
        {
            //if (id2 == 0)
            //{
            try
            {

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                Program.sql_cmd = Program.sql_con.CreateCommand();
                Program.sql_cmd.CommandType = CommandType.Text;
                Program.sql_cmd.CommandText = " select id2 , Aop   from [publication]  where validate  = 1 and id2  not in ( select id2  from fk2 ) ";
                Program.sql_cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                Program.adapter = new SqlDataAdapter(Program.sql_cmd);
                Program.adapter.Fill(dt);
                comboBoxAoo.DataSource = dt;
                comboBoxAoo.ValueMember = "id2";
                comboBoxAoo.DisplayMember = "Aop";
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


            comboBoxAoo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;


        }

        private void Montant_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void overt_Load(object sender, EventArgs e)
        {
            ExecuteQueryoVERTURE();
            Montant.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Montant.Properties.Mask.EditMask = "n2";
            Montant.Properties.Mask.UseMaskAsDisplayFormat = true;

            textEditdefinitif.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            textEditdefinitif.Properties.Mask.EditMask = "n0";
            textEditdefinitif.Properties.Mask.UseMaskAsDisplayFormat = true;

            var roundedA = Math.Ceiling(1 + .00); // Output: 1

            textEdit3.Text = roundedA.ToString();

            editable.Checked = false;


        }

        private void comboBoxAoo_SelectionChangeCommitted(object sender, EventArgs e)
        {



            string s = "1";
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
            if (comboBoxAoo.SelectedIndex > -1)
            {
                SqlCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                s = comboBoxAoo.SelectedItem.ToString();
                cmd.CommandText = "select e.[délai_dexecution] as délai_dexecution  from etude e inner join  fk f on e.id1 = f.id1 inner join  publication p on p.id2 = f.id2 where p.Aop = '" + s + "'";

                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    MessageBox.Show(row["délai_dexecution"].ToString());

                    délai_dexecution.EditValue = row["délai_dexecution"].ToString();



                }

            }
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;

            if (e.Button == windowsUIButtonPanelMain.Buttons[0])
            {
                try
                {

                    if (attributaire.Text == "" || Montant.Text == "" || num_Marcher.Text == "" || comboBoxAoo.SelectedIndex == -1 || dateEditdate_approbation.Text == "" || délai_dexecution.Text == "" )
                    {
                        XtraMessageBox.Show("champs obligatoires");

                    }
                    else

                    {


                        if (idOvert == 0)
                        {
                            if(editable_ == false)
                            {
                            string sql = "insert into [SIMPLE_overture](attributaire ,[Montant],[num_Marcher],[date_Visa],[date_approbation] , [délai_dexecution]  , [caution_definitif] , [caution_return]) VALUES(@attributaire,@Montant,@num_Marcher , @date_Visa , @date_approbation  ,@délai_dexecution , @caution_definitif  ,@caution_return)";


                            Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                            Program.sql_cmd.Parameters.AddWithValue("@attributaire", attributaire.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@Montant", Montant.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@num_Marcher", num_Marcher.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@date_Visa", dateEditvisa.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@date_approbation", dateEditdate_approbation.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@délai_dexecution", délai_dexecution.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@caution_definitif", textEditdefinitif.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@caution_return", caution_return.Text);



                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                            Program.sql_cmd.ExecuteNonQuery();
                            Program.sql_con.Close();
                            XtraMessageBox.Show("good");

                              


                                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                                Program.sql_cmd = new SqlCommand("SELECT TOP 1 id3 FROM [SIMPLE_overture] ORDER BY id3 DESC", Program.sql_con);
                                string id = "";
                                Program.db = Program.sql_cmd.ExecuteReader();
                                if (Program.db.HasRows)
                                {


                                    Program.db.Read();


                                    id = Program.db[0].ToString();

                                }

                                string sql2 = "insert into [fk2](id2 ,id3 ) VALUES(@id2,@id3) ";


                                Program.sql_cmd = new SqlCommand(sql2, Program.sql_con);
                                Program.sql_cmd.Parameters.AddWithValue("@id1", comboBoxAoo.SelectedValue.ToString());
                                Program.sql_cmd.Parameters.AddWithValue("@id2", id);




                                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                                Program.sql_cmd.ExecuteNonQuery();
                                Program.sql_con.Close();
                                ///toastNotificationsManager1.ShowNotification("677ae63a-96ce-4b84-bb50-c3feef4564ce");


                                // toastNotificationsManager1.ShowNotification("1d00270b-1651-4ed4-a139-bd59d5d8cf8e");

                                // toastNotificationsManager1.ShowNotification("677ae63a-96ce-4b84-bb50-c3feef4564ce");
                                this.Close();

                            }
                            else
                            {

                                string sql = "insert into [SIMPLE_overture](attributaire ,[Montant],[num_Marcher],[date_Visa],[date_approbation] , [délai_dexecution]  , [caution_definitif] , [caution_return] , [datenotifiy] ,[date_caution] ) VALUES(@attributaire,@Montant,@num_Marcher , @date_Visa , @date_approbation  ,@délai_dexecution , @caution_definitif  ,@caution_return,@datenotifiy,@date_caution)";


                                Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                                Program.sql_cmd.Parameters.AddWithValue("@attributaire", attributaire.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@Montant", Montant.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@num_Marcher", num_Marcher.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@date_Visa", dateEditvisa.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@date_approbation", dateEditdate_approbation.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@délai_dexecution", délai_dexecution.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@caution_definitif", textEditdefinitif.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@caution_return", caution_return.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@datenotifiy", datenotifiy.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@date_caution", dateEdit_caution.Text);




                                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                                Program.sql_cmd.ExecuteNonQuery();
                                Program.sql_con.Close();
                                XtraMessageBox.Show("good");




                                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                                Program.sql_cmd = new SqlCommand("SELECT TOP 1 id3 FROM [SIMPLE_overture] ORDER BY id3 DESC", Program.sql_con);
                                string id = "";
                                Program.db = Program.sql_cmd.ExecuteReader();
                                if (Program.db.HasRows)
                                {


                                    Program.db.Read();


                                    id = Program.db[0].ToString();

                                }

                                string sql2 = "insert into [fk2](id2 ,id3 ) VALUES(@id2,@id3) ";


                                Program.sql_cmd = new SqlCommand(sql2, Program.sql_con);
                                Program.sql_cmd.Parameters.AddWithValue("@id1", comboBoxAoo.SelectedValue.ToString());
                                Program.sql_cmd.Parameters.AddWithValue("@id2", id);




                                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                                Program.sql_cmd.ExecuteNonQuery();
                                Program.sql_con.Close();
                                ///toastNotificationsManager1.ShowNotification("677ae63a-96ce-4b84-bb50-c3feef4564ce");


                                // toastNotificationsManager1.ShowNotification("1d00270b-1651-4ed4-a139-bd59d5d8cf8e");

                                // toastNotificationsManager1.ShowNotification("677ae63a-96ce-4b84-bb50-c3feef4564ce");
                                this.Close();

                            }


                        }
                        else
                        {
                            if (editable_ == false)
                            {
                                string sql = "update  [SIMPLE_overture] set attributaire = @attributaire ,[Montant] = @Montant ,[num_Marcher] = @num_Marcher ,[date_Visa]  = @date_Visa,[date_approbation] =  @date_approbation , [délai_dexecution]  = @délai_dexecution , [caution_definitif] = @caution_definitif , [caution_return]  = @caution_return where id3 = @id ";


                            Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                                Program.sql_cmd.Parameters.AddWithValue("@attributaire", attributaire.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@Montant", Montant.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@num_Marcher", num_Marcher.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@date_Visa", dateEditvisa.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@date_approbation", dateEditdate_approbation.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@délai_dexecution", délai_dexecution.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@caution_definitif", textEditdefinitif.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@caution_return", caution_return.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@id", idOvert);



                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                            Program.sql_cmd.ExecuteNonQuery();
                            Program.sql_con.Close();
                            XtraMessageBox.Show("good");


                            this.Close();

                            }
                            else
                            {
                                string sql = "update  [SIMPLE_overture] set attributaire = @attributaire ,[Montant] = @Montant ,[num_Marcher] = @num_Marcher ,[date_Visa]  = @date_Visa,[date_approbation] =  @date_approbation , [délai_dexecution]  = @délai_dexecution , [caution_definitif] = @caution_definitif , [caution_return]  = @caution_return , datenotifiy = @datenotifiy , date_caution = @date_caution  where id3 = @id ";


                                Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                                Program.sql_cmd.Parameters.AddWithValue("@attributaire", attributaire.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@Montant", Montant.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@num_Marcher", num_Marcher.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@date_Visa", dateEditvisa.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@date_approbation", dateEditdate_approbation.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@délai_dexecution", délai_dexecution.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@caution_definitif", textEditdefinitif.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@caution_return", caution_return.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@datenotifiy", datenotifiy.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@date_caution", dateEdit_caution.Text);
                                Program.sql_cmd.Parameters.AddWithValue("@id", idOvert);



                                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                                Program.sql_cmd.ExecuteNonQuery();
                                Program.sql_con.Close();
                                XtraMessageBox.Show("good");


                                this.Close();
                            }

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
                attributaire.Text = "";
                Montant.Text = "";
                num_Marcher.Text = "";
                comboBoxAoo.SelectedIndex = -1;
                dateEditdate_approbation.Text = "";
                délai_dexecution.Text = "";
                



            }


        }
        bool editable_  = false;
        private void editable_CheckedChanged(object sender, EventArgs e)
        {


            if (editable.Checked)
            {
                layoutControlGroup8.Enabled = true;
                editable_ = true;

            }
            else
            {
                layoutControlGroup8.Enabled = false;
                editable_ = false;

            }
        }
    }
}