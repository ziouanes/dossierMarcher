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
    public partial class valide_caution : DevExpress.XtraEditors.XtraForm
    {

        int _order_service;
        DateTime dt;


        public valide_caution(int order_service, DateTime date_caution)
        {
            dt = date_caution;
            _order_service = order_service;
            InitializeComponent();
        }

        private void valide_caution_Load(object sender, EventArgs e)
        {
            this.dateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            dateEdit1.DateTime = dt ;

        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Voulez-vous vraiment validate cette caution   ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    using (SqlCommand deleteCommand = new SqlCommand("update SIMPLE_overture set valide_caution = 1 , date_caution = @dt_caution  WHERE id3 = @id", Program.sql_con))
                    {


                        if (Program.sql_con.State == ConnectionState.Closed) Program.sql_con.Open();

                        deleteCommand.Parameters.AddWithValue("@dt_caution", dateEdit1.Text);


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