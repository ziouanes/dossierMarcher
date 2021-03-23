using Dapper;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
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





                string query = $"select id2 , Aop , date_jornal , date_portail , date_convocation , validate  , duree_portail , duree_Jornal  , date_op  from publication where deleted = 0  order by id2 desc ; " ;
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



                

                    string query = $"select id1 , objet , estimation , montant , envoyer_tresoryer , validate  , délai_dexecution   from etude where deleted = 0   order by id1 desc ; ";
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

        private void select_Overt_Data()
        {
            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id3 , attributaire , Montant , num_Marcher , date_Visa  , date_approbation  , valide_approbation  , duree_approbation , délai_dexecution  , caution_definitif , caution_return , datenotifiy , date_caution , valide_caution , duree_caution  , valide_order_service  , duree_order_service from SIMPLE_overture order by id3 desc";
                classSIMPLEovertureBindingSource.DataSource = Program.sql_con.Query<ClassSIMPLE_overture>(query, commandType: CommandType.Text);



                //Changing the appearance settings of column cells dynamically
                gridViewOvert.RowCellStyle += (sender, e) =>
                {
                    GridView view = sender as GridView;
                    int valide_order_service = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["valide_order_service"]).ToString());

                    if (valide_order_service != 1)
                    {
                        int valide_caution = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["valide_caution"]).ToString());
                        if (e.Column.FieldName == "date_caution")
                        {

                            if (valide_caution == 1)

                            {
                                e.Appearance.BackColor = Color.LightGreen;
                                //e.Appearance.TextOptions.HAlignment = _mark ? HorzAlignment.Far : HorzAlignment.Near;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.LightSalmon;

                            }

                        }
                        //
                        int valide_Approbation = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["valide_approbation"]).ToString());

                        if (e.Column.FieldName == "date_approbation")
                        {

                            if (valide_Approbation == 1)

                            {
                                e.Appearance.BackColor = Color.LightGreen;
                                //e.Appearance.TextOptions.HAlignment = _mark ? HorzAlignment.Far : HorzAlignment.Near;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.LightSalmon;

                            }



                        }

                    }

                    ////




                };
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
            select_Overt_Data();
            gridViewOvert.OptionsSelection.EnableAppearanceFocusedRow = false;

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
            int cell_validate;



            id2 = int.Parse(gridViewPub.GetRowCellValue(row2, "id2").ToString());
            cellaoo = gridViewPub.GetRowCellValue(row2, "Aop").ToString();
            celldateJornal = Convert.ToDateTime(gridViewPub.GetRowCellValue(row2, "date_jornal").ToString());
            celldateconvocation = Convert.ToDateTime(gridViewPub.GetRowCellValue(row2, "date_convocation").ToString());
            cellDatePortail = Convert.ToDateTime((gridViewPub.GetRowCellValue(row2, "date_portail")));
            celldateOverture = Convert.ToDateTime(gridViewPub.GetRowCellValue(row2, "date_OP").ToString());
            cell_validate = int.Parse(gridViewPub.GetRowCellValue(row2, "validate").ToString());


            publication pub = new publication(id2, cellaoo, celldateJornal, celldateconvocation, cellDatePortail, celldateOverture , cell_validate);
            pub.ShowDialog();
            select_Publication_Data();

        }

        private void gridViewOvert_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            
           

        }

        //private void gridViewOvert_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        //{
        //    GridView view = sender as GridView;

        //    if (e.RowHandle == view.FocusedRowHandle) return;
        //    if (e.Column.FieldName == "date_approbation")
        //    {
        //    int valide_app = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["valide_approbation"]).ToString());
        //    if (valide_app == 1)
        //    {
        //        e.Appearance.BackColor2 = Color.FromArgb(60, Color.Green);
        //    }
        //    else
        //    {
        //        e.Appearance.BackColor2 = Color.FromArgb(60, Color.Red);
        //    }

        //    }


        //    //////////////
        //    GridView view1 = sender as GridView;

        //    if (e.RowHandle == view1.FocusedRowHandle) return ;

        //    if (e.Column.FieldName == "date_caution")
        //    {

        //    int valide_caution = int.Parse(view1.GetRowCellValue(e.RowHandle, view1.Columns["valide_caution"]).ToString());
        //    if (valide_caution == 1)
        //    {
        //        e.Appearance.BackColor = Color.FromArgb(60, Color.Green);

        //        }
        //        else
        //    {
        //        e.Appearance.BackColor = Color.FromArgb(60, Color.Red);

        //        }


        //    }

        //    ////////
        //    GridView view2 = sender as GridView;

        //    if (e.RowHandle == view1.FocusedRowHandle) return;

        //    if (e.Column.FieldName == "duree_order_service")
        //    {
                
        //        int valide_order_service = int.Parse(view1.GetRowCellValue(e.RowHandle, view1.Columns["valide_order_service"]).ToString());
        //        if (valide_order_service == 1)
        //        {
        //            e.Appearance.BackColor2 = Color.FromArgb(60, Color.Green);
        //        }
        //        else
        //        {
        //            e.Appearance.BackColor2 = Color.FromArgb(60, Color.Red);
        //        }

        //    }











        //}

        private void gridViewOvert_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //gridViewOvert.Appearance.FocusedRow.BackColor = Color.FromArgb(100, 180, 80); //Applied when the grid is focused

            //gridViewOvert.Appearance.FocusedRow.ForeColor = Color.LightYellow;


           // gridViewOvert.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridViewOvert.OptionsSelection.EnableAppearanceFocusedCell = false;


        }

        private void gridControlOvert_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gridControlOvert_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var rowM = gridViewOvert.FocusedRowHandle;

            string validate_approbation;
            string valide_caution;
            string valide_order_s;
            validate_approbation = gridViewOvert.GetRowCellValue(rowM, "valide_approbation").ToString();
            valide_caution = gridViewOvert.GetRowCellValue(rowM, "valide_caution").ToString();
            valide_order_s = gridViewOvert.GetRowCellValue(rowM, "valide_order_service").ToString();
            if (int.Parse(validate_approbation) == 0)
            {

                if (rowM >= 0)
                    popupMenucaution.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                else
                    popupMenucaution.HidePopup();
            }
            else if (int.Parse(valide_caution) == 0)
            {
                if (rowM >= 0)
                    popupMenucaution.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                else
                    popupMenucaution.HidePopup();

            }
            else if (int.Parse(valide_order_s) == 0)
            {
                if (rowM >= 0)
                    popupMenu_order_s.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                else
                    popupMenu_order_s.HidePopup();
            }
            else if (int.Parse(valide_order_s) == 1)
            {
                if (rowM >= 0)
                    popupMenu_suivi_orders.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                else
                    popupMenu_suivi_orders.HidePopup();
            }
        }

        private void gridViewOvert_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string validate = View.GetRowCellDisplayText(e.RowHandle, View.Columns["valide_order_service"]);
                if (validate == "1")
                {
                    e.Appearance.BackColor = Color.Orange;
                    
                    //e.HighPriority = true;
                }
               
            }
        }

        private void barButtonouverture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            overt ov = new overt();
            ov.ShowDialog();
        }

        private void barButtonItem_modifier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridViewEtude.FocusedRowHandle;
            int id3;
            string   cellattributaire;
            string   cellMontant;
            string cellnum_Marcher;
            int celldélai_dexecution;
            int cellcaution_return;
            int cellcaution_definitif;
            DateTime celldate_Visa;
            DateTime celldate_approbation;
            DateTime celldatenotifiy;
            DateTime delldate_caution;

            int cell_validate;



            id3 = int.Parse(gridViewEtude.GetRowCellValue(row2, "id3").ToString());
            cellattributaire = gridViewEtude.GetRowCellValue(row2, "attributaire").ToString();
            cellMontant = gridViewEtude.GetRowCellValue(row2, "Montant").ToString();
            cellnum_Marcher = gridViewEtude.GetRowCellValue(row2, "num_Marcher").ToString();
            celldélai_dexecution = int.Parse(gridViewEtude.GetRowCellValue(row2, "délai_dexecution").ToString());
            cellcaution_return = int.Parse(gridViewEtude.GetRowCellValue(row2, "caution_return").ToString());
            cellcaution_definitif = int.Parse(gridViewEtude.GetRowCellValue(row2, "caution_definitif").ToString());
            celldate_Visa = Convert.ToDateTime(gridViewEtude.GetRowCellValue(row2, "date_Visa").ToString());
            celldate_approbation  = Convert.ToDateTime(gridViewEtude.GetRowCellValue(row2, "date_approbation").ToString());
            celldatenotifiy = Convert.ToDateTime(gridViewEtude.GetRowCellValue(row2, "datenotifiy").ToString());
            delldate_caution = Convert.ToDateTime(gridViewEtude.GetRowCellValue(row2, "date_caution").ToString());

            overt ov = new overt(id3, cellattributaire, cellMontant, cellnum_Marcher, celldélai_dexecution, cellcaution_return, cellcaution_definitif, celldate_Visa, celldate_approbation, celldatenotifiy, delldate_caution);
            ov.ShowDialog();
            select_Publication_Data();
        }
    }
}