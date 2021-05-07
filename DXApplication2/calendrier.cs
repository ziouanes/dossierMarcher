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
    public partial class calendrier : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public calendrier()
        {
            InitializeComponent();
        }

        private void calendrier_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dossierMarcherDataSet.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.dossierMarcherDataSet.Resources);
            // TODO: This line of code loads data into the 'dossierMarcherDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.dossierMarcherDataSet.Appointments);

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {


        }

        private void schedulerDataStorage1_AppointmentsChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter.Update(dossierMarcherDataSet);
            dossierMarcherDataSet.AcceptChanges();
        }

        private void schedulerControl1_Click(object sender, EventArgs e)
        {

        }
    }
}