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

        public void InitData(string n_marche, string objet, string apo,string Attribute , int delai_jour, string montant, DateTime date_op, DateTime dateportail, string estimation ,string etat,DateTime date_effet,string délai_restant,  List<class_reportData> reportdata)
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
