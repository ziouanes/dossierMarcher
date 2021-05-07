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
using DevExpress.XtraScheduler.GoogleCalendar;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System.IO;
using Google.Apis.Services;
using System.Threading;
using Google.Apis.Util.Store;

namespace DXApplication2
{
    public partial class calendrier : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        UserCredential credential;
        CalendarService service;
        CalendarList calendarList;
        string activeCalendarId;
        bool allowEventLoad;
        public calendrier()
        {
            InitializeComponent();

            gcSyncComponent.ConflictDetected += gcSyncComponent_ConflictDetected;

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


        #region Authorization
        async protected override void OnLoad(EventArgs e)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 3000;
            args.Caption = "Auto-close message";
            args.Text = "This message closes automatically after 3 seconds.";
            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };



            ////////////:
            base.OnLoad(e);
            Directory.CreateDirectory(Environment.CurrentDirectory + @"\xml");
            //try
            //{
                this.credential = await AuthorizeToGoogle();
                this.service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = this.credential,
                    ApplicationName = "Other client 1"
                });
                this.gcSyncComponent.CalendarService = this.service;
                // await UpdateCalendarListUI();
                this.allowEventLoad = true;
               // UpdateBbiAvailability();
                this.gcSyncComponent.Storage = schedulerDataStorage1;


            //  this.gcSyncComponent.CalendarId = "652ilqp8u3ikeur3ac2uqd1t8s@group.calendar.google.com";
              this.gcSyncComponent.CalendarId = "zioianhamza@gmail.com";

              this.gcSyncComponent.Synchronize();
            //}
            //catch (Exception ex)
            //{
            //     MessageBox.Show(ex.Message);
            //   // XtraMessageBox.Show(args).ToString();

            //}
        }

        async Task<UserCredential> AuthorizeToGoogle()
        {
            using (FileStream stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/GoogleSchedulerSync.json");

                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new String[] { CalendarService.Scope.Calendar },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
            }
        }
        #endregion

        private void gcSyncComponent_ConflictDetected(object sender, ConflictDetectedEventArgs e)
        {
            XtraMessageBox.Show("Google '" + e.Event.Summary + "' Event conflicts with the Scheduler '" +
                e.Appointment.Subject + "' Appointment." + Environment.NewLine + "Synchronizing by the Google Event.",
                "Conflict detected", MessageBoxButtons.OK);
            //uncomment the following line to sync by Scheduler Appointments instead
            e.GoogleEventIsValid = false;
        }
    }
}