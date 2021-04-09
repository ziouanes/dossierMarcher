using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2
{
    public partial class report : DevExpress.XtraEditors.XtraForm
    {
        public report()
        {
            InitializeComponent();
        }

        private void select_Publication_Data()
        {
            try
            {
                label_objet.Text ="";
                labelAop.Text = "";
                labeln_marche.Text = "";
                stepProgressBar1.SelectedItemIndex = -1;

                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id2 , Aop , date_jornal , date_portail , date_convocation , validate  , duree_portail , duree_Jornal  , date_op  from publication where deleted = 0  order by id2 desc ; ";
                classpublicationBindingSource.DataSource = Program.sql_con.Query<Class_publication>(query, commandType: CommandType.Text);


                lookUpEdit2.Properties.PopulateColumns();
                lookUpEdit2.Properties.Columns[0].Visible = false;
                lookUpEdit2.Properties.Columns[2].Visible = false;
                lookUpEdit2.Properties.Columns[3].Visible = false;
                lookUpEdit2.Properties.Columns[4].Visible = false;
                lookUpEdit2.Properties.Columns[5].Visible = false;
                lookUpEdit2.Properties.Columns[6].Visible = false;
                lookUpEdit2.Properties.Columns[7].Visible = false;
                lookUpEdit2.Properties.Columns[8].Visible = false;


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
                label_objet.Text = "";
                labelAop.Text = "";
                labeln_marche.Text = "";
                stepProgressBar1.SelectedItemIndex = -1;
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id1 , objet , estimation , montant , envoyer_tresoryer , validate  , délai_dexecution   from etude where deleted = 0   order by id1 desc ; ";
                classEtudeBindingSource.DataSource = Program.sql_con.Query<ClassEtude>(query, commandType: CommandType.Text);



                lookUpEdit1.Properties.PopulateColumns();
                lookUpEdit1.Properties.Columns[0].Visible = false;
                lookUpEdit1.Properties.Columns[2].Visible = false;
                lookUpEdit1.Properties.Columns[3].Visible = false;
                lookUpEdit1.Properties.Columns[4].Visible = false;
                lookUpEdit1.Properties.Columns[5].Visible = false;
                lookUpEdit1.Properties.Columns[6].Visible = false;
                lookUpEdit1.Properties.Columns[7].Visible = false;
                lookUpEdit1.Properties.Columns[8].Visible = false;



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

                label_objet.Text = "";
                labelAop.Text = "";
                labeln_marche.Text = "";
                stepProgressBar1.SelectedItemIndex = -1;
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id3 , attributaire , Montant , num_Marcher , date_Visa  , date_approbation  , valide_approbation  , duree_approbation , délai_dexecution  , caution_definitif , caution_return , datenotifiy , date_caution , valide_caution , duree_caution  , valide_order_service  , duree_order_service from SIMPLE_overture order by id3 desc";
                classSIMPLEovertureBindingSource.DataSource = Program.sql_con.Query<ClassSIMPLE_overture>(query, commandType: CommandType.Text);


                lookUpEdit3.Properties.PopulateColumns();
                lookUpEdit3.Properties.Columns[0].Visible = false;
                lookUpEdit3.Properties.Columns[2].Visible = false;
                lookUpEdit3.Properties.Columns[1].Visible = false;
                lookUpEdit3.Properties.Columns[4].Visible = false;
                lookUpEdit3.Properties.Columns[5].Visible = false;
                lookUpEdit3.Properties.Columns[6].Visible = false;
                lookUpEdit3.Properties.Columns[7].Visible = false;
                lookUpEdit3.Properties.Columns[8].Visible = false;
                lookUpEdit3.Properties.Columns[9].Visible = false;
                lookUpEdit3.Properties.Columns[10].Visible = false;
                lookUpEdit3.Properties.Columns[11].Visible = false;
                lookUpEdit3.Properties.Columns[12].Visible = false;
                lookUpEdit3.Properties.Columns[13].Visible = false;
                lookUpEdit3.Properties.Columns[14].Visible = false;
                lookUpEdit3.Properties.Columns[15].Visible = false;
                lookUpEdit3.Properties.Columns[16].Visible = false;










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


        private void report_Load(object sender, EventArgs e)
        {
            select_Etude_Data();
            select_Overt_Data();
            select_Publication_Data();

            lookUpEdit1.Properties.Buttons[1].Click += Worksetude;
            lookUpEdit2.Properties.Buttons[1].Click += Workspub;
            lookUpEdit3.Properties.Buttons[1].Click += Worksovert;

    



        }

        private void Worksetude(object sender, EventArgs e)
        {
            select_Etude_Data();
            select_Overt_Data();
            select_Publication_Data();
        }

        private void Workspub(object sender, EventArgs e)
        {
            select_Etude_Data();
            select_Overt_Data();
            select_Publication_Data();
        }

        private void Worksovert(object sender, EventArgs e)
        {
            select_Etude_Data();
            select_Overt_Data();
            select_Publication_Data();
        }

        private void stepProgressBar1_Click(object sender, EventArgs e)
        {

        }

        public void run()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormsplach), true, true, false);

            SplashScreenManager.Default.SetWaitFormCaption("en cours d'exécution");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(5);
            }
            SplashScreenManager.CloseForm();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            run();

            try
            {

                if(lookUpEdit1.EditValue != null && lookUpEdit2.EditValue == null && lookUpEdit3.EditValue == null)
                {
                    //etude
                    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                    {
                        SqlCommand cmd = Program.sql_con.CreateCommand();
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = $" select  [id1] , [validate] from etude where id1  = {lookUpEdit1.EditValue.ToString()} ";

                        DataTable table = new DataTable();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            if (int.Parse(row["validate"].ToString()) == 0)
                            {
                                stepProgressBar1.SelectedItemIndex = 0;
                            }
                        else if (int.Parse(row["validate"].ToString()) == 1)
                        {
                            stepProgressBar1.SelectedItemIndex = 1;

                        }



                    }

                    }

                }


                //pub

                else if(lookUpEdit1.EditValue != null && lookUpEdit2.EditValue != null && lookUpEdit3.EditValue == null)
                {
                    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                    {
                        SqlCommand cmd = Program.sql_con.CreateCommand();
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = $" select p.id2 , p.validate  from publication p inner join fk f on f.id2 = p.id2 inner join etude e on e.id1 = f.id1  where p.id2 = {lookUpEdit2.EditValue.ToString()} ";

                        DataTable table = new DataTable();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            if (int.Parse(row["validate"].ToString()) == 1)
                            {
                                stepProgressBar1.SelectedItemIndex = 2;

                            }
                           



                        }

                    }

                }

                //
                else if (lookUpEdit1.EditValue != null && lookUpEdit2.EditValue != null && lookUpEdit3.EditValue != null)
                {
                    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                    {
                        SqlCommand cmd = Program.sql_con.CreateCommand();
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = $" select  e.validate as 'etude_V'  ,   p.validate as 'public_V'   ,  o.etat ,  s.valide_approbation , s.valide_caution , s.valide_order_service  ,    s.num_Marcher ,   e.id1 , e.objet from etude e inner join fk k on e.id1 = k.id1 inner join publication p on p.id2 = k.id2 inner join fk2 pk on pk.id2 =  p.id2 inner join SIMPLE_overture s on s.id3 = pk.id3 inner join order_service o on o.id_order = s.id3  where s.id3 = {lookUpEdit2.EditValue.ToString()} ";

                        DataTable table = new DataTable();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            if (int.Parse(row["etat"].ToString()) == 3)
                            {
                                stepProgressBar1.SelectedItemIndex = 7;
                            }
                            else if (int.Parse(row["etat"].ToString()) == 2)
                            {
                                stepProgressBar1.SelectedItemIndex = 6;
                            }
                            else if (int.Parse(row["etat"].ToString()) == 1 || int.Parse(row["etat"].ToString()) == 0)
                            {
                                stepProgressBar1.SelectedItemIndex = 5;
                            }
                            else if (int.Parse(row["etat"].ToString()) == -1 )
                            {
                                if(int.Parse(row["valide_order_service"].ToString()) == 1)
                                {
                                    stepProgressBar1.SelectedItemIndex = 5;

                                }
                                else if(int.Parse(row["valide_caution"].ToString()) == 1)
                                {
                                    stepProgressBar1.SelectedItemIndex = 4;

                                }
                                else if (int.Parse(row["valide_approbation"].ToString()) == 1)
                                {
                                    stepProgressBar1.SelectedItemIndex = 3;

                                }


                            }


                        }

                    }
                }


                    
                label_objet.Text = "objet :  " + lookUpEdit1.Text;
                labelAop.Text = "référence ° " + lookUpEdit2.Text;
                labeln_marche.Text = "n° marchée :" + lookUpEdit3.Text;
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

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select p.id2 , p.Aop  from publication p inner join fk f on f.id2 = p.id2 inner join etude e on e.id1 = f.id1 where  e.id1 ={lookUpEdit1.EditValue.ToString()}     ; ";
                classpublicationBindingSource.DataSource = Program.sql_con.Query<Class_publication>(query, commandType: CommandType.Text);


                string query2 = $"select s.id3 , s.num_Marcher  from publication p inner join fk f on f.id2 = p.id2 inner join etude e on e.id1 = f.id1 inner join fk2 k2 on k2.id2 = p.id2 inner join SIMPLE_overture s on s.id3 = k2.id3  where  e.id1 = {lookUpEdit1.EditValue.ToString()}     ; ";
                classSIMPLEovertureBindingSource.DataSource = Program.sql_con.Query<ClassSIMPLE_overture>(query2, commandType: CommandType.Text);




                lookUpEdit2.ItemIndex = 0;
                lookUpEdit3.ItemIndex = 0;

               


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

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}