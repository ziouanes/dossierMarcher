using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2
{
   public class ClassSIMPLE_overture
    {
        public int id3 { get; set; }
        public string attributaire { get; set; }
        public string Montant { get; set; }
        public string num_Marcher { get; set; }
        public DateTime date_Visa { get; set; }
        public DateTime date_approbation { get; set; }
        public int valide_approbation { get; set; }
        public int duree_approbation { get; set; }
        public int délai_dexecution { get; set; }
        public string caution_definitif { get; set; }
        public string caution_return { get; set; }
        public DateTime datenotifiy { get; set; }
        public DateTime date_caution { get; set; }
        public int valide_caution { get; set; }
        public int duree_caution { get; set; }
        public int valide_order_service { get; set; }
        public int duree_order_service { get; set; }


    }
}
