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
    public partial class overt : DevExpress.XtraEditors.XtraForm
    {
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
                    //else

                    //{

                    //    if (idEtude == 0)
                    //    {
                    //        string sql = "insert into [etude](objet ,[estimation],[montant],[envoyer_tresoryer],[délai_dexecution] , [localite]  , [Type_marcher] , [Nature]) VALUES(@objet,@estimation,@montant , @envoyer , @delai  ,@localisation , @type_marcher  ,@nature)";


                    //        Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                    //        Program.sql_cmd.Parameters.AddWithValue("@objet", richTextBoxobject.Text);
                    //        Program.sql_cmd.Parameters.AddWithValue("@estimation", textEditestimation.Text);
                    //        Program.sql_cmd.Parameters.AddWithValue("@montant", textEditCaution.Text);
                    //        Program.sql_cmd.Parameters.AddWithValue("@envoyer", dateEditTresorier.Text);
                    //        Program.sql_cmd.Parameters.AddWithValue("@delai", textEditdélai.Text);
                    //        Program.sql_cmd.Parameters.AddWithValue("@localisation", comboBoxcocalite.SelectedValue);
                    //        Program.sql_cmd.Parameters.AddWithValue("@type_marcher", comboBoxtype.SelectedValue);
                    //        Program.sql_cmd.Parameters.AddWithValue("@nature", comboBoxnature.SelectedValue);



                    //        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                    //        Program.sql_cmd.ExecuteNonQuery();
                    //        Program.sql_con.Close();
                    //        XtraMessageBox.Show("good");

                    //        // toastNotificationsManager1.ShowNotification("677ae63a-96ce-4b84-bb50-c3feef4564ce");
                    //        this.Close();


                    //    }
                    //    else
                    //    {
                    //        string sql = "update  [etude] set objet = @objet ,[estimation] = @estimation ,[montant] = @montant ,[envoyer_tresoryer]  = @envoyer,[délai_dexecution] =  @delai , [localite]  = @localisation , [Type_marcher] = @type_marcher , [Nature]  = @nature where id1 = @id ";


                    //        Program.sql_cmd = new SqlCommand(sql, Program.sql_con);
                    //        Program.sql_cmd.Parameters.AddWithValue("@objet", richTextBoxobject.Text);
                    //        Program.sql_cmd.Parameters.AddWithValue("@estimation", textEditestimation.Text);
                    //        Program.sql_cmd.Parameters.AddWithValue("@montant", textEditCaution.Text);
                    //        Program.sql_cmd.Parameters.AddWithValue("@envoyer", dateEditTresorier.Text);
                    //        Program.sql_cmd.Parameters.AddWithValue("@delai", textEditdélai.Text);
                    //        Program.sql_cmd.Parameters.AddWithValue("@localisation", comboBoxcocalite.SelectedValue);
                    //        Program.sql_cmd.Parameters.AddWithValue("@type_marcher", comboBoxtype.SelectedValue);
                    //        Program.sql_cmd.Parameters.AddWithValue("@nature", comboBoxnature.SelectedValue);
                    //        Program.sql_cmd.Parameters.AddWithValue("@id", idEtude);



                    //        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                    //        Program.sql_cmd.ExecuteNonQuery();
                    //        Program.sql_con.Close();
                    //        XtraMessageBox.Show("good");


                    //        this.Close();
                    //    }


                   // }
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