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

        public void InitData(string n_marche, string objet, string apo,string Attribute, string intitile, int delai_jour, string montant, DateTime date_op, DateTime dateportail, List<class_reportData> description)
        {
            Parameters["param_n_marche"].Value = n_marche;
            Parameters["param_objet"].Value = objet;
            Parameters["param_apo"].Value = apo;
            Parameters["param_Attribute"].Value = Attribute;
            Parameters["param_intitile"].Value = intitile;
            Parameters["param_delai_jour"].Value = delai_jour;
            Parameters["param_montant"].Value = montant;
            Parameters["param_date_op"].Value = date_op;
            Parameters["param_dateportail"].Value = dateportail;

            reportDataSource1.DataSource = description;

        }

    }
}
