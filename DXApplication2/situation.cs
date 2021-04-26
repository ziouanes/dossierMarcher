using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Worksheet = DevExpress.Spreadsheet.Worksheet;
using System.Data;
using Worksheet = DevExpress.Spreadsheet.Worksheet;
using System.Data.SqlClient;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using Table = DevExpress.ClipboardSource.SpreadsheetML.Table;

namespace DXApplication2
{
    public partial class situation : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        IWorkbook Workbook;
        DataView dataView;

        public situation()
        {
            InitializeComponent();

            Workbook = spreadsheetControl1.Document;
            Workbook.LoadDocument(@"Document\situation.xlsx", DocumentFormat.Xlsx);

            //CreateDataSourse();
            selectData();
            BindingDataSource();
        }

        private void BindingDataSource()
        {
            IWorkbook workbook = spreadsheetControl1.Document;

            Worksheet worksheet = Workbook.Worksheets[0];
            workbook.BeginUpdate();
            try
            {

                ExternalDataSourceOptions options = new ExternalDataSourceOptions() { ImportHeaders = true };



                worksheet.DataBindings.BindTableToDataSource(dataView, 4, 1,options);

                worksheet.Cells.AutoFitColumns();
                worksheet.Cells.AutoFitRows();
                worksheet.Cells.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                worksheet.Cells.Style.Alignment.Vertical = SpreadsheetVerticalAlignment.Top;
                worksheet.ActiveView.Zoom = 80;

                
                
                //worksheet.RowColumnHeadersVisible = false;
                
            }
            finally
            {
                workbook.EndUpdate();
            }
        }

        private void selectData()
        {
            if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

            
                SqlCommand cmd = Program.sql_con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"select p.Aop as 'N°AOP' ,CAST(e.fdr as varchar(10)) as 'FDR'  , e.délai_dexecution , s.num_Marcher as 'N°MARCHE'  , l.localite as 'Localité des Tran' ,e.objet, p.date_op as 'Date ouverture des Plis' , e.estimation as 'Estimation' , s.attributaire as 'ATTRIBUTAIRE' , e.montant as 'MONTANT' , CAST(o.Etat as varchar(20)) as 'Etat'   from localite l FULL OUTER JOIN  etude e on l.id_l = e.localite inner join fk k on e.id1 = k.id1 FULL OUTER JOIN publication p on p.id2 = k.id2 FULL OUTER JOIN fk2 pk on pk.id2 =  p.id2 FULL OUTER JOIN SIMPLE_overture s on s.id3 = pk.id3 FULL OUTER JOIN order_service o on o.id_order = s.id3  where 1=1";


                DataTable dt1 = new DataTable();


                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                da1.Fill(dt1);




                foreach (DataRow row in dt1.Rows)
                {
                    //do what you need to calculate myNewValue here
                    if (row["Etat"].ToString() == "-1")
                    {

                        row["Etat"] = "order de commencement";
                    }
                   else if (row["Etat"].ToString() == "0"){

                    row["Etat"] = "order d'arrêt";
                    }
                    else if (row["Etat"].ToString() == "1")
                    {

                        row["Etat"] = "order de reprise";
                    }
                    else if (row["Etat"].ToString() == "2")
                    {

                        row["Etat"] = "réception provisoire";
                    }
                    else if (row["Etat"].ToString() == "3")
                    {

                        row["Etat"] = "réception définitive";
                    }

                    if (row["FDR"].ToString() == "0")
                    {

                        row["FDR"] = "Non";
                    }
                    else
                    {
                        row["FDR"] = "Oui";
                    }


                }
                //gridControl1.DataSource = dt1;

                DataSet ds = new DataSet("tab");
                ds.Tables.Add(dt1);

                dataView = new DataView(ds.Tables[0]);
            
        }

        private void CreateDataSourse()
        {
            Worksheet worksheet1 = spreadsheetControl1.Document.Worksheets[0];



            //DataTable sourceTable = new DataTable("Products");
            //sourceTable.Columns.Add("Product", typeof(string));
            //sourceTable.Columns.Add("Price", typeof(float));
            //sourceTable.Columns.Add("Quantity", typeof(Int32));
            //sourceTable.Columns.Add("Discount", typeof(float));

            //sourceTable.Rows.Add("Chocolade", 5, 15, 0.03);
            //sourceTable.Rows.Add("Konbu", 9, 55, 0.1);
            //sourceTable.Rows.Add("Geitost", 15, 70, 0.07);


            //DataSet ds = new DataSet("Products");



            //SqlDataAdapter da = new SqlDataAdapter();

            ////da.Fill(sourceTable);
            //ds.Tables.Add(sourceTable);

            //dataView = new DataView(ds.Tables[0]);



            ////////////////////:
            //dossierMarcherDataSet dataSet = new dossierMarcherDataSet();
            //dossierMarcherDataSetTableAdapters.etudeTableAdapter etudeTableAdapter = new dossierMarcherDataSetTableAdapters.etudeTableAdapter();
            //etudeTableAdapter.Fill(dataSet.etude);


            //dataSet.etude.Columns["objet"].SetOrdinal(1);
            ////dataSet.etude.Columns["objet"].SetOrdinal(2);
            ////dataSet.etude.Columns["objet"].SetOrdinal(3);

            //dataSet.etude.Columns["objet"].ReadOnly = true;

            //dataView = new DataView(dataSet.etude);
            //dataView.Sort = "objet";
            



        }









        private void ribbonControl1_Click(object sender, EventArgs e)
        {



        }
       


        

        private void situation_Load(object sender, EventArgs e)
        {
           



        }

        private void spreadsheetFormulaBar1_Load(object sender, EventArgs e)
        {

        }

        private void spreadsheetCommandBarCheckItem67_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}