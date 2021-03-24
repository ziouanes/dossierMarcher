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
    public partial class openOrderService : DevExpress.XtraEditors.XtraForm
    {
        int _id_overt;
        public openOrderService(int id_Overture , int délai_dexecution  )
        {
            InitializeComponent();
            textEditdelai_initail.Text = délai_dexecution.ToString();
            _id_overt = id_Overture;



        }

        private void openOrderService_Load(object sender, EventArgs e)
        {

            this.dateeditorderservice.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateeditorderservice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateeditorderservice.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateeditorderservice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;


            //int dayrestant;
            //DateTime dt = dateeditorderservice.DateTime;
            //int delai = int.Parse(textEditdelai_initail.Text);
            //dayrestant =  delai - (DateTime.Now - dt).Days;

        }

        private void dateeditorderservice_EditValueChanged(object sender, EventArgs e)
        {
            int dayrestant;
            DateTime dt = dateeditorderservice.DateTime;
            int delai = int.Parse(textEditdelai_initail.Text);
            if(dt <= DateTime.Now)
            {

            dayrestant = delai - (DateTime.Now - dt).Days;
            textEditdelai_restant.Text = dayrestant.ToString();
            }

        }
    }
}