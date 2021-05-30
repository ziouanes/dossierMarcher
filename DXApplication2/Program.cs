﻿using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
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

            //get current proccess name
            string strProcessName = Process.GetCurrentProcess().ProcessName;

            //chech if this process name is existing in the current name
            Process[] Oprocesses = Process.GetProcessesByName(strProcessName);
            //if its existing then exit

            if (Oprocesses.Length > 1)
            {

                MessageBox.Show("cette application est déjà en cours d'exécution");
            }
            else
            {


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Create a new object, representing the German culture. 
                CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR");

                // The following line provides localization for the application's user interface. 
                Thread.CurrentThread.CurrentUICulture = culture;

                // The following line provides localization for data formats. 
                Thread.CurrentThread.CurrentCulture = culture;

                // Set this culture as the default culture for all threads in this application. 
                // Note: The following properties are supported in the .NET Framework 4.5+
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;

                Application.Run(new Form1());
               // Application.Run(new calendrier());


            }
        }


     // public static SqlConnection sql_con = new SqlConnection(@"server =192.168.100.92;database = dossierMarcher ; user id = log1; password=P@ssword1965** ;MultipleActiveResultSets = True;");

        
    

        public static SqlConnection sql_con = new SqlConnection("Data Source=AANDROID-123122;Initial Catalog=dossierMarcher;Integrated Security=True;MultipleActiveResultSets = True;");



        




        internal static SqlCommand sql_cmd;

        public static SqlDataReader db;

        public static SqlDataAdapter adapter;
    }
}
