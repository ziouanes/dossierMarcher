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
            using (Program.sql_con)

            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                SqlCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select top 1  p.Aop , o.délai_restant, s.attributaire , e.estimation  , o.délai_Initial  , e.montant , p.date_op , p.date_portail  ,  o.etat  ,    s.num_Marcher ,   e.id1 , e.objet , et.date_deffet from etude e FULL OUTER JOIN fk k on e.id1 = k.id1 FULL OUTER JOIN publication p on p.id2 = k.id2 FULL OUTER JOIN fk2 pk on pk.id2 =  p.id2 FULL OUTER JOIN SIMPLE_overture s on s.id3 = pk.id3 FULL OUTER JOIN order_service o on o.id_order = s.id3 FULL OUTER JOIN Etat_order et on o.id_order = et.order_service   where e.id1 = " + id_etude + " and et.etat_objet = 1  order by et.date_deffet desc";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                foreach (DataRow row in table.Rows)
                {

                    report.InitData(row["num_Marcher"].ToString(), row["objet"].ToString(), row["Aop"].ToString(), row["attributaire"].ToString(), int.Parse(row["délai_Initial"].ToString()), row["montant"].ToString(), Convert.ToDateTime(row["date_op"].ToString()), Convert.ToDateTime(row["date_portail"].ToString()), row["estimation"].ToString() , row["etat"].ToString()  , Convert.ToDateTime(row["date_deffet"].ToString()), row["délai_restant"].ToString() ,   reportData);
                    documentViewer1.DocumentSource = report;
                    report.CreateDocument();

                }


            }
        }
    }
}