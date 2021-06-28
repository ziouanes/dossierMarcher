using Dapper;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            //
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        public void run()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormsplach), true, true, false);

            SplashScreenManager.Default.SetWaitFormCaption("en cours d'exécution");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1);
            }
            SplashScreenManager.CloseForm();
        }

        private void barButtonEtude_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            run();
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
           

            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("dossierMarche", Application.ExecutablePath.ToString());
            
            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon1.BalloonTipText = "votre application a été réduite dans la barre d'état système";
            notifyIcon1.ShowBalloonTip(1000);
            notifyIcon1.Visible = true;

            label1.Visible = false;

            this.KeyPreview = true;

            select_Etude_Data();
            select_Publication_Data();
            select_Overt_Data();

            RunStoredProc_duree_portail();



            gridViewOvert.OptionsSelection.EnableAppearanceFocusedRow = false;

            valide_sms(); 

            if(label1.Visible == true)
            {
              //  RunStoredProc_caution();
              //  RunStoredProc_duree_order_service();

            RunStoredProc_duree_portail();
            //RunStoredProc_Approbation();

            }
        }


        public void RunStoredProc_duree_portail()
        {



            try
            {
                //    for (int i = 0; i < gridViewPub.DataRowCount; i++)
                //    {
                //      //if(  int.Parse(gridViewPub.GetRowCellValue(i, "duree_portail").ToString()) < 100 && int.Parse(gridViewPub.GetRowCellValue(i, "duree_portail").ToString())>=0) {
                //        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                //        SqlCommand cmd = new SqlCommand("dbo.p1", Program.sql_con);
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Parameters.AddWithValue("@id", int.Parse(gridViewPub.GetRowCellValue(i, "id2").ToString()));
                //        cmd.Parameters.AddWithValue("@jornal", gridViewPub.GetRowCellValue(i, "date_jornal").ToString());
                //        cmd.Parameters.AddWithValue("@date_op", gridViewPub.GetRowCellValue(i, "date_portail").ToString());
                //        cmd.ExecuteNonQuery();
                //    MessageBox.Show("ss");

                //        //}
                //        //do something  
                //    }  
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                SqlCommand cmd = new SqlCommand("dbo.p1_cursor", Program.sql_con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();





            }

            finally
            {
                if (Program.sql_con != null)
                {
                    Program.sql_con.Close();
                }
                if (Program.db != null)
                {
                    Program.db.Close();
                }
            }
            select_Publication_Data();

        }

        //public void RunStoredProc_Approbation()
        //{



        //    try
        //    {
        //        //for (int i = 0; i < gridViewOvert.DataRowCount; i++)
        //        //{
        //            //if (int.Parse(gridViewOvert.GetRowCellValue(i, "duree_approbation").ToString()) < 100)
        //            //{

        //                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
        //                SqlCommand cmd = new SqlCommand("dbo.approbation_cursor", Program.sql_con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                //cmd.Parameters.AddWithValue("@id", int.Parse(gridViewOvert.GetRowCellValue(i, "id3").ToString()));
                       
        //                cmd.ExecuteNonQuery();
        //           // }

        //            //do something  
             








        //    }
        //    finally
        //    {
        //        if (Program.sql_con != null)
        //        {
        //            Program.sql_con.Close();
        //        }
        //        if (Program.db != null)
        //        {
        //            Program.db.Close();
        //        }
        //    }
        //    select_Overt_Data();

        //}

        //public void RunStoredProc_caution()
        //{



        //    try
        //    {
        //        for (int i = 0; i < gridViewOvert.DataRowCount; i++)
        //        {
        //            if (int.Parse(gridViewOvert.GetRowCellValue(i, "duree_caution").ToString()) < 100)
        //            {

        //                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
        //                SqlCommand cmd = new SqlCommand("dbo.CAUTION", Program.sql_con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@id", int.Parse(gridViewOvert.GetRowCellValue(i, "id3").ToString()));

        //                cmd.ExecuteNonQuery();
        //                MessageBox.Show("good");
        //            }

        //            //do something  
        //        }








        //    }
        //    finally
        //    {
        //        if (Program.sql_con != null)
        //        {
        //            Program.sql_con.Close();
        //        }
        //        if (Program.db != null)
        //        {
        //            Program.db.Close();
        //        }
        //    }
        //    select_Overt_Data();

        //}

        //public void RunStoredProc_duree_order_service()
        //{



        //    try
        //    {
        //        for (int i = 0; i < gridViewOvert.DataRowCount; i++)
        //        {
        //            if (int.Parse(gridViewOvert.GetRowCellValue(i, "duree_order_service").ToString()) < 100)
        //            {

        //                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
        //                SqlCommand cmd = new SqlCommand("dbo._order_service", Program.sql_con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@id", int.Parse(gridViewOvert.GetRowCellValue(i, "id3").ToString()));

        //                cmd.ExecuteNonQuery();
                       
        //            }

        //            //do something  
        //        }








        //    }
        //    finally
        //    {
        //        if (Program.sql_con != null)
        //        {
        //            Program.sql_con.Close();
        //        }
        //        if (Program.db != null)
        //        {
        //            Program.db.Close();
        //        }
        //    }
        //    select_Overt_Data();

        //}


        private void barButtonPublication_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            run();
            publication fm = new publication();

            fm.ShowDialog();

            select_Publication_Data();

        }

        private void officeNavigationBar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("ff");
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
                    popupMenuapprob.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                else
                    popupMenuapprob.HidePopup();
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
            run();
            overt ov = new overt();
            ov.ShowDialog();
            select_Overt_Data();


        }

        private void barButtonItem_modifier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //modification 


            var row2 = gridViewOvert.FocusedRowHandle;
            int id3;
            string cellattributaire;
            string cellMontant;
            string cellnum_Marcher;
            int celldélai_dexecution;
            string cellcaution_return;
            string cellcaution_definitif;
            DateTime celldate_Visa;
            DateTime celldate_approbation;
            DateTime celldatenotifiy;
            DateTime delldate_caution;

            int cell_validate;


            id3 = int.Parse(gridViewOvert.GetRowCellValue(row2, "id3").ToString());
            cellattributaire = gridViewOvert.GetRowCellValue(row2, "attributaire").ToString();
            cellMontant = gridViewOvert.GetRowCellValue(row2, "Montant").ToString();
            cellnum_Marcher = gridViewOvert.GetRowCellValue(row2, "num_Marcher").ToString();
            celldélai_dexecution = int.Parse(gridViewOvert.GetRowCellValue(row2, "délai_dexecution").ToString());
            cellcaution_return = (gridViewOvert.GetRowCellValue(row2, "caution_return").ToString());
            cellcaution_definitif = (gridViewOvert.GetRowCellValue(row2, "caution_definitif").ToString());
            celldate_Visa = Convert.ToDateTime(gridViewOvert.GetRowCellValue(row2, "date_Visa").ToString());
            celldate_approbation = Convert.ToDateTime(gridViewOvert.GetRowCellValue(row2, "date_approbation").ToString());
            celldatenotifiy = Convert.ToDateTime(gridViewOvert.GetRowCellValue(row2, "datenotifiy").ToString());
            delldate_caution = Convert.ToDateTime(gridViewOvert.GetRowCellValue(row2, "date_caution").ToString());

            overt ovs = new overt(id3, cellattributaire, cellMontant, cellnum_Marcher, celldélai_dexecution, cellcaution_return, cellcaution_definitif, celldate_Visa, celldate_approbation, celldatenotifiy, delldate_caution);
            ovs.ShowDialog();
            select_Overt_Data();
        }

        private void barButtonItem_approbation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //valide approbation  change date approbation

            var row2 = gridViewOvert.FocusedRowHandle;
            string cellid;
            DateTime date_approbation =  Convert.ToDateTime(gridViewOvert.GetRowCellValue(row2, "date_approbation").ToString());
            cellid = gridViewOvert.GetRowCellValue(row2, "id3").ToString();

            Valide_approbation valide_ = new  Valide_approbation(int.Parse(cellid), date_approbation);
            valide_.ShowDialog();
            select_Overt_Data();


            //if (MessageBox.Show("Voulez-vous vraiment validate cette approbation   ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    try
            //    {


            //        using (SqlCommand deleteCommand = new SqlCommand("update SIMPLE_overture set valide_approbation = 1 WHERE id3 = @id", Program.sql_con))
            //        {


            //            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

            //            deleteCommand.Parameters.AddWithValue("@id", int.Parse(cellid));

            //            deleteCommand.ExecuteNonQuery();



            //        }
            //        select_Overt_Data();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    finally
            //    {
            //        //this.Dispose();
            //    }

           // }
        }

        private void barButtonItem_confirmer_caution_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridViewOvert.FocusedRowHandle ;
            string cellid ;
            cellid = gridViewOvert.GetRowCellValue(row2, "id3").ToString();
            DateTime date_caution = Convert.ToDateTime(gridViewOvert.GetRowCellValue(row2, "date_caution").ToString());
            valide_caution valide_ = new valide_caution( int.Parse(cellid), date_caution);
            valide_.ShowDialog();
            select_Overt_Data();



        }

        private void barButtonItem_order_service_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridViewOvert.FocusedRowHandle;
            int cellid_Overture;
            int celldélai_dexecution;
            cellid_Overture = int.Parse(gridViewOvert.GetRowCellValue(row2, "id3").ToString());
            celldélai_dexecution = int.Parse(gridViewOvert.GetRowCellValue(row2, "délai_dexecution").ToString());


            openOrderService openOrder = new openOrderService(cellid_Overture, celldélai_dexecution);
            openOrder.ShowDialog();
             select_Overt_Data();


           
        }

        private void barButtonItem_suivi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row2 = gridViewOvert.FocusedRowHandle;
            int cellid_Overture;
            cellid_Overture = int.Parse(gridViewOvert.GetRowCellValue(row2, "id3").ToString());


            suivi_des_order opensuivi = new suivi_des_order(cellid_Overture);
            opensuivi.ShowDialog();
            select_Overt_Data();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RunStoredProc_duree_portail();
            valide_sms();

        }
                private string[] lines;
                private int index = 0;
                    string ss = "";

        static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        public void valide_sms()
        {
            if (File.Exists(filePath + " / FILE_SMS.txt"))  // If file does not exists
            {

                lines = lines ?? File.ReadAllLines(filePath + " / FILE_SMS.txt");

                // sanity check 
                if (index < lines.Length)
                    ss = lines[index++]; // index++ increments after use



                //MessageBox.Show(ss);
                label1.Visible = true;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

           



            if (e.Control && e.Alt && e.KeyCode == Keys.F10)//here you can choose any key you want
            {

                if (MessageBox.Show("Create Admin  ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        if (!File.Exists(filePath + " / FILE_SMS.txt")) // If file does not exists
                        {
                            File.Create(filePath + " / FILE_SMS.txt").Close(); // Create file
                            using (StreamWriter sw = File.AppendText(filePath + " / FILE_SMS.txt"))
                            {
                                sw.WriteLine("911"); // Write text to .txt file
                                MessageBox.Show("Create success");
                            }
                            File.SetAttributes(
                             filePath + " / FILE_SMS.txt",
                             FileAttributes.Hidden |
                             FileAttributes.ReadOnly
                             );
                            label1.Visible = true;

                        }
                        else // If file already exists
                        {




                            MessageBox.Show("elredy_exist");



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


            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                notifyIcon1.BalloonTipText = "votre application a été réduite dans la barre d'état système";
                notifyIcon1.ShowBalloonTip(1000);
                notifyIcon1.Visible = true;


            }
        }

        private void barButtonItem_print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            run();
            report rp = new report();
            rp.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            run();
            situation st = new situation();
            st.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            calendrier cd = new calendrier();
            cd.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            select_Etude_Data();
            select_Publication_Data();
            select_Overt_Data();

            if (label1.Visible == true)
            {
               

            RunStoredProc_duree_portail();
            //RunStoredProc_Approbation();
            


            }
        }
    }
}