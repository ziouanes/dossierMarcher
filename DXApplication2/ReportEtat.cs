using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace DXApplication2
{
    public partial class ReportEtat : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportEtat()
        {
            InitializeComponent();
        }

        public void InitData(string n_marche, string objet, string apo,string Attribute , int delai_jour, string montant, DateTime date_op, DateTime dateportail, string estimation ,string etat,DateTime date_effet,string délai_restant, DateTime date_convocation , DateTime date_jornal , string caution_definitif  , string caution_return , DateTime date_approbation , DateTime date_caution ,DateTime date_Visa, DateTime datenotifiy ,  List<class_reportData> reportdata)
        {
            Parameters["param_n_marche"].Value = n_marche;
            Parameters["param_objet"].Value = objet;
            Parameters["param_apo"].Value = apo;
            Parameters["param_Attribute"].Value = Attribute;
            Parameters["param_delai_jour"].Value = delai_jour;
            Parameters["param_montant"].Value = montant;
            Parameters["param_date_op"].Value = date_op;
            Parameters["param_dateportail"].Value = dateportail;
            Parameters["param_estimation"].Value = estimation;
            Parameters["param_date_convocation"].Value = date_convocation;
            Parameters["param_date_jornal"].Value = date_jornal;
            Parameters["param_caution_definitif"].Value = caution_definitif;
            Parameters["param_caution_return"].Value = caution_return;
            Parameters["param_date_approbation"].Value = date_approbation;
            Parameters["param_date_caution"].Value = date_caution;
            Parameters["param_date_Visa"].Value = date_Visa;
            Parameters["param_datenotifiy"].Value = datenotifiy;



            if (etat == "-1")
            {
                Parameters["param_etat"].Value = "order de commencement";
            }
            else if (etat == "0")
            {
                Parameters["param_etat"].Value = "order d'arrêt";
            }
            else if (etat == "1")
            {

                Parameters["param_etat"].Value = "order de reprise";


            }
            else if (etat == "2")
            {
                Parameters["param_etat"].Value = "réception provisoire";

            }
            else if (etat == "3")
            {
                Parameters["param_etat"].Value = "réception définitive";
            }

           // Parameters["param_etat"].Value = etat;
            Parameters["param_date_effet"].Value = date_effet;

            Parameters["param_délai_restant"].Value = délai_restant;

            objectDataSource1.DataSource = reportdata;

        }

    }
}
