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
    public partial class form_report : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public form_report()
        {
            InitializeComponent();
        }

        private void form_report_Load(object sender, EventArgs e)
        {

        }
        public void Printreport(int id_etude, List<class_reportData> reportData)
        {
            ReportEtat report = new ReportEtat();

            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;
            
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                SqlCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP 1 e.id1 , p.Aop , o.délai_restant , s.attributaire , e.estimation , o.délai_Initial , e.montant , p.date_op , p.date_portail , o.Etat  ,s.num_Marcher , e.objet  from etude e  full outer join fk f on e.id1 = f.id1  full outer join publication p on p.id2 = f.id2  full outer join fk2 ff on p.id2 = ff.id2 full outer join	SIMPLE_overture s on s.id3 = ff.id3	full outer join order_service o on s.id3 = o.id_Overture full outer join Etat_order et on o.id_order = et.order_service  where e.id1 =  " + id_etude + " and et.etat_objet = -1  order by et.date_deffet desc";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                foreach (DataRow row in table.Rows)
                {

                    report.InitData(row["num_Marcher"].ToString(), row["objet"].ToString(), row["Aop"].ToString(), row["attributaire"].ToString(), int.Parse(row["délai_Initial"].ToString()), row["montant"].ToString(), Convert.ToDateTime(row["date_op"].ToString()), Convert.ToDateTime(row["date_portail"].ToString()), row["estimation"].ToString() , row["Etat"].ToString()  , Convert.ToDateTime(row["date_deffet"].ToString()), row["délai_restant"].ToString() ,   reportData);
                    documentViewer1.DocumentSource = report;
                    report.CreateDocument();

                }


            
        }
    }
}