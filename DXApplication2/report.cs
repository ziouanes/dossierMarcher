using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select id2 , Aop , date_jornal , date_portail , date_convocation , validate  , duree_portail , duree_Jornal  , date_op  from publication where deleted = 0  order by id2 desc ; ";
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


        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

            MessageBox.Show(lookUpEdit1.EditValue.ToString());
            try
            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();





                string query = $"select p.id2 , p.Aop  from publication p inner join fk f on f.id2 = p.id2 inner join etude e on e.id1 = f.id1 where  e.id1 ={lookUpEdit1.EditValue.ToString()}    order by p.id2 desc  ; ";
                classpublicationBindingSource.DataSource = Program.sql_con.Query<Class_publication>(query, commandType: CommandType.Text);

                lookUpEdit2.ItemIndex = 0;

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