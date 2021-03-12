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
            select_Etude_Data();
            select_Publication_Data();
        }

        private void select_Publication_Data()
        {
            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id2 , Aop , date_jornal , date_portail , date_convocation , validate  , duree_portail , duree_Jornal  , date_op  from publication where deleted = 0  ; " ;
                classpublicationBindingSource.DataSource = Program.sql_con.Query<Class_publication>(query, commandType: CommandType.Text);



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



            private void select_Etude_Data()
        {
            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();



                

                    string query = $"select id1 , objet , estimation , montant , envoyer_tresoryer , validate  , délai_dexecution   from etude where deleted = 0  ; ";
                    classEtudeBindingSource.DataSource = Program.sql_con.Query<ClassEtude>(query, commandType: CommandType.Text);


                
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
            select_Publication_Data();
        }

        private void barButtonPublication_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            publication fm = new publication();

            fm.ShowDialog();

            select_Publication_Data();

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
                        e.Appearance.BackColor = Color.Gray;
                        e.Appearance.BackColor2 = Color.SeaShell;
                        e.HighPriority = true;
                    }
                }
            

        }

        private void barButtonItem_validate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var row3 = gridViewEtude.FocusedRowHandle;
            string cellid;
            cellid = gridViewEtude.GetRowCellValue(row3, "id1").ToString();

            if (MessageBox.Show("Voulez-vous vraiment Valider cette Etude   ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    using (SqlCommand deleteCommand = new SqlCommand("update etude set validate = 1 WHERE id1 = @id", Program.sql_con))
                    {


                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                        deleteCommand.Parameters.AddWithValue("@id", int.Parse(cellid));

                        deleteCommand.ExecuteNonQuery();



                    }
                    select_Etude_Data();
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

        private void gridControlEtude_MouseUp(object sender, MouseEventArgs e)
        {
            
          


            if (e.Button != MouseButtons.Right) return;
            var rowM = gridViewEtude.FocusedRowHandle;

            string validate;
            validate = gridViewEtude.GetRowCellValue(rowM, "validate").ToString();

            if (int.Parse(validate) == 0)
            {

            if (rowM >= 0)
                popupMenuetude.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
            else
                popupMenuetude.HidePopup();
            }
            else if (int.Parse(validate) == 1)
            {
                if (rowM >= 0)
                    popupMenu_validate.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                else
                    popupMenu_validate.HidePopup();

            }


        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {


        }

        private void gridControlPub_Click(object sender, EventArgs e)
        {

        }

        private void gridViewPub_RowStyle(object sender, RowStyleEventArgs e)
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
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
        }

        private void gridControlPub_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var rowM = gridViewPub.FocusedRowHandle;

            string validate;
            validate = gridViewPub.GetRowCellValue(rowM, "validate").ToString();

            if (int.Parse(validate) == 0)
            {

                if (rowM >= 0)
                    popupMenupub.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                else
                    popupMenupub.HidePopup();
            }
            else if (int.Parse(validate) == 1)
            {
                if (rowM >= 0)
                    popupMenuPub_validate.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                else
                    popupMenuPub_validate.HidePopup();

            }
        }

        private void barButtonItem_delete_etude_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridViewEtude.FocusedRowHandle;
            string cellid;
            cellid = gridViewEtude.GetRowCellValue(row2, "id1").ToString();

                if (MessageBox.Show("Voulez-vous vraiment Annuler cette Etude   ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
            try
            {


                    using (SqlCommand deleteCommand = new SqlCommand("update etude set validate = -1 WHERE id1 = @id", Program.sql_con))
                {


                    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                    deleteCommand.Parameters.AddWithValue("@id", int.Parse(cellid));

                    deleteCommand.ExecuteNonQuery();



                }
                    select_Etude_Data();
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

        private void barButtonItemedit_Etude_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridViewEtude.FocusedRowHandle;
            int cellid;
            string cellobjet;
            string cellEstimation;
            string montant;
            DateTime cellEnvoyer_tresorier;
            int délai_dexecution;
           


            cellid = int.Parse(gridViewEtude.GetRowCellValue(row2, "id1").ToString());
            cellobjet = gridViewEtude.GetRowCellValue(row2, "objet").ToString();
            cellEstimation = gridViewEtude.GetRowCellValue(row2, "estimation").ToString();
            montant = gridViewEtude.GetRowCellValue(row2, "montant").ToString();
            cellEnvoyer_tresorier = Convert.ToDateTime(gridViewEtude.GetRowCellValue(row2, "envoyer_tresoryer"));
            délai_dexecution = int.Parse(gridViewEtude.GetRowCellValue(row2, "délai_dexecution").ToString());



            Etude etude = new Etude(cellid, cellobjet, cellEstimation, montant, cellEnvoyer_tresorier, délai_dexecution);
            etude.ShowDialog();
            select_Etude_Data();


        }

        private void barButtonItem_valider_pub_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row3 = gridViewPub.FocusedRowHandle;
            string cellid;
            cellid = gridViewPub.GetRowCellValue(row3, "id2").ToString();

            if (MessageBox.Show("Voulez-vous vraiment Valider cette Publication   ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    using (SqlCommand deleteCommand = new SqlCommand("update publication set validate = 1 WHERE id2 = @id", Program.sql_con))
                    {


                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                        deleteCommand.Parameters.AddWithValue("@id", int.Parse(cellid));

                        deleteCommand.ExecuteNonQuery();



                    }
                    select_Publication_Data();
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

        private void barButtonItem_annuler_pub_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridViewPub.FocusedRowHandle;
            string cellid;
            cellid = gridViewPub.GetRowCellValue(row2, "id2").ToString();

            if (MessageBox.Show("Voulez-vous vraiment Annuler cette Publication   ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    using (SqlCommand deleteCommand = new SqlCommand("update publication set validate = -1 WHERE id2 = @id", Program.sql_con))
                    {


                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                        deleteCommand.Parameters.AddWithValue("@id", int.Parse(cellid));

                        deleteCommand.ExecuteNonQuery();



                    }
                    select_Publication_Data();
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

        private void barButtonItemedit_pub_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridViewPub.FocusedRowHandle;
            int id2;
            string cellaoo;
            DateTime celldateJornal;
            DateTime celldateconvocation;
            DateTime cellDatePortail;
            DateTime celldateOverture;



            //id2 = int.Parse(gridViewPub.GetRowCellValue(row2, "id2").ToString());
            //cellaoo = gridViewPub.GetRowCellValue(row2, "Aop").ToString();
            //celldateJornal = gridViewPub.GetRowCellValue(row2, "date_jornal").ToString();
            //celldateconvocation = gridViewPub.GetRowCellValue(row2, "date_convocation").ToString();
            //cellDatePortail = Convert.ToDateTime(gridViewPub.GetRowCellValue(row2, "date_portail"));
            //celldateOverture = int.Parse(gridViewPub.GetRowCellValue(row2, "délai_dexecution").ToString());



            //Etude etude = new Etude(cellid, cellobjet, cellEstimation, montant, cellEnvoyer_tresorier, délai_dexecution);
            //etude.ShowDialog();
            select_Etude_Data();

        }
    }
}