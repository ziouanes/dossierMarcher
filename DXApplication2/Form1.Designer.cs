
namespace DXApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.barSubItemNavigation = new DevExpress.XtraBars.BarSubItem();
            this.employeesBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.customersBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.skinDropDownButtonItem = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.skinPaletteRibbonGalleryBarItem = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.barButtonEtude = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPublication = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonouverture = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupNavigation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.officeNavigationBar = new DevExpress.XtraBars.Navigation.OfficeNavigationBar();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.employeesNavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.customersNavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.employeesNavigationPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gridControlEtude = new DevExpress.XtraGrid.GridControl();
            this.classEtudeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewEtude = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colobjet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colestimation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmontant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colenvoyer_tresoryer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvalidate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldélai_dexecution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employeesLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.customersNavigationPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gridControlPub = new DevExpress.XtraGrid.GridControl();
            this.gridViewPub = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.customersLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gridControlOvert = new DevExpress.XtraGrid.GridControl();
            this.gridViewOvert = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).BeginInit();
            this.navigationFrame.SuspendLayout();
            this.employeesNavigationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEtude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classEtudeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEtude)).BeginInit();
            this.customersNavigationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPub)).BeginInit();
            this.navigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOvert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOvert)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 575);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1144, 24);
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.skinRibbonGalleryBarItem,
            this.barSubItemNavigation,
            this.employeesBarButtonItem,
            this.customersBarButtonItem,
            this.skinDropDownButtonItem,
            this.skinPaletteRibbonGalleryBarItem,
            this.barButtonEtude,
            this.barButtonPublication,
            this.barButtonouverture,
            this.barButtonItem1});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 50;
            this.ribbonControl.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage,
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1144, 158);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // skinRibbonGalleryBarItem
            // 
            this.skinRibbonGalleryBarItem.Id = 14;
            this.skinRibbonGalleryBarItem.Name = "skinRibbonGalleryBarItem";
            // 
            // barSubItemNavigation
            // 
            this.barSubItemNavigation.Caption = "Navigation";
            this.barSubItemNavigation.Id = 15;
            this.barSubItemNavigation.ImageOptions.ImageUri.Uri = "NavigationBar";
            this.barSubItemNavigation.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.employeesBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.customersBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.barSubItemNavigation.Name = "barSubItemNavigation";
            // 
            // employeesBarButtonItem
            // 
            this.employeesBarButtonItem.Caption = "Etude";
            this.employeesBarButtonItem.Id = 44;
            this.employeesBarButtonItem.Name = "employeesBarButtonItem";
            this.employeesBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonNavigation_ItemClick);
            // 
            // customersBarButtonItem
            // 
            this.customersBarButtonItem.Caption = "Publication";
            this.customersBarButtonItem.Id = 45;
            this.customersBarButtonItem.Name = "customersBarButtonItem";
            this.customersBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonNavigation_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Overture";
            this.barButtonItem1.Id = 49;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // skinDropDownButtonItem
            // 
            this.skinDropDownButtonItem.Id = 46;
            this.skinDropDownButtonItem.Name = "skinDropDownButtonItem";
            // 
            // skinPaletteRibbonGalleryBarItem
            // 
            this.skinPaletteRibbonGalleryBarItem.Caption = "$newskinpalettename$";
            this.skinPaletteRibbonGalleryBarItem.Id = 47;
            this.skinPaletteRibbonGalleryBarItem.Name = "skinPaletteRibbonGalleryBarItem";
            // 
            // barButtonEtude
            // 
            this.barButtonEtude.Caption = "Etude";
            this.barButtonEtude.Id = 46;
            this.barButtonEtude.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonEtude.ImageOptions.Image")));
            this.barButtonEtude.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonEtude.ImageOptions.LargeImage")));
            this.barButtonEtude.Name = "barButtonEtude";
            this.barButtonEtude.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonEtude_ItemClick);
            // 
            // barButtonPublication
            // 
            this.barButtonPublication.Caption = "Publication";
            this.barButtonPublication.Id = 47;
            this.barButtonPublication.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonPublication.ImageOptions.Image")));
            this.barButtonPublication.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonPublication.ImageOptions.LargeImage")));
            this.barButtonPublication.Name = "barButtonPublication";
            this.barButtonPublication.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonPublication_ItemClick);
            // 
            // barButtonouverture
            // 
            this.barButtonouverture.Caption = "Overtutre";
            this.barButtonouverture.Id = 48;
            this.barButtonouverture.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonouverture.ImageOptions.Image")));
            this.barButtonouverture.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonouverture.ImageOptions.LargeImage")));
            this.barButtonouverture.Name = "barButtonouverture";
            // 
            // ribbonPage
            // 
            this.ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupNavigation,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage.Name = "ribbonPage";
            this.ribbonPage.Text = "View";
            // 
            // ribbonPageGroupNavigation
            // 
            this.ribbonPageGroupNavigation.ItemLinks.Add(this.barSubItemNavigation);
            this.ribbonPageGroupNavigation.Name = "ribbonPageGroupNavigation";
            this.ribbonPageGroupNavigation.Text = "Module";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonEtude);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonPublication);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonouverture);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "theme";
            // 
            // ribbonPageGroup
            // 
            this.ribbonPageGroup.AllowTextClipping = false;
            this.ribbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup.ItemLinks.Add(this.skinDropDownButtonItem);
            this.ribbonPageGroup.ItemLinks.Add(this.skinPaletteRibbonGalleryBarItem);
            this.ribbonPageGroup.Name = "ribbonPageGroup";
            this.ribbonPageGroup.Text = "Appearance";
            // 
            // officeNavigationBar
            // 
            this.officeNavigationBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.officeNavigationBar.Location = new System.Drawing.Point(0, 529);
            this.officeNavigationBar.Name = "officeNavigationBar";
            this.officeNavigationBar.NavigationClient = this.navBarControl;
            this.officeNavigationBar.Size = new System.Drawing.Size(1144, 46);
            this.officeNavigationBar.TabIndex = 1;
            this.officeNavigationBar.Text = "officeNavigationBar";
            this.officeNavigationBar.Click += new System.EventHandler(this.officeNavigationBar_Click);
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.employeesNavBarGroup;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.employeesNavBarGroup,
            this.customersNavBarGroup,
            this.navBarGroup1});
            this.navBarControl.Location = new System.Drawing.Point(0, 158);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 165;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.Size = new System.Drawing.Size(165, 371);
            this.navBarControl.TabIndex = 0;
            this.navBarControl.Text = "navBarControl";
            this.navBarControl.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.navBarControl_ActiveGroupChanged);
            // 
            // employeesNavBarGroup
            // 
            this.employeesNavBarGroup.Caption = "Etude";
            this.employeesNavBarGroup.Expanded = true;
            this.employeesNavBarGroup.Name = "employeesNavBarGroup";
            // 
            // customersNavBarGroup
            // 
            this.customersNavBarGroup.Caption = "Publication";
            this.customersNavBarGroup.Name = "customersNavBarGroup";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Overture";
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navigationFrame
            // 
            this.navigationFrame.Appearance.BackColor = System.Drawing.Color.White;
            this.navigationFrame.Appearance.Options.UseBackColor = true;
            this.navigationFrame.Controls.Add(this.employeesNavigationPage);
            this.navigationFrame.Controls.Add(this.customersNavigationPage);
            this.navigationFrame.Controls.Add(this.navigationPage1);
            this.navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame.Location = new System.Drawing.Point(165, 158);
            this.navigationFrame.Name = "navigationFrame";
            this.navigationFrame.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.employeesNavigationPage,
            this.customersNavigationPage,
            this.navigationPage1});
            this.navigationFrame.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
            this.navigationFrame.SelectedPage = this.employeesNavigationPage;
            this.navigationFrame.Size = new System.Drawing.Size(979, 371);
            this.navigationFrame.TabIndex = 0;
            this.navigationFrame.Text = "navigationFrame";
            // 
            // employeesNavigationPage
            // 
            this.employeesNavigationPage.Controls.Add(this.gridControlEtude);
            this.employeesNavigationPage.Controls.Add(this.employeesLabelControl);
            this.employeesNavigationPage.Name = "employeesNavigationPage";
            this.employeesNavigationPage.Size = new System.Drawing.Size(979, 371);
            // 
            // gridControlEtude
            // 
            this.gridControlEtude.BackgroundImage = global::DXApplication2.Properties.Resources.icons8_registration_32;
            this.gridControlEtude.DataSource = this.classEtudeBindingSource;
            this.gridControlEtude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEtude.Location = new System.Drawing.Point(0, 0);
            this.gridControlEtude.MainView = this.gridViewEtude;
            this.gridControlEtude.MenuManager = this.ribbonControl;
            this.gridControlEtude.Name = "gridControlEtude";
            this.gridControlEtude.Size = new System.Drawing.Size(979, 371);
            this.gridControlEtude.TabIndex = 1;
            this.gridControlEtude.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEtude});
            // 
            // classEtudeBindingSource
            // 
            this.classEtudeBindingSource.DataSource = typeof(DXApplication2.ClassEtude);
            // 
            // gridViewEtude
            // 
            this.gridViewEtude.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid1,
            this.colobjet,
            this.colestimation,
            this.colmontant,
            this.colenvoyer_tresoryer,
            this.colvalidate,
            this.coldélai_dexecution,
            this.coldeleted});
            this.gridViewEtude.GridControl = this.gridControlEtude;
            this.gridViewEtude.Name = "gridViewEtude";
            this.gridViewEtude.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewEtude_RowStyle);
            // 
            // colid1
            // 
            this.colid1.FieldName = "id1";
            this.colid1.Name = "colid1";
            this.colid1.Visible = true;
            this.colid1.VisibleIndex = 0;
            this.colid1.Width = 60;
            // 
            // colobjet
            // 
            this.colobjet.FieldName = "objet";
            this.colobjet.Name = "colobjet";
            this.colobjet.Visible = true;
            this.colobjet.VisibleIndex = 1;
            this.colobjet.Width = 126;
            // 
            // colestimation
            // 
            this.colestimation.FieldName = "estimation";
            this.colestimation.Name = "colestimation";
            this.colestimation.Visible = true;
            this.colestimation.VisibleIndex = 2;
            this.colestimation.Width = 113;
            // 
            // colmontant
            // 
            this.colmontant.FieldName = "montant";
            this.colmontant.Name = "colmontant";
            this.colmontant.Visible = true;
            this.colmontant.VisibleIndex = 3;
            this.colmontant.Width = 94;
            // 
            // colenvoyer_tresoryer
            // 
            this.colenvoyer_tresoryer.FieldName = "envoyer_tresoryer";
            this.colenvoyer_tresoryer.Name = "colenvoyer_tresoryer";
            this.colenvoyer_tresoryer.Visible = true;
            this.colenvoyer_tresoryer.VisibleIndex = 4;
            this.colenvoyer_tresoryer.Width = 108;
            // 
            // colvalidate
            // 
            this.colvalidate.FieldName = "validate";
            this.colvalidate.Name = "colvalidate";
            this.colvalidate.Width = 108;
            // 
            // coldélai_dexecution
            // 
            this.coldélai_dexecution.FieldName = "délai_dexecution";
            this.coldélai_dexecution.Name = "coldélai_dexecution";
            this.coldélai_dexecution.Visible = true;
            this.coldélai_dexecution.VisibleIndex = 5;
            this.coldélai_dexecution.Width = 108;
            // 
            // coldeleted
            // 
            this.coldeleted.FieldName = "deleted";
            this.coldeleted.Name = "coldeleted";
            this.coldeleted.Width = 129;
            // 
            // employeesLabelControl
            // 
            this.employeesLabelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 25.25F);
            this.employeesLabelControl.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.employeesLabelControl.Appearance.Options.UseFont = true;
            this.employeesLabelControl.Appearance.Options.UseForeColor = true;
            this.employeesLabelControl.Appearance.Options.UseTextOptions = true;
            this.employeesLabelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.employeesLabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.employeesLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.employeesLabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeesLabelControl.Location = new System.Drawing.Point(0, 0);
            this.employeesLabelControl.Name = "employeesLabelControl";
            this.employeesLabelControl.Size = new System.Drawing.Size(979, 371);
            this.employeesLabelControl.TabIndex = 0;
            this.employeesLabelControl.Text = "Etude";
            // 
            // customersNavigationPage
            // 
            this.customersNavigationPage.Controls.Add(this.gridControlPub);
            this.customersNavigationPage.Controls.Add(this.customersLabelControl);
            this.customersNavigationPage.Name = "customersNavigationPage";
            this.customersNavigationPage.Size = new System.Drawing.Size(979, 371);
            // 
            // gridControlPub
            // 
            this.gridControlPub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPub.Location = new System.Drawing.Point(0, 0);
            this.gridControlPub.MainView = this.gridViewPub;
            this.gridControlPub.MenuManager = this.ribbonControl;
            this.gridControlPub.Name = "gridControlPub";
            this.gridControlPub.Size = new System.Drawing.Size(979, 371);
            this.gridControlPub.TabIndex = 2;
            this.gridControlPub.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPub});
            // 
            // gridViewPub
            // 
            this.gridViewPub.GridControl = this.gridControlPub;
            this.gridViewPub.Name = "gridViewPub";
            // 
            // customersLabelControl
            // 
            this.customersLabelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 25.25F);
            this.customersLabelControl.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.customersLabelControl.Appearance.Options.UseFont = true;
            this.customersLabelControl.Appearance.Options.UseForeColor = true;
            this.customersLabelControl.Appearance.Options.UseTextOptions = true;
            this.customersLabelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.customersLabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.customersLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.customersLabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customersLabelControl.Location = new System.Drawing.Point(0, 0);
            this.customersLabelControl.Name = "customersLabelControl";
            this.customersLabelControl.Size = new System.Drawing.Size(979, 371);
            this.customersLabelControl.TabIndex = 1;
            this.customersLabelControl.Text = "Publication";
            // 
            // navigationPage1
            // 
            this.navigationPage1.Controls.Add(this.gridControlOvert);
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(979, 371);
            // 
            // gridControlOvert
            // 
            this.gridControlOvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlOvert.Location = new System.Drawing.Point(0, 0);
            this.gridControlOvert.MainView = this.gridViewOvert;
            this.gridControlOvert.MenuManager = this.ribbonControl;
            this.gridControlOvert.Name = "gridControlOvert";
            this.gridControlOvert.Size = new System.Drawing.Size(979, 371);
            this.gridControlOvert.TabIndex = 0;
            this.gridControlOvert.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOvert});
            // 
            // gridViewOvert
            // 
            this.gridViewOvert.GridControl = this.gridControlOvert;
            this.gridViewOvert.Name = "gridViewOvert";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 599);
            this.Controls.Add(this.navigationFrame);
            this.Controls.Add(this.navBarControl);
            this.Controls.Add(this.officeNavigationBar);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.IconOptions.Image = global::DXApplication2.Properties.Resources.icons8_registration_32;
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "accueil";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).EndInit();
            this.navigationFrame.ResumeLayout(false);
            this.employeesNavigationPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEtude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classEtudeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEtude)).EndInit();
            this.customersNavigationPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPub)).EndInit();
            this.navigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOvert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOvert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Navigation.OfficeNavigationBar officeNavigationBar;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup employeesNavBarGroup;
        private DevExpress.XtraNavBar.NavBarGroup customersNavBarGroup;
        private DevExpress.XtraBars.Navigation.NavigationPage employeesNavigationPage;
        private DevExpress.XtraEditors.LabelControl employeesLabelControl;
        private DevExpress.XtraBars.Navigation.NavigationPage customersNavigationPage;
        private DevExpress.XtraEditors.LabelControl customersLabelControl;
        private DevExpress.XtraGrid.GridControl gridControlEtude;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEtude;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraGrid.GridControl gridControlPub;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPub;
        private DevExpress.XtraGrid.GridControl gridControlOvert;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOvert;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem;
        private DevExpress.XtraBars.BarSubItem barSubItemNavigation;
        private DevExpress.XtraBars.BarButtonItem employeesBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem customersBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem;
        private DevExpress.XtraBars.BarButtonItem barButtonEtude;
        private DevExpress.XtraBars.BarButtonItem barButtonPublication;
        private DevExpress.XtraBars.BarButtonItem barButtonouverture;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupNavigation;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup;
        private System.Windows.Forms.BindingSource classEtudeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn colobjet;
        private DevExpress.XtraGrid.Columns.GridColumn colestimation;
        private DevExpress.XtraGrid.Columns.GridColumn colmontant;
        private DevExpress.XtraGrid.Columns.GridColumn colenvoyer_tresoryer;
        private DevExpress.XtraGrid.Columns.GridColumn colvalidate;
        private DevExpress.XtraGrid.Columns.GridColumn coldélai_dexecution;
        private DevExpress.XtraGrid.Columns.GridColumn coldeleted;
    }
}