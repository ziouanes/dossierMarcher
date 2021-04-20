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
        public void Printreport(int id_Reaparation, List<class_reportData> descriptions)
        {
            ReportEtat report = new ReportEtat();

            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;
            using (Program.sql_con)

            {
                if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();
                SqlCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select r.[n/],r.[nom] , r.[Carburant]  ,v.[Marque] ,v.[matricule]   , r.[first_kilometrage] , r.[_date]  ,r.[datenow] as datenow from [Reaparation] r inner join [vehicules] v on r.vehecule  =v.id  where r.id = " + id_Reaparation + "";
                DataTable table = new DataTable();
                cmd.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                foreach (DataRow row in table.Rows)
                {

                    string n_marche, string objet, string apo,string Attribute, int delai_jour, string montant, DateTime date_op, DateTime dateportail, List< class_reportData > description)
                    report.InitData(row["n/"].ToString(), row["nom"].ToString(), row["Carburant"].ToString(), row["Marque"].ToString(), row["matricule"].ToString(), row["first_kilometrage"].ToString(), row["_date"].ToString(), row["datenow"].ToString(), descriptions);
                    documentViewer1.DocumentSource = report;
                    report.CreateDocument();

                }


            }
        }
    }
}