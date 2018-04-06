namespace PMS.Forms.HeThong
{
    partial class frmChucNang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChucNang));
            this.barMng = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnLamTuoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.cboPhanLoai = new DevExpress.XtraBars.BarEditItem();
            this.repoLookupEditLoaiChucNang = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.treeListChucNang = new DevExpress.XtraTreeList.TreeList();
            this.bsChucNang = new System.Windows.Forms.BindingSource(this.components);
            this.repoImageEditHinhAnh = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repoLookUpEditTenForm = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.toolTip = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barMng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookupEditLoaiChucNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListChucNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsChucNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoImageEditHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookUpEditTenForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
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
            this.btnThem,
            this.btnXoa,
            this.btnLuu,
            this.btnLamTuoi,
            this.cboPhanLoai});
            this.barMng.MaxItemId = 6;
            this.barMng.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repoLookupEditLoaiChucNang});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cboPhanLoai, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Caption)});
            this.bar1.Text = "Tools";
            // 
            // btnLamTuoi
            // 
            this.btnLamTuoi.Caption = "Làm tươi";
            this.btnLamTuoi.Id = 4;
            this.btnLamTuoi.ImageOptions.ImageIndex = 2;
            this.btnLamTuoi.Name = "btnLamTuoi";
            this.btnLamTuoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLamTuoi_ItemClick);
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 1;
            this.btnThem.ImageOptions.ImageIndex = 0;
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.ImageIndex = 1;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.ImageIndex = 3;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // cboPhanLoai
            // 
            this.cboPhanLoai.Caption = "Phân loại:";
            this.cboPhanLoai.Edit = this.repoLookupEditLoaiChucNang;
            this.cboPhanLoai.EditWidth = 100;
            this.cboPhanLoai.Id = 5;
            this.cboPhanLoai.Name = "cboPhanLoai";
            // 
            // repoLookupEditLoaiChucNang
            // 
            this.repoLookupEditLoaiChucNang.AutoHeight = false;
            this.repoLookupEditLoaiChucNang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoLookupEditLoaiChucNang.Name = "repoLookupEditLoaiChucNang";
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
            this.barDockControlTop.Size = new System.Drawing.Size(681, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 385);
            this.barDockControlBottom.Manager = this.barMng;
            this.barDockControlBottom.Size = new System.Drawing.Size(681, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barMng;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 354);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(681, 31);
            this.barDockControlRight.Manager = this.barMng;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 354);
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
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.treeListChucNang);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 31);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(681, 354);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // treeListChucNang
            // 
            this.treeListChucNang.DataSource = this.bsChucNang;
            this.treeListChucNang.Location = new System.Drawing.Point(12, 12);
            this.treeListChucNang.Name = "treeListChucNang";
            this.treeListChucNang.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoImageEditHinhAnh,
            this.repoLookUpEditTenForm});
            this.treeListChucNang.Size = new System.Drawing.Size(657, 330);
            this.treeListChucNang.TabIndex = 4;
            this.treeListChucNang.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListChucNang_FocusedNodeChanged);
            this.treeListChucNang.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeListChucNang_CellValueChanged);
            // 
            // repoImageEditHinhAnh
            // 
            this.repoImageEditHinhAnh.AutoHeight = false;
            this.repoImageEditHinhAnh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoImageEditHinhAnh.Name = "repoImageEditHinhAnh";
            // 
            // repoLookUpEditTenForm
            // 
            this.repoLookUpEditTenForm.AutoHeight = false;
            this.repoLookUpEditTenForm.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoLookUpEditTenForm.Name = "repoLookUpEditTenForm";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(681, 354);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeListChucNang;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(661, 334);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 408);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmChucNang";
            this.Text = "frmChucNang";
            this.Load += new System.EventHandler(this.frmChucNang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barMng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookupEditLoaiChucNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListChucNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsChucNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoImageEditHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookUpEditTenForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barMng;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnLamTuoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgCollection;
        private DevExpress.XtraBars.BarEditItem cboPhanLoai;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repoLookupEditLoaiChucNang;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraTreeList.TreeList treeListChucNang;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Utils.ToolTipController toolTip;
        private System.Windows.Forms.BindingSource bsChucNang;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repoImageEditHinhAnh;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repoLookUpEditTenForm;
    }
}