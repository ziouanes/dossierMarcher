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
    public partial class Etude : DevExpress.XtraEditors.XtraForm
    {
        int idEtude = 0;
        DateTime dateenvoyer = DateTime.Now;


        public Etude(int id1 , string objet ,string estimation , string montant , DateTime envoyer_tresoryer  , int délai_dexecution )
        {

            InitializeComponent();
            idEtude = id1;
            richTextBoxobject.Text = objet;
            textEditestimation.Text = estimation;
            textEditCaution.Text = montant;
            dateenvoyer = envoyer_tresoryer;
            textEditdélai.Text = délai_dexecution.ToString();
           

            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                {
                    SqlCommand cmd = Program.sql_con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "SELECT [localite] , [Type_marcher]  , [Nature] , fdr from etude where id1 =" + id1 + "";
                    DataTable table = new DataTable();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        comboBoxcocalite.SelectedValue = row["localite"].ToString();
                        comboBoxnature.SelectedValue = row["Nature"].ToString();
                        comboBoxtype.SelectedValue = row["Type_marcher"].ToString();
                        if (int.Parse(row["fdr"].ToString()) == 1)
                        {
                            checkEditFDR.Checked = true;
                        }
                        else { checkEditFDR.Checked = false; }

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



        public Etude()
        {
            InitializeComponent();
        }

        private void Etude_Load(object sender, EventArgs e)
        {
            textEditCaution.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            textEditCaution.Properties.Mask.EditMask = "n2";
            textEditCaution.Properties.Mask.UseMaskAsDisplayFormat = true;


            textEditdélai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            textEditdélai.Properties.Mask.EditMask = "n0";
            textEditdélai.Properties.Mask.UseMaskAsDisplayFormat = true;

            ExecuteQuerylocality();
            ExecuteQuerytype();
            ExecuteQueryNature();

            if(idEtude != 0)
            {
                dateEditTresorier.EditValue = dateenvoyer;
            }
        }

        private void ExecuteQuerylocality()
        {
            try
            {

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                Program.sql_cmd = Program.sql_con.CreateCommand();
                Program.sql_cmd.CommandType = CommandType.Text;
                Program.sql_cmd.CommandText = "select id_l , localite  from [localite] ";
                Program.sql_cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                Program.adapter = new SqlDataAdapter(Program.sql_cmd);
                Program.adapter.Fill(dt);
                comboBoxcocalite.DataSource = dt;
                comboBoxcocalite.ValueMember = "id_l";
                comboBoxcocalite.DisplayMember = "localite";
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


            comboBoxtype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void ExecuteQuerytype()
        {
            try
            {

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                Program.sql_cmd = Program.sql_con.CreateCommand();
                Program.sql_cmd.CommandType = CommandType.Text;
                Program.sql_cmd.CommandText = "select id_type , type_marcher  from [Type_marcher] ";
                Program.sql_cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                Program.adapter = new SqlDataAdapter(Program.sql_cmd);
                Program.adapter.Fill(dt);
                comboBoxtype.DataSource = dt;
                comboBoxtype.ValueMember = "id_type";
                comboBoxtype.DisplayMember = "type_marcher";
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


            comboBoxtype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void ExecuteQueryNature()
        {
            try
            {

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                Program.sql_cmd = Program.sql_con.CreateCommand();
                Program.sql_cmd.CommandType = CommandType.Text;
                Program.sql_cmd.CommandText = "select id_N , nature  from [Nature] ";
                Program.sql_cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                Program.adapter = new SqlDataAdapter(Program.sql_cmd);
                Program.adapter.Fill(dt);
                comboBoxnature.DataSource = dt;
                comboBoxnature.ValueMember = "id_N";
                comboBoxnature.DisplayMember = "nature";
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


            comboBoxtype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        //setexecutequery
        private void ExecuteQuery(string txtQuery)
        {
            try
            {


                //Program.SetConnection();
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                Program.sql_cmd = Program.sql_con.CreateCommand();
                Program.sql_cmd.CommandText = txtQuery;
                Program.sql_cmd.ExecuteNonQuery();
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

        }
        int fdr = 0;

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;

            if (e.Button == windowsUIButtonPanelMain.Buttons[0])
            {
                try
                {

                    if (checkEditFDR.Checked == true)
                    {
                        fdr = 1;
                    }
                    else
                    {
                        fdr = 0;
                    }

                    if (richTextBoxobject.Text == "" || textEditCaution.Text == "" || dateEditTresorier.Text == "" || comboBoxcocalite.SelectedIndex == -1 || comboBoxnature.SelectedIndex == -1 || comboBoxtype.SelectedIndex == -1)
                    {
                        XtraMessageBox.Show("champs obligatoires");

                    }
                    else

                    {

                        if (idEtude == 0)
                        {
                            string sql = "insert into [etude](objet ,[estimation],[montant],[envoyer_tresoryer],[délai_dexecution] , [localite]  , [Type_marcher] , [Nature] , fdr) VALUES(@objet,@estimation,@montant , @envoyer , @delai  ,@localisation , @type_marcher  ,@nature , @fdr)";


                            Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                            Program.sql_cmd.Parameters.AddWithValue("@objet", richTextBoxobject.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@estimation", textEditestimation.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@montant", textEditCaution.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@envoyer", dateEditTresorier.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@delai", textEditdélai.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@localisation", comboBoxcocalite.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@type_marcher", comboBoxtype.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@nature", comboBoxnature.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@fdr", fdr);




                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                            Program.sql_cmd.ExecuteNonQuery();
                            Program.sql_con.Close();
                            XtraMessageBox.Show("good");

                            // toastNotificationsManager1.ShowNotification("677ae63a-96ce-4b84-bb50-c3feef4564ce");
                            this.Close();


                        }
                        else
                        {
                            string sql = "update  [etude] set objet = @objet ,[estimation] = @estimation ,[montant] = @montant ,[envoyer_tresoryer]  = @envoyer,[délai_dexecution] =  @delai , [localite]  = @localisation , [Type_marcher] = @type_marcher , [Nature]  = @nature , fdr = @fdr where id1 = @id ";


                            Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                            Program.sql_cmd.Parameters.AddWithValue("@objet", richTextBoxobject.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@estimation", textEditestimation.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@montant", textEditCaution.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@envoyer", dateEditTresorier.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@delai", textEditdélai.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@localisation", comboBoxcocalite.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@type_marcher", comboBoxtype.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@nature", comboBoxnature.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@fdr", fdr);

                            Program.sql_cmd.Parameters.AddWithValue("@id", idEtude);



                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                            Program.sql_cmd.ExecuteNonQuery();
                            Program.sql_con.Close();
                            XtraMessageBox.Show("good");


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
                    if(checkEditFDR.Checked == true)
                    {
                        fdr = 1;
                    }
                    else
                    {
                        fdr = 0;
                    }


                    if (richTextBoxobject.Text == "" || textEditCaution.Text == "" || dateEditTresorier.Text == "" || comboBoxcocalite.SelectedIndex == -1 || comboBoxnature.SelectedIndex == -1 || comboBoxtype.SelectedIndex == -1)
                    {
                        XtraMessageBox.Show("champs obligatoires");

                    }
                    else

                    {

                        if (idEtude == 0)
                        {
                            string sql = "insert into [etude](objet ,[estimation],[montant],[envoyer_tresoryer],[délai_dexecution] , [localite]  , [Type_marcher] , [Nature],[fdr]) VALUES(@objet,@estimation,@montant , @envoyer , @delai  ,@localisation , @type_marcher  ,@nature , @fdr)";


                            Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                            Program.sql_cmd.Parameters.AddWithValue("@objet", richTextBoxobject.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@estimation", textEditestimation.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@montant", textEditCaution.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@envoyer", dateEditTresorier.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@delai", textEditdélai.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@localisation", comboBoxcocalite.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@type_marcher", comboBoxtype.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@nature", comboBoxnature.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@nature", comboBoxnature.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@fdr", fdr);





                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                            Program.sql_cmd.ExecuteNonQuery();
                            Program.sql_con.Close();
                            XtraMessageBox.Show("good");

                            // toastNotificationsManager1.ShowNotification("1d00270b-1651-4ed4-a139-bd59d5d8cf8e");
                            richTextBoxobject.Text = "";
                            textEditCaution.Text = "";
                            dateEditTresorier.Text = "";
                            comboBoxcocalite.SelectedIndex = -1;
                            comboBoxnature.SelectedIndex = -1;
                            comboBoxtype.SelectedIndex = -1;


                        }
                        else
                        {
                            string sql = "update  [etude] set objet = @objet ,[estimation] = @estimation ,[montant] = @montant ,[envoyer_tresoryer]  = @envoyer,[délai_dexecution] =  @delai , [localite]  = @localisation , [Type_marcher] = @type_marcher , [Nature]  = @nature , fdr = @fdr where id1 = @id ";


                            Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                            Program.sql_cmd.Parameters.AddWithValue("@objet", richTextBoxobject.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@estimation", textEditestimation.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@montant", textEditCaution.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@envoyer", dateEditTresorier.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@delai", textEditdélai.Text);
                            Program.sql_cmd.Parameters.AddWithValue("@localisation", comboBoxcocalite.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@type_marcher", comboBoxtype.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@nature", comboBoxnature.SelectedValue);
                            Program.sql_cmd.Parameters.AddWithValue("@id", idEtude);
                            Program.sql_cmd.Parameters.AddWithValue("@fdr", fdr);




                            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                            Program.sql_cmd.ExecuteNonQuery();
                            Program.sql_con.Close();
                            XtraMessageBox.Show("good");

                            idEtude = 0;
                            richTextBoxobject.Text = "";
                            textEditCaution.Text = "";
                            dateEditTresorier.Text = "";
                            comboBoxcocalite.SelectedIndex = -1;
                            comboBoxnature.SelectedIndex = -1;
                            comboBoxtype.SelectedIndex = -1;
                            checkEditFDR.Checked = true;
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
                idEtude = 0;
                richTextBoxobject.Text = "";
                textEditCaution.Text = "";
                dateEditTresorier.Text = "";
                comboBoxcocalite.SelectedIndex = -1;
                comboBoxnature.SelectedIndex = -1;
                comboBoxtype.SelectedIndex = -1;
                checkEditFDR.Checked = false;
            }
        }

        private void comboBoxnature_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}