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
using DevExpress.XtraSplashScreen;
using System.Threading;

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
            
            
        }

        private void BindingDataSource()
        {
            run();

            Workbook = spreadsheetControl1.Document;
            Workbook.LoadDocument(@"Document\situation.xlsx", DocumentFormat.Xlsx);

            IWorkbook workbook = spreadsheetControl1.Document;
            
            Worksheet worksheet = Workbook.Worksheets[0];

            workbook.BeginUpdate();
            try
            {
               
                ExternalDataSourceOptions options = new ExternalDataSourceOptions() { ImportHeaders = true };


                worksheet.DataBindings.Clear();
                worksheet.Columns.ClearOutline();
                
                

                //worksheet.DataBindings.BindTableToDataSource(null);
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

        //private void selectData()
        //{
        //    if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

            
        //        SqlCommand cmd = Program.sql_con.CreateCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = $"select p.Aop as 'N°AOP' ,CAST(e.fdr as varchar(10)) as 'FDR'  , e.délai_dexecution , s.num_Marcher as 'N°MARCHE'  , l.localite as 'Localité des Tran' ,e.objet, p.date_op as 'Date ouverture des Plis' , e.estimation as 'Estimation' , s.attributaire as 'ATTRIBUTAIRE' , e.montant as 'MONTANT' , CAST(o.Etat as varchar(20)) as 'Etat'   from localite l FULL OUTER JOIN  etude e on l.id_l = e.localite inner join fk k on e.id1 = k.id1 FULL OUTER JOIN publication p on p.id2 = k.id2 FULL OUTER JOIN fk2 pk on pk.id2 =  p.id2 FULL OUTER JOIN SIMPLE_overture s on s.id3 = pk.id3 FULL OUTER JOIN order_service o on o.id_order = s.id3  where 1=1";


        //        DataTable dt1 = new DataTable();


        //        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        //        da1.Fill(dt1);




        //        foreach (DataRow row in dt1.Rows)
        //        {
        //            //do what you need to calculate myNewValue here
        //            if (row["Etat"].ToString() == "-1")
        //            {

        //                row["Etat"] = "order de commencement";
        //            }
        //           else if (row["Etat"].ToString() == "0"){

        //            row["Etat"] = "order d'arrêt";
        //            }
        //            else if (row["Etat"].ToString() == "1")
        //            {

        //                row["Etat"] = "order de reprise";
        //            }
        //            else if (row["Etat"].ToString() == "2")
        //            {

        //                row["Etat"] = "réception provisoire";
        //            }
        //            else if (row["Etat"].ToString() == "3")
        //            {

        //                row["Etat"] = "réception définitive";
        //            }

        //            if (row["FDR"].ToString() == "0")
        //            {

        //                row["FDR"] = "Non";
        //            }
        //            else
        //            {
        //                row["FDR"] = "Oui";
        //            }


        //        }
        //        //gridControl1.DataSource = dt1;

        //        DataSet ds = new DataSet("tab");
        //        ds.Tables.Add(dt1);

        //        dataView = new DataView(ds.Tables[0]);
            
        //}

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

        public void GetTable_LOCALITE()
        {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("localite", typeof(string));



            table.Rows.Add(1, "Marrakech");
            table.Rows.Add(2, "Chichaoua");
            table.Rows.Add(3, "Al Haouz");
            table.Rows.Add(4, "El Kelâa des Sraghna");
            table.Rows.Add(5, "Essaouira");
            table.Rows.Add(6, "Rehamna");
            table.Rows.Add(7, "Safi");
            table.Rows.Add(8, "Youssoufia");

            DISTINATION.Properties.DataSource = table;
            DISTINATION.Properties.DisplayMember = "localite";
            DISTINATION.Properties.ValueMember = "id";

            DISTINATION.Properties.PopulateColumns();

            DISTINATION.Properties.Columns[DISTINATION.Properties.ValueMember].Visible = false;
        }

            public void GetTable_ETAT()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("id", typeof(int));
            table1.Columns.Add("Etat", typeof(string));


            table1.Rows.Add(-1,"order de commencement");
            table1.Rows.Add(0, "order d'arrêt");
            table1.Rows.Add(1, "order de reprise");
            table1.Rows.Add(2, "réception provisoire");
            table1.Rows.Add(3, "réception définitive");

            edProductName.Properties.DataSource = table1;
            edProductName.Properties.DisplayMember = "Etat";
            edProductName.Properties.ValueMember = "id";

            edProductName.Properties.PopulateColumns();

            edProductName.Properties.Columns[edProductName.Properties.ValueMember].Visible = false;

            }




        private void situation_Load(object sender, EventArgs e)
        {
            GetTable_LOCALITE();
            GetTable_ETAT();


            this.mask.Properties.DisplayFormat.FormatString = "yyyy";
            this.mask.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.mask.Properties.EditFormat.FormatString = "yyyy";
            this.mask.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;



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

        private void simpleButtoncherch_Click(object sender, EventArgs e)
        {



            string req = "", req1 = "", req2 = "", req3 = "" , req4 ="";

            req = "select p.Aop as 'N°AOP' ,CAST(e.fdr as varchar(10)) as 'FDR'  , e.délai_dexecution , s.num_Marcher as 'N°MARCHE'  , l.localite as 'Localité des Tran' ,e.objet, p.date_op as 'Date ouverture des Plis' , e.estimation as 'Estimation'  , e.montant as 'Caution Provisoire' , s.attributaire as 'ATTRIBUTAIRE',s.Montant as 'Montant DU Marche', o.date_orderService as 'Date order Service' ,  CAST(o.Etat as varchar(20)) as 'Etat de Marche' , et.date_deffet as  [Date d'effet]   from localite l FULL OUTER JOIN  etude e on l.id_l = e.localite inner join fk k on e.id1 = k.id1 FULL OUTER JOIN publication p on p.id2 = k.id2 FULL OUTER JOIN fk2 pk on pk.id2 =  p.id2 FULL OUTER JOIN SIMPLE_overture s on s.id3 = pk.id3 FULL OUTER JOIN order_service o on o.id_order = s.id3 full outer join Etat_order et on o.id_order = et.order_service  where 1=1 ";


            if (mask.Text !="")
            {
                
                    req1 = "and YEAR( p.date_op)  = '"+ mask.Text +"' ";


             }
              

            

            if (edProductName.ItemIndex != -1)
            {
               
                    req2 = "and   o.Etat =  '" + edProductName.EditValue.ToString() + "'";


                

            }

            if (DISTINATION.ItemIndex != -1)
            {
                
                    req3 = "  and l.localite =  '" + DISTINATION.EditValue.ToString() + "'";


               

            }
            if(checkEdit_fdr.Checked == true)
            {
                req4 = "and e.fdr   = 1";
            }
            

            req += req1 + req2 + req3 +req4 + "order by p.date_op desc , et.date_deffet desc";


               if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();


            SqlCommand cmd = Program.sql_con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = req;


            
                DataTable dt1 = new DataTable();
                


                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                da1.Fill(dt1);




                foreach (DataRow row in dt1.Rows)
                {
                    //do what you need to calculate myNewValue here
                    if (row["Etat de Marche"].ToString() == "-1")
                    {

                        row["Etat de Marche"] = "order de commencement";
                    }
                    else if (row["Etat de Marche"].ToString() == "0")
                    {

                        row["Etat de Marche"] = "order d'arrêt";
                    }
                    else if (row["Etat de Marche"].ToString() == "1")
                    {

                        row["Etat de Marche"] = "order de reprise";
                    }
                    else if (row["Etat de Marche"].ToString() == "2")
                    {

                        row["Etat de Marche"] = "réception provisoire";
                    }
                    else if (row["Etat de Marche"].ToString() == "3")
                    {

                        row["Etat de Marche"] = "réception définitive";
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
            ds.Clear();
                ds.Tables.Add(dt1);

                dataView = new DataView(ds.Tables[0]);

            //if (dataView.Table.Rows.Count > 0)
            //{
            //dataView.Table.Rows.Clear();

            //}




            
           

            Program.sql_con.Close();



            BindingDataSource();

            mask.Text = ""; edProductName.ItemIndex = -1; DISTINATION.ItemIndex = -1; checkEdit_fdr.Checked = false;

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            run();

            Workbook = spreadsheetControl1.Document;
            Workbook.LoadDocument(@"Document\situation.xlsx", DocumentFormat.Xlsx);


            mask.Text = ""; edProductName.EditValue = -2; DISTINATION.ItemIndex = -1; checkEdit_fdr.Checked = false; 

        }
    }
}