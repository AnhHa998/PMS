using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using PMS.Core.Manager;
//using PMS.Core.Manager;
using PMS.Forms.HeThong;
using PMS_Data;
using PMS_Object;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using XuLyChung.XuLyHinhAnh;

namespace PMS.Core
{
    public class AppSystem
    {
        #region Biến toàn cục
        ChucNang_Data _dataChucNang = new ChucNang_Data();
        #endregion

        /// <summary>
        /// Container for app.
        /// </summary>
        private GroupControl AppContainer { get; set; }

        /// <summary>
        /// Invoke method.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="t"></param>
        /// <param name="module"></param>
        private static void InvokeMethod(object obj, Type t, AppModule module)
        {
            try
            {
                if (module.IsMethodInvoke)
                {
                    MethodInfo mi = FindMethod(t, module.MethodName, module.Parameter);
                    if (mi != null)
                    {
                        if (module.IsParameter)
                            mi.Invoke(obj, module.Parameter.Split(','));
                        else
                            mi.Invoke(obj, null);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load item module.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="e"></param>
        private static void LoadItemModule(Type t, ItemClickEventArgs e)
        {
            //AppModule objModule = e.Item.Tag as AppModule;
            ChucNang cn = e.Item.Tag as ChucNang;
            if (cn == null) return;
            foreach (Form fr in frmMain.Instance.xtraTabbedMdiManager.MdiParent.MdiChildren)
            {
                if (fr.Name == string.Format("{0}{1}", t.Name, cn.GUIName)) //Nếu chức năng đang được mở
                {
                    fr.Focus();
                    return;
                }
            }
            //Nếu chức năng đang không được mở
            switch (t.BaseType.Name)    //Tên lớp cha
            {
                case "XtraForm":
                    XtraForm xfrm = Activator.CreateInstance(t) as XtraForm;
                    if (xfrm != null)
                    {
                        //Phan quyen theo phuong thuc
                        bool result = false;
                        if (result)
                        {
                            MethodInfo mi = FindMethod(t, "KhongDuocPhepCapNhat", result.ToString());
                            if (mi != null)
                                mi.Invoke(xfrm, new string[] { result.ToString() });
                        }
                        //
                        xfrm.Name += cn.ModuleID;
                        //InvokeMethod(xfrm, t, cn);
                        if ((cn.LoaiChucNang.MdiForm ? "Mdi" : "") == "Popup")
                            xfrm.ShowDialog();
                        else
                        {
                            xfrm.MdiParent = frmMain.Instance;
                            xfrm.Tag = cn;
                            xfrm.Text = e.Item.Caption;
                            xfrm.Show();
                            xfrm.Focus();
                        }
                    }
                    break;
                //case "Form":
                //    Form frm = Activator.CreateInstance(t) as Form;
                //    if (frm != null)
                //    {
                //        frm.Name += cn.ModuleID;
                //        InvokeMethod(frm, t, cn);
                //        if (cn.LoaiChucNang.MaLoai == "Popup")
                //            frm.ShowDialog();
                //        else
                //        {
                //            if (cn.Module == null)
                //                cn.Module = new ChucNang_Data().LayDuLieu(cn.ModuleID);
                //            frm.MdiParent = frmMain.Instance;
                //            frm.Tag = cn;
                //            frm.Text = e.Item.Caption;
                //            frm.Show();
                //            frm.Focus();
                //        }
                //    }
                //    break;
                //case "Object":
                //    Object obj = Activator.CreateInstance(t) as Object;
                //    if (obj != null)
                //        InvokeMethod(obj, t, objModule);
                //    break;
                default:
                    break;
            }
        }

        //public static void LoadModules(XtraForm frm, TreeList treeList)
        //{
        //    treeList.KeyFieldName = "Id";
        //    treeList.ParentFieldName = "ParentId";
        //    AppModule objModule = frm.Tag as AppModule;
        //    if (objModule != null)
        //    {
        //        foreach (ChucNang c in DataServices.ChucNang.GetByIDTrangThai(objModule.Id, true))
        //        {
        //            TList<ChucNang> listModules = DataServices.ChucNang.GetByMaNhomQuyenParentIDPhanLoaiTrangThai(UserInfo.GroupID, c.Id, "Module", true);
        //            if (listModules.Count > 0)
        //            {
        //                treeList.DataSource = listModules;
        //                return;
        //            }
        //        }
        //    }
        //}

        public void LoadModules(XtraForm frm, NavBarControl navControl, GroupControl pContainer, ImageCollection simageCollection)
        {
            AppContainer = pContainer;
            int sIndex = 0;
            ChucNang cn = frm.Tag as ChucNang;

            if (cn == null || !cn.TrangThai) return;

            List<ChucNang> dsGroup = _dataChucNang.LayDuLieu(cn.ModuleID, "Module", true);
            foreach (ChucNang grp in dsGroup)
            {
                //Group
                NavBarGroup group = new NavBarGroup(grp.ModuleName) { Name = string.Format("navBarGroup{0}", grp.ModuleID), GroupStyle = NavBarGroupStyle.Default };
                if (grp.HinhAnh != null)
                {
                    simageCollection.AddImage(grp.HinhAnh);
                    group.SmallImageIndex = sIndex;
                    sIndex++;
                }
                //Item
                List<ChucNang> dsItem = _dataChucNang.LayDuLieu(grp.ModuleID, "Module", true);
                foreach (ChucNang i in dsItem)
                {
                    NavBarItem item = new NavBarItem(i.ModuleName)
                    {
                        Caption = i.ModuleName,
                        Hint = i.ModuleName,
                        Name = string.Format("navBarItem{0}{1}", i.ModuleID, grp.ModuleID),
                        Tag = i
                        //Tag = new AppModule() {
                        //    Id = i.ModuleID,
                        //    ModuleId = i.GUIName,
                        //    Caption = i.ModuleName,
                        //    Type = i.KieuForm,
                        //    MethodName = i.TenPhuongThuc,
                        //    Parameter = i.ThamSo
                        //}
                    };
                    item.LinkClicked += NavItemClick;
                    if (i.HinhAnh != null)
                    {
                        simageCollection.AddImage(i.HinhAnh);
                        item.SmallImageIndex = sIndex;
                        sIndex++;
                    }
                    group.ItemLinks.Add(item);
                    navControl.Items.Add(item);
                }
                navControl.Groups.Add(group);
            }
            return;
        }

        /// <summary>
        /// Item Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Item.Tag == null) return;
            //AppModule objModule = e.Item.Tag as AppModule;
            ChucNang cn = e.Item.Tag as ChucNang;
            if (cn != null)
            {
                Plugin plugin = AppPlugin.Plugins.Find(cn.GUIName);
                if (plugin != null)
                {
                    Type t = Type.GetType(plugin.FullName);
                    if (t != null) LoadItemModule(t, e);
                    else
                    {
                        Type tf = Assembly.LoadFrom(plugin.AssemblyPath).GetType(plugin.FullName);
                        if (tf != null) LoadItemModule(tf, e);
                    }
                }
                else
                {
                    throw new Exception("Chức năng không tồn tại!");
                }
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Nav item click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavItemClick(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ChucNang cn = e.Link.Item.Tag as ChucNang;
            if (cn != null)
            {
                Plugin plugin = AppPlugin.Plugins.Find(cn.GUIName);
                if (plugin != null)
                {
                    Type t = Type.GetType(plugin.FullName);
                    if (t != null)
                        ModuleSelect(t, e);
                    else
                    {
                        Type tf = Assembly.LoadFrom(plugin.AssemblyPath).GetType(plugin.FullName);
                        if (tf != null)
                            ModuleSelect(tf, e);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }


        /// <summary>
        /// Init System.
        /// </summary>
        public static void InitSystem()
        {
            //Init ComponentModel
            ((System.ComponentModel.ISupportInitialize)(frmMain.Instance.ribbon)).BeginInit();
            //Init Image
            frmMain.Instance.ribbon.LargeImages = frmMain.Instance.imageCollectionSystem;
            //Add page
            RibbonPage page = new RibbonPage("Hệ thống") { Name = "ribbonPageSystem" };
            frmMain.Instance.ribbon.Pages.Add(page);
            //Add Group
            RibbonPageGroup group = new RibbonPageGroup("Nhóm hệ thống") { Name = "ribbonPageGroupSystem", AllowTextClipping = false };
            page.Groups.Add(group);

            List<XtraForm> listForm = new List<XtraForm>();
            listForm.AddRange(new XtraForm[] {
                //new frmChucNang(),
                new frmNhomQuyen(),
                new frmPhanQuyen() });

            int index = 0;
            foreach (XtraForm fr in listForm)
            {
                BarButtonItem item = new BarButtonItem { Caption = fr.Text, Name = string.Format("barButtonItem{0}", index), Tag = new AppModule() { ModuleId = fr.GetType().FullName }, Hint = fr.Text, Description = fr.Text, LargeImageIndex = index };
                item.ItemClick += ItemClick;
                group.ItemLinks.Add(item, true);
                index++;
            }
            ((System.ComponentModel.ISupportInitialize)(frmMain.Instance.ribbon)).EndInit();
        }

        /// <summary>
        /// Init Control.
        /// </summary>
        public static void InitControl()
        {
            int lIndex = 0, sIndex = 0;
            //Init ComponentModel
            ((System.ComponentModel.ISupportInitialize)(frmMain.Instance.ribbon)).BeginInit();
            //Init Image
            frmMain.Instance.ribbon.LargeImages = frmMain.Instance.LimageCollection;
            //Clear image collection
            frmMain.Instance.LimageCollection.Images.Clear();
            frmMain.Instance.SimageCollection.Images.Clear();
            //Init 
            foreach (Quyen q in TaiKhoan.TAI_KHOAN_HIEN_TAI.DsQuyen)
            {
                List<ChucNang> dsTab = q.DsChucNang.FindAll(cn => cn.LoaiChucNang.MaLoai == "Tab" && cn.TrangThai);
                foreach (ChucNang cnTab in dsTab)
                {
                    //Add Page:
                    RibbonPage page = new RibbonPage(cnTab.ModuleName) { Name = string.Format("ribbonPage{0}", cnTab.ModuleID) };
                    frmMain.Instance.ribbon.Pages.Add(page);
                    //Add PageGroup:
                    List<ChucNang> dsGroup = q.DsChucNang.FindAll(cn => cn.LoaiChucNang.MaLoai == "Group" && cn.MaChucNangBacTren == cnTab.ModuleID && cn.TrangThai);
                    foreach (ChucNang cnGroup in dsGroup)
                    {
                        RibbonPageGroup group = new RibbonPageGroup(cnGroup.ModuleName) { Name = string.Format("ribbonPageGroup{0}", cnGroup.ModuleID), AllowTextClipping = false };
                        page.Groups.Add(group);
                        //Add Item:
                        List<ChucNang> dsItem = q.DsChucNang.FindAll(cn => cn.LoaiChucNang.MaLoai == "Item" && cn.MaChucNangBacTren == cnGroup.ModuleID && cn.TrangThai);
                        foreach (ChucNang cnItem in dsItem)
                        {
                            //RibbonPageGroup item = new RibbonPageGroup(cnItem.ModuleName) { Name = string.Format("ribbonPageGroup{0}", cnItem.ModuleID), AllowTextClipping = false };
                            //page.Groups.Add(item);
                            if (cnItem.HinhAnh != null && !cnItem.HinhAnh.Equals(DBNull.Value))
                            {
                                frmMain.Instance.LimageCollection.AddImage(cnItem.HinhAnh);
                            }
                            BarButtonItem item = new BarButtonItem(frmMain.Instance.ribbon.Manager, cnItem.ModuleName)
                            {
                                Name = string.Format("barButtonItem{0}", cnItem.ModuleID),
                                Tag = cnItem,
                                //= new AppModule()
                                //{
                                //    Id = cnItem.ModuleID,
                                //    ModuleId = cnItem.GUIName,
                                //    Caption = cnItem.ModuleName,
                                //    Type = cnItem.LoaiChucNang.MdiForm ? "Mdi" : ""
                                //    //, MethodName = iModule["TenPhuongThuc"].ToString()
                                //    //, Parameter = iModule["ThamSo"].ToString()
                                //},
                                Hint = cnItem.ModuleName,
                                Description = cnItem.ModuleName
                            };
                            item.ItemClick += ItemClick;
                            if (cnItem.HinhAnh != null)
                            {
                                item.LargeImageIndex = lIndex;
                                lIndex++;
                            }
                            item.RibbonStyle = RibbonItemStyles.All;
                            group.ItemLinks.Add(item, false); //(bool)iModule["BeginGroup"]
                            frmMain.Instance.ribbon.Items.Add(item);
                        }
                    }
                }
                
            }
            //foreach (DataRow pModule in dt.Select(string.Format("PhanLoai='{0}' AND TrangThai={1}", "Tab", 1), "ThuTu ASC"))
            //{
            //    //Add Page
            //    RibbonPage page = new RibbonPage(pModule["ModuleName"].ToString()) { Name = string.Format("ribbonPage{0}", pModule["ID"]) };
            //    frmMain.Instance.ribbon.Pages.Add(page);
            //    //Add PageGroup
            //    foreach (DataRow gModule in dt.Select(string.Format("PhanLoai='{0}' AND TrangThai={1} AND ParentID={2}", "Group", 1, pModule["ID"]), "ThuTu ASC"))
            //    {
            //        RibbonPageGroup group = new RibbonPageGroup(gModule["ModuleName"].ToString()) { Name = string.Format("ribbonPageGroup{0}", gModule["ID"]), AllowTextClipping = false };
            //        page.Groups.Add(group);
            //        //Add Item
            //        foreach (DataRow iModule in dt.Select(string.Format("PhanLoai='{0}' AND TrangThai={1} AND ParentID={2}", "Item", 1, gModule["ID"]), "ThuTu ASC"))
            //        {
            //            if (iModule["HinhAnh"] != DBNull.Value)
            //            {
            //                //if ((bool)iModule["RibbonStyle"])
            //                //    frmMain.Instance.SimageCollection.AddImage(AppImage.ByteArrayToImage((byte[])iModule["HinhAnh"]));
            //                //else
            //                    frmMain.Instance.LimageCollection.AddImage(AppImage.ByteArrayToImage((byte[])iModule["HinhAnh"]));
            //            }
            //            BarButtonItem item = new BarButtonItem(frmMain.Instance.ribbon.Manager
            //                , iModule["ModuleName"].ToString()) {
            //                    Name = string.Format("barButtonItem{0}", iModule["ID"])
            //                    , Tag = new AppModule() { Id = (int)iModule["ID"]
            //                    , ModuleId = iModule["GUIName"].ToString()
            //                    , Caption = iModule["ModuleName"].ToString()
            //                    , Type = iModule["KieuForm"].ToString()
            //                    //, MethodName = iModule["TenPhuongThuc"].ToString()
            //                    //, Parameter = iModule["ThamSo"].ToString()
            //                }
            //                , Hint = iModule["ModuleName"].ToString()
            //                , Description = iModule["ModuleName"].ToString() };
            //            item.ItemClick += ItemClick;
            //            if (iModule["HinhAnh"] != DBNull.Value)
            //            {
            //                if (frmMain.Instance.SimageCollection.Images.Count > 0 && (bool)iModule["RibbonStyle"])
            //                {
            //                    item.ImageIndex = sIndex;
            //                    sIndex++;
            //                    item.RibbonStyle = RibbonItemStyles.SmallWithoutText | RibbonItemStyles.SmallWithText;
            //                    group.ItemLinks.Add(item, (bool)iModule["BeginGroup"]);
            //                }
            //                else
            //                {
            //                    item.LargeImageIndex = lIndex;
            //                    lIndex++;
            //                    item.RibbonStyle = RibbonItemStyles.All;
            //                    group.ItemLinks.Add(item, (bool)iModule["BeginGroup"]);
            //                }
            //            }
            //            else
            //            {
            //                item.RibbonStyle = RibbonItemStyles.All;
            //                group.ItemLinks.Add(item, (bool)iModule["BeginGroup"]);
            //            }
            //            frmMain.Instance.ribbon.Items.Add(item);
            //        }
            //    }
            //}
            ((System.ComponentModel.ISupportInitialize)(frmMain.Instance.ribbon)).EndInit();
        }

        /// <summary>
        /// Invoke method support treelist.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void InvokeMethod(Type t, object obj, FocusedNodeChangedEventArgs e)
        {
            try
            {
                AppModule objModule = e.Node.Tag as AppModule;
                if (objModule != null)
                {
                    if (objModule.IsMethodInvoke)
                    {
                        MethodInfo mi = FindMethod(t, objModule.MethodName, objModule.Parameter);
                        if (mi != null)
                        {
                            if (objModule.IsParameter)
                                mi.Invoke(obj, objModule.Parameter.Split(','));
                            else
                                mi.Invoke(obj, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Find method in class.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="name"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private static MethodInfo FindMethod(Type t, string name, string parameter)
        {
            MethodInfo[] methods = t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MethodInfo m in methods)
            {
                if (m.Name == name)
                {
                    if (string.IsNullOrEmpty(parameter))
                        return m;
                    else
                    {
                        if (m.GetParameters().Length == parameter.Split(',').Length)
                            return m;
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// Invoke method support navigation.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void InvokeMethod(Type t, object obj, NavBarLinkEventArgs e)
        {
            try
            {
                AppModule objModule = e.Link.Item.Tag as AppModule;
                if (objModule != null)
                {
                    if (objModule.IsMethodInvoke)
                    {
                        MethodInfo mi = FindMethod(t, objModule.MethodName, objModule.Parameter);
                        if (mi != null)
                        {
                            if (objModule.IsParameter)
                                mi.Invoke(obj, objModule.Parameter.Split(','));
                            else
                                mi.Invoke(obj, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModuleSelect(Type t, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (t == null) return;
                object ui = Activator.CreateInstance(t);
                if (ui == null) return;
                ChucNang cn = e.Link.Item.Tag as ChucNang;

                switch (t.Name)
                {
                    case "ucTuDienDuLieu":
                        ((Modules.ucTuDienDuLieu)ui).ChucNang = cn;
                        break;
                }

                switch (t.BaseType.Name)
                {
                    case "XtraForm":
                        XtraForm xForm = (XtraForm)ui;
                        foreach (Form fr in frmMain.Instance.xtraTabbedMdiManager.MdiParent.MdiChildren)
                        {
                            if (fr.Name == string.Format("{0}{1}", t.Name, cn.ModuleID))
                            {
                                fr.Focus();
                                return;
                            }
                        }
                        xForm.Name += cn.ModuleID;
                        InvokeMethod(t, xForm, e);
                        if (!string.IsNullOrEmpty(cn.LoaiChucNang.MaLoai))
                        {
                            if (cn.LoaiChucNang.MaLoai == "Popup")
                            {
                                xForm.Tag = cn;
                                xForm.Text = e.Link.Caption;
                                xForm.ShowDialog();
                            }
                            else
                            {
                                xForm.MdiParent = frmMain.Instance;
                                xForm.Tag = cn;
                                xForm.Text = e.Link.Caption;
                                xForm.Show();
                                xForm.Focus();
                            }
                        }
                        else
                        {
                            xForm.MdiParent = frmMain.Instance;
                            xForm.Tag = cn;
                            xForm.Text = e.Link.Caption;
                            xForm.Show();
                            xForm.Focus();
                        }
                        break;
                    case "Form":
                        Form form = (Form)ui;
                        foreach (Form fr in frmMain.Instance.xtraTabbedMdiManager.MdiParent.MdiChildren)
                        {
                            if (fr.Name == string.Format("{0}{1}", t.Name, cn.ModuleID))
                            {
                                fr.Focus();
                                return;
                            }
                        }
                        form.Name += cn.ModuleID;
                        InvokeMethod(t, form, e);
                        if (!string.IsNullOrEmpty(cn.LoaiChucNang.MaLoai))
                        {
                            if (cn.LoaiChucNang.MaLoai == "Popup")
                            {
                                form.Tag = cn;
                                form.Text = e.Link.Caption;
                                form.ShowDialog();
                            }
                            else
                            {
                                form.MdiParent = frmMain.Instance;
                                form.Tag = cn;
                                form.Text = e.Link.Caption;
                                form.Show();
                                form.Focus();
                            }
                        }
                        else
                        {
                            form.MdiParent = frmMain.Instance;
                            form.Tag = cn;
                            form.Text = e.Link.Caption;
                            form.Show();
                            form.Focus();
                        }
                        break;
                    case "XtraUserControl":
                        if (AppContainer != null)
                        {
                            if (!AppContainer.Controls.ContainsKey(string.Format("{0}{1}", t.Name, cn.ModuleID)))
                            {
                                XtraUserControl xc = (XtraUserControl)ui;
                                ////Phan quyen tung control
                                //bool result = false;
                                //DataServices.TaiKhoan.KiemTraPhanQuyenControl(UserInfo.UserID, xc.Name, ref result);
                                //if (result)
                                //{
                                //    MethodInfo mi = FindMethod(t, "KhongDuocPhepCapNhat", result.ToString());
                                //    if (mi != null)
                                //        mi.Invoke(xc, new string[] { result.ToString() });
                                //}

                                if (!AppContainer.Controls.Contains(xc))
                                {
                                    xc.Name = string.Format("{0}{1}", t.Name, cn.ModuleID);
                                    xc.Dock = DockStyle.Fill;
                                    xc.Tag = cn;
                                    AppContainer.Text = e.Link.Caption;
                                    InvokeMethod(t, xc, e);
                                    AppContainer.Controls.Add(xc);
                                    xc.BringToFront();
                                    xc.Focus();
                                }
                            }
                            else
                            {
                                AppContainer.Text = e.Link.Caption;
                                AppContainer.Controls[AppContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, cn.ModuleID))].BringToFront();
                                AppContainer.Controls[AppContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, cn.ModuleID))].Focus();
                            }
                        }
                        break;
                    case "UserControl":
                        Cursor.Current = Cursors.WaitCursor;
                        if (AppContainer != null)
                        {
                            if (!AppContainer.Controls.ContainsKey(string.Format("{0}{1}", t.Name, cn.ModuleID)))
                            {
                                UserControl uc = Activator.CreateInstance(t) as UserControl;
                                if (uc != null)
                                {
                                    if (!AppContainer.Controls.Contains(uc))
                                    {
                                        uc.Name = string.Format("{0}{1}", t.Name, cn.ModuleID);
                                        uc.Dock = DockStyle.Fill;
                                        uc.Tag = cn;
                                        AppContainer.Text = e.Link.Caption;
                                        InvokeMethod(t, uc, e);
                                        AppContainer.Controls.Add(uc);
                                        uc.BringToFront();
                                        uc.Focus();
                                    }
                                }
                            }
                            else
                            {
                                AppContainer.Text = e.Link.Caption;
                                AppContainer.Controls[AppContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, cn.ModuleID))].BringToFront();
                                AppContainer.Controls[AppContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, cn.ModuleID))].Focus();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                        break;
                    case "Object":
                        Object obj = Activator.CreateInstance(t) as Object;
                        if (obj != null)
                            InvokeMethod(t, obj, e);
                        break;
                    default:
                        break;
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Module select support treelist.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="pContainer"></param>
        /// <param name="e"></param>
        //private static void ModuleSelect(Type t, GroupControl pContainer, FocusedNodeChangedEventArgs e)
        //{
        //    try
        //    {
        //        ChucNang cn = e.Node.Tag as ChucNang;
        //        //if (cn == null)
        //        //{
        //        //    cn = new AppModule() { Id = (int)e.Node.GetValue("Id"), ModuleId = e.Node.GetValue("GUIName").ToString() };
        //        //    //if (e.Node.GetValue("TenPhuongThuc") != null)
        //        //    //    objModule.MethodName = e.Node.GetValue("TenPhuongThuc").ToString();
        //        //    //if (e.Node.GetValue("ThamSo") != null)
        //        //        cn.Parameter = e.Node.GetValue("ThamSo").ToString();
        //        //    if (e.Node.GetValue("KieuForm") != null)
        //        //        cn.LoaiChucNang.MaLoai = e.Node.GetValue("KieuForm").ToString();
        //        //    if (e.Node.GetValue("ModuleName") != null)
        //        //        cn.Caption = e.Node.GetValue("ModuleName").ToString();
        //        //    e.Node.Tag = cn;
        //        //}

        //        switch (t.BaseType.Name)
        //        {
        //            case "XtraForm":
        //                Cursor.Current = Cursors.WaitCursor;
        //                XtraForm xForm = Activator.CreateInstance(t) as XtraForm;
        //                if (xForm != null)
        //                {
        //                    foreach (Form fr in frmMain.Instance.xtraTabbedMdiManager.MdiParent.MdiChildren)
        //                    {
        //                        if (fr.Name == string.Format("{0}{1}", t.Name, cn.ModuleID))
        //                        {
        //                            fr.Focus();
        //                            return;
        //                        }
        //                    }
        //                    xForm.Name += cn.ModuleID;
        //                    InvokeMethod(t, xForm, e);
        //                    //if (cn.Module == null)
        //                    //    cn.Module = new ChucNang_Data().LayDuLieu(cn.ModuleID);
        //                    if (cn.LoaiChucNang != null)
        //                    {
        //                        if ((cn.LoaiChucNang.MdiForm ? "Mdi" : "") == "Popup")
        //                        {
        //                            xForm.Tag = cn;
        //                            xForm.Text = cn.ModuleName;
        //                            xForm.ShowDialog();
        //                        }
        //                        else
        //                        {
        //                            xForm.MdiParent = frmMain.Instance;
        //                            xForm.Tag = cn;
        //                            xForm.Text = cn.ModuleName;
        //                            xForm.Show();
        //                            xForm.Focus();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        xForm.MdiParent = frmMain.Instance;
        //                        xForm.Tag = cn;
        //                        xForm.Text = cn.ModuleName;
        //                        xForm.Show();
        //                        xForm.Focus();
        //                    }
        //                }
        //                Cursor.Current = Cursors.Default;
        //                break;
        //            case "Form":
        //                Cursor.Current = Cursors.WaitCursor;
        //                Form form = Activator.CreateInstance(t) as Form;
        //                if (form != null)
        //                {
        //                    foreach (Form fr in frmMain.Instance.xtraTabbedMdiManager.MdiParent.MdiChildren)
        //                    {
        //                        if (fr.Name == string.Format("{0}{1}", t.Name, cn.ModuleID))
        //                        {
        //                            fr.Focus();
        //                            return;
        //                        }
        //                    }
        //                    form.Name += cn.ModuleID;
        //                    InvokeMethod(t, form, e);
        //                    //if (cn.Module == null)
        //                    //    cn.Module = new ChucNang_Data().LayDuLieu(cn.ModuleID);
        //                    if (cn.LoaiChucNang != null)
        //                    {
        //                        if ((cn.LoaiChucNang.MdiForm ? "Mdi" : "") == "Popup")
        //                        {
        //                            form.Tag = cn;
        //                            form.Text = cn.ModuleName;
        //                            form.ShowDialog();
        //                        }
        //                        else
        //                        {
        //                            form.MdiParent = frmMain.Instance;
        //                            form.Tag = cn;
        //                            form.Text = cn.ModuleName;
        //                            form.Show();
        //                            form.Focus();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        form.MdiParent = frmMain.Instance;
        //                        form.Tag = cn;
        //                        form.Text = cn.ModuleName;
        //                        form.Show();
        //                        form.Focus();
        //                    }
        //                }
        //                Cursor.Current = Cursors.Default;
        //                break;
        //            case "XtraUserControl":
        //                Cursor.Current = Cursors.WaitCursor;
        //                if (!pContainer.Controls.ContainsKey(string.Format("{0}{1}", t.Name, cn.ModuleID)))
        //                {
        //                    XtraUserControl xc = Activator.CreateInstance(t) as XtraUserControl;
        //                    if (xc != null)
        //                    {
        //                        if (!pContainer.Controls.Contains(xc))
        //                        {
        //                            //if (cn.Module == null)
        //                            //    cn.Module = new ChucNang_Data().LayDuLieu(cn.ModuleID);
        //                            xc.Name = string.Format("{0}{1}", t.Name, cn.ModuleID);
        //                            xc.Dock = DockStyle.Fill;
        //                            xc.Tag = cn;
        //                            pContainer.Text = cn.ModuleName;
        //                            InvokeMethod(t, xc, e);
        //                            pContainer.Controls.Add(xc);
        //                            xc.BringToFront();
        //                            xc.Focus();
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    pContainer.Text = cn.ModuleName;
        //                    pContainer.Controls[pContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, cn.ModuleID))].BringToFront();
        //                    pContainer.Controls[pContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, cn.ModuleID))].Focus();
        //                }
        //                Cursor.Current = Cursors.Default;
        //                break;
        //            case "UserControl":
        //                Cursor.Current = Cursors.WaitCursor;
        //                if (!pContainer.Controls.ContainsKey(string.Format("{0}{1}", t.Name, cn.ModuleID)))
        //                {
        //                    UserControl uc = Activator.CreateInstance(t) as UserControl;
        //                    if (uc != null)
        //                    {
        //                        if (!pContainer.Controls.Contains(uc))
        //                        {
        //                            //if (cn.Module == null)
        //                            //    cn.Module = new ChucNang_Data().LayDuLieu(cn.ModuleID);
        //                            uc.Name = string.Format("{0}{1}", t.Name, cn.ModuleID);
        //                            uc.Dock = DockStyle.Fill;
        //                            uc.Tag = cn;
        //                            pContainer.Text = cn.ModuleName;
        //                            InvokeMethod(t, uc, e);
        //                            pContainer.Controls.Add(uc);
        //                            uc.BringToFront();
        //                            uc.Focus();
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    pContainer.Text = cn.ModuleName;
        //                    pContainer.Controls[pContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, cn.ModuleID))].BringToFront();
        //                    pContainer.Controls[pContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, cn.ModuleID))].Focus();
        //                }
        //                Cursor.Current = Cursors.Default;
        //                break;
        //            case "Object":
        //                Object obj = Activator.CreateInstance(t) as Object;
        //                if (obj != null)
        //                    InvokeMethod(t, obj, e);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

    }
}