using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DXApplication2
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Etude());
        }


        public static SqlConnection sql_con = new SqlConnection("Data Source=AANDROID-123122;Initial Catalog=dossierMarcher;Integrated Security=True;MultipleActiveResultSets = True;");


        internal static SqlCommand sql_cmd;

        public static SqlDataReader db;

        public static SqlDataAdapter adapter;
    }
}
