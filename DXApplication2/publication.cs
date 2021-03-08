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

namespace DXApplication2
{
    public partial class publication : DevExpress.XtraEditors.XtraForm
    {
        public publication()
        {
            InitializeComponent();
        }

        private void layoutControlItem4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textEditJornal_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
            DateTime dt = (DateTime)textEditJornal.EditValue ;
            dt = dt.AddDays(23);
            dateEditop.EditValue = dt ;





            textEditportai.EditValue = textEditJornal.EditValue;


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

        private void publication_Load(object sender, EventArgs e)
        {
           


            this.dateEditop.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEditop.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditop.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEditop.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;


            this.textEditJornal.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.textEditJornal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEditJornal.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.textEditJornal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;


            this.textEditconvocation.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.textEditconvocation.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEditconvocation.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.textEditconvocation.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;


            this.textEditportai.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.textEditportai.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textEditportai.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.textEditportai.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

        }

        private void textEditconvocation_EditValueChanged(object sender, EventArgs e)
        {

           

        }

        private void dateEditop_EditValueChanged(object sender, EventArgs e)
        {
            DateTime dt = (DateTime)dateEditop.EditValue;
            dt = dt.AddDays(-8);
            textEditconvocation.EditValue = dt;
        }
    }
}