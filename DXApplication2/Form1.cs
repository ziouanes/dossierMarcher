using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonEtude_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Etude fm = new Etude();

            fm.ShowDialog();
        }

        private void select_Etude_Data()
        {
            try
            {
                using (Program.sql_con)

                {
                    if (Program.sql_con.State == ConnectionState.Closed)
                        Program.sql_con.Open();

                    string query = $"select id1 , objet , estimation , montant , envoyer_tresoryer , validate  , délai_dexecution   from etude where deleted = 0  ; ";
                    classEtudeBindingSource.DataSource = Program.sql_con.Query<ClassEtude>(query, commandType: CommandType.Text);


                }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            select_Etude_Data();
        }

        private void barButtonPublication_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            publication fm = new publication();

            fm.ShowDialog();
        }

        private void officeNavigationBar_Click(object sender, EventArgs e)
        {

        }

        private void gridViewEtude_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
             
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string validate = View.GetRowCellDisplayText(e.RowHandle, View.Columns["validate"]);
                    if (validate == "0")
                    {
                        e.Appearance.BackColor = Color.Cyan;
                        e.Appearance.BackColor2 = Color.SeaShell;
                        e.HighPriority = true;
                    }
                if (validate == "1")
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
                if (validate == "-1")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
            

        }

    }
}