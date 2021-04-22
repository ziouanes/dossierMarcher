using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2
{
   public class class_reportData
    {
        public int délai_Initial { get; set; }

        //public int etat_objet { get; set; }

        private string _etat_objet;


        public string etat_objet
        {
            get
            {
                return _etat_objet;
            }
            set
            {
                if (value == "0")
                {
                    _etat_objet = "order d'arrêt";
                }
                else if (value == "1")
                {
                    _etat_objet = "order de reprise";
                }
                else if (value == "2")
                {
                    _etat_objet = "réception provisoire";

                }
                else if (value == "3")
                {
                    _etat_objet = "réception définitive";

                }
            }
        }

        public DateTime date_deffet { get; set; }



    }
}
