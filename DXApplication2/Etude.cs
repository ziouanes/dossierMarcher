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
        public Etude()
        {
            InitializeComponent();
        }

        private void Etude_Load(object sender, EventArgs e)
        {
            ExecuteQuerylocality();
            ExecuteQuerytype();
            ExecuteQueryNature();
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
    }
}