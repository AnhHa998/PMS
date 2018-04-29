namespace PMS.Modules
{
    partial class ucTuDienDuLieu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTuDienDuLieu));
            this.barMng = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnLamTuoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.layout_control = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlDuLieu = new DevExpress.XtraGrid.GridControl();
            this.bsDuLieu = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewDuLieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layout_control_group = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.toolTip = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barMng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layout_control)).BeginInit();
            this.layout_control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layout_control_group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // barMng
            // 
            this.barMng.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barMng.DockControls.Add(this.barDockControlTop);
            this.barMng.DockControls.Add(this.barDockControlBottom);
            this.barMng.DockControls.Add(this.barDockControlLeft);
            this.barMng.DockControls.Add(this.barDockControlRight);
            this.barMng.Form = this;
            this.barMng.Images = this.imgCollection;
            this.barMng.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnLamTuoi,
            this.btnXoa,
            this.btnLuu});
            this.barMng.MaxItemId = 3;
            this.barMng.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLamTuoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnLamTuoi
            // 
            this.btnLamTuoi.Caption = "Làm tươi";
            this.btnLamTuoi.Id = 0;
            this.btnLamTuoi.ImageOptions.ImageIndex = 2;
            this.btnLamTuoi.Name = "btnLamTuoi";
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 1;
            this.btnXoa.ImageOptions.ImageIndex = 1;
            this.btnXoa.Name = "btnXoa";
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 2;
            this.btnLuu.ImageOptions.ImageIndex = 3;
            this.btnLuu.Name = "btnLuu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barMng;
            this.barDockControlTop.Size = new System.Drawing.Size(525, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 338);
            this.barDockControlBottom.Manager = this.barMng;
            this.barDockControlBottom.Size = new System.Drawing.Size(525, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barMng;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 307);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(525, 31);
            this.barDockControlRight.Manager = this.barMng;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 307);
            // 
            // imgCollection
            // 
            this.imgCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCollection.ImageStream")));
            this.imgCollection.InsertImage(global::PMS.Properties.Resources.Them_16px, "Them_16px", typeof(global::PMS.Properties.Resources), 0);
            this.imgCollection.Images.SetKeyName(0, "Them_16px");
            this.imgCollection.InsertImage(global::PMS.Properties.Resources.Xoa_16px, "Xoa_16px", typeof(global::PMS.Properties.Resources), 1);
            this.imgCollection.Images.SetKeyName(1, "Xoa_16px");
            this.imgCollection.InsertImage(global::PMS.Properties.Resources.LamTuoi_16px, "LamTuoi_16px", typeof(global::PMS.Properties.Resources), 2);
            this.imgCollection.Images.SetKeyName(2, "LamTuoi_16px");
            this.imgCollection.InsertImage(global::PMS.Properties.Resources.Luu_16px, "Luu_16px", typeof(global::PMS.Properties.Resources), 3);
            this.imgCollection.Images.SetKeyName(3, "Luu_16px");
            // 
            // layout_control
            // 
            this.layout_control.Controls.Add(this.gridControlDuLieu);
            this.layout_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_control.Location = new System.Drawing.Point(0, 31);
            this.layout_control.Name = "layout_control";
            this.layout_control.Root = this.layout_control_group;
            this.layout_control.Size = new System.Drawing.Size(525, 307);
            this.layout_control.TabIndex = 4;
            this.layout_control.Text = "layout control";
            // 
            // gridControlDuLieu
            // 
            this.gridControlDuLieu.DataSource = this.bsDuLieu;
            this.gridControlDuLieu.Location = new System.Drawing.Point(12, 12);
            this.gridControlDuLieu.MainView = this.gridViewDuLieu;
            this.gridControlDuLieu.MenuManager = this.barMng;
            this.gridControlDuLieu.Name = "gridControlDuLieu";
            this.gridControlDuLieu.Size = new System.Drawing.Size(501, 283);
            this.gridControlDuLieu.TabIndex = 4;
            this.gridControlDuLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDuLieu});
            // 
            // gridViewDuLieu
            // 
            this.gridViewDuLieu.GridControl = this.gridControlDuLieu;
            this.gridViewDuLieu.Name = "gridViewDuLieu";
            // 
            // layout_control_group
            // 
            this.layout_control_group.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layout_control_group.GroupBordersVisible = false;
            this.layout_control_group.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layout_control_group.Name = "layout_control_group";
            this.layout_control_group.Size = new System.Drawing.Size(525, 307);
            this.layout_control_group.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlDuLieu;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(505, 287);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ucTuDienDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layout_control);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucTuDienDuLieu";
            this.Size = new System.Drawing.Size(525, 361);
            this.Load += new System.EventHandler(this.ucTuDienDuLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barMng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layout_control)).EndInit();
            this.layout_control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layout_control_group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barMng;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnLamTuoi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layout_control;
        private DevExpress.XtraGrid.GridControl gridControlDuLieu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDuLieu;
        private DevExpress.XtraLayout.LayoutControlGroup layout_control_group;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Utils.ImageCollection imgCollection;
        private DevExpress.Utils.ToolTipController toolTip;
        private System.Windows.Forms.BindingSource bsDuLieu;
    }
}
