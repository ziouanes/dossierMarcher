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
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonEtude_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Etude fm = new Etude();
            
            fm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void barButtonPublication_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            publication fm = new publication();

            fm.ShowDialog();
        }

        private void officeNavigationBar_Click(object sender, EventArgs e)
        {

        }
    }
}