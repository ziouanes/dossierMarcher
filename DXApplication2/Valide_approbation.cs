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
    public partial class Valide_approbation : DevExpress.XtraEditors.XtraForm
    {
        int _order_service;
        DateTime dt;

        public Valide_approbation(int order_service, DateTime date_approbation)
        {

            dt = date_approbation;

            _order_service = order_service;
            InitializeComponent();
            
        }

        private void Valide_approbation_Load(object sender, EventArgs e)
        {
            this.dateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            dateEdit1.EditValue = dt;

        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment validate cette approbation   ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    using (SqlCommand deleteCommand = new SqlCommand("update SIMPLE_overture set valide_approbation = 1  , date_approbation = @dt_approbation WHERE id3 = @id", Program.sql_con))
                    {


                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                        deleteCommand.Parameters.AddWithValue("@dt_approbation", dateEdit1.Text);


                        deleteCommand.Parameters.AddWithValue("@id", _order_service);

                        deleteCommand.ExecuteNonQuery();

                        this.Close();



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //this.Dispose();
                }

            }
        }
    }
}