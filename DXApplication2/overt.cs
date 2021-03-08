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
    public partial class overt : DevExpress.XtraEditors.XtraForm
    {
        public overt()
        {
            InitializeComponent();
        }

        private void Montant_EditValueChanged(object sender, EventArgs e)
        {
            if(Montant.Text != "")
            {
                


                float montant = float.Parse(Montant.Text);
                var roundedA = Math.Ceiling(((montant * 3) / 100) + .00); // Output: 1

                textEditdefinitif.Text = roundedA.ToString();
            caution_return.Text = ((montant * 7) / 100).ToString();

            }
            else
            {
                textEditdefinitif.Text = "";
                caution_return.Text = "";
            }

           
        }

        private void Montant_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void overt_Load(object sender, EventArgs e)
        {
            Montant.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Montant.Properties.Mask.EditMask = "n2";
            Montant.Properties.Mask.UseMaskAsDisplayFormat = true;

            textEditdefinitif.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            textEditdefinitif.Properties.Mask.EditMask = "n0";
            textEditdefinitif.Properties.Mask.UseMaskAsDisplayFormat = true;

            var roundedA = Math.Ceiling(1+.00); // Output: 1
            
            textEdit3.Text = roundedA.ToString();
        }
    }
}