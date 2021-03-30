using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication2
{
   public class class_EtatOrder
    {
        public int id_order { get; set; }

        public DateTime date_deffet { get; set; }

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

        public int délai_restant { get; set; }

    }
}
