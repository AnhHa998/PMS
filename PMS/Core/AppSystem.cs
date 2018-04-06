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
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using XuLyChung.XuLyHinhAnh;

namespace PMS.Core
{
    public class AppSystem
    {

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
            AppModule objModule = e.Item.Tag as AppModule;
            if (objModule != null)
            {
                foreach (Form fr in frmMain.Instance.xtraTabbedMdiManager.MdiParent.MdiChildren)
                {
                    if (fr.Name == string.Format("{0}{1}", t.Name, objModule.Id))
                    {
                        fr.Focus();
                        return;
                    }
                }
                //Create instance form
                switch (t.BaseType.Name)
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
                            xfrm.Name += objModule.Id;
                            InvokeMethod(xfrm, t, objModule);
                            if (objModule.Type == "Popup")
                                xfrm.ShowDialog();
                            else
                            {
                                if (objModule.Module == null)
                                    objModule.Module = new ChucNang_Data().LayDuLieu(objModule.Id);
                                xfrm.MdiParent = frmMain.Instance;
                                xfrm.Tag = objModule;
                                xfrm.Text = e.Item.Caption;
                                xfrm.Show();
                                xfrm.Focus();
                            }
                        }
                        break;
                    case "Form":
                        Form frm = Activator.CreateInstance(t) as Form;
                        if (frm != null)
                        {
                            frm.Name += objModule.Id;
                            InvokeMethod(frm, t, objModule);
                            if (objModule.Type == "Popup")
                                frm.ShowDialog();
                            else
                            {
                                if (objModule.Module == null)
                                    objModule.Module = new ChucNang_Data().LayDuLieu(objModule.Id);
                                frm.MdiParent = frmMain.Instance;
                                frm.Tag = objModule;
                                frm.Text = e.Item.Caption;
                                frm.Show();
                                frm.Focus();
                            }
                        }
                        break;
                    case "Object":
                        Object obj = Activator.CreateInstance(t) as Object;
                        if (obj != null)
                            InvokeMethod(obj, t, objModule);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Item Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Item.Tag == null)
                return;
            AppModule objModule = e.Item.Tag as AppModule;
            if (objModule != null)
            {
                Plugin plugin = AppPlugin.Plugins.Find(objModule.ModuleId);
                if (plugin != null)
                {
                    Type t = Type.GetType(plugin.FullName);
                    if (t != null)
                        LoadItemModule(t, e);
                    else
                    {
                        Type tf = Assembly.LoadFrom(plugin.AssemblyPath).GetType(plugin.FullName);
                        if (tf != null)
                            LoadItemModule(tf, e);
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
        //private void NavItemClick(object sender, NavBarLinkEventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    AppModule objModule = e.Link.Item.Tag as AppModule;
        //    if (objModule != null)
        //    {
        //        Plugin plugin = AppPlugin.Plugins.Find(objModule.ModuleId);
        //        if (plugin != null)
        //        {
        //            Type t = Type.GetType(plugin.FullName);
        //            if (t != null)
        //                ModuleSelect(t, e);
        //            else
        //            {
        //                Type tf = Assembly.LoadFrom(plugin.AssemblyPath).GetType(plugin.FullName);
        //                if (tf != null)
        //                    ModuleSelect(tf, e);
        //            }
        //        }
        //    }
        //    Cursor.Current = Cursors.Default;
        //}


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
                List<ChucNang> dsTab = q.DsChucNang.FindAll(cn => cn.LoaiChucNang.MaLoai == 1 && cn.TrangThai);
                foreach (ChucNang cnTab in dsTab)
                {
                    //Add Page:
                    RibbonPage page = new RibbonPage(cnTab.TenChucNang) { Name = string.Format("ribbonPage{0}", cnTab.MaChucNang) };
                    frmMain.Instance.ribbon.Pages.Add(page);
                    //Add PageGroup:
                    List<ChucNang> dsGroup = q.DsChucNang.FindAll(cn => cn.LoaiChucNang.MaLoai == 2 && cn.ChucNangCha.MaChucNang == cnTab.MaChucNang && cn.TrangThai);
                    foreach (ChucNang cnGroup in dsGroup)
                    {
                        RibbonPageGroup group = new RibbonPageGroup(cnGroup.TenChucNang) { Name = string.Format("ribbonPageGroup{0}", cnGroup.MaChucNang), AllowTextClipping = false };
                        page.Groups.Add(group);
                        //Add Item:
                        List<ChucNang> dsItem = q.DsChucNang.FindAll(cn => cn.LoaiChucNang.MaLoai == 3 && cn.ChucNangCha.MaChucNang == cnGroup.MaChucNang && cn.TrangThai);
                        foreach (ChucNang cnItem in dsItem)
                        {
                            //RibbonPageGroup item = new RibbonPageGroup(cnItem.TenChucNang) { Name = string.Format("ribbonPageGroup{0}", cnItem.MaChucNang), AllowTextClipping = false };
                            //page.Groups.Add(item);
                            if (cnItem.HinhAnh != null && !cnItem.HinhAnh.Equals(DBNull.Value))
                            {
                                frmMain.Instance.LimageCollection.AddImage(cnItem.HinhAnh);
                            }
                            BarButtonItem item = new BarButtonItem(frmMain.Instance.ribbon.Manager, cnItem.TenChucNang)
                            {
                                Name = string.Format("barButtonItem{0}", cnItem.MaChucNang),
                                Tag = new AppModule()
                                {
                                    Id = cnItem.MaChucNang,
                                    ModuleId = cnItem.TenForm,
                                    Caption = cnItem.TenChucNang,
                                    Type = cnItem.LoaiChucNang.MdiForm ? "Mdi" : ""
                                    //, MethodName = iModule["TenPhuongThuc"].ToString()
                                    //, Parameter = iModule["ThamSo"].ToString()
                                },
                                Hint = cnItem.TenChucNang,
                                Description = cnItem.TenChucNang
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
            //    RibbonPage page = new RibbonPage(pModule["TenChucNang"].ToString()) { Name = string.Format("ribbonPage{0}", pModule["ID"]) };
            //    frmMain.Instance.ribbon.Pages.Add(page);
            //    //Add PageGroup
            //    foreach (DataRow gModule in dt.Select(string.Format("PhanLoai='{0}' AND TrangThai={1} AND ParentID={2}", "Group", 1, pModule["ID"]), "ThuTu ASC"))
            //    {
            //        RibbonPageGroup group = new RibbonPageGroup(gModule["TenChucNang"].ToString()) { Name = string.Format("ribbonPageGroup{0}", gModule["ID"]), AllowTextClipping = false };
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
            //                , iModule["TenChucNang"].ToString()) {
            //                    Name = string.Format("barButtonItem{0}", iModule["ID"])
            //                    , Tag = new AppModule() { Id = (int)iModule["ID"]
            //                    , ModuleId = iModule["TenForm"].ToString()
            //                    , Caption = iModule["TenChucNang"].ToString()
            //                    , Type = iModule["KieuForm"].ToString()
            //                    //, MethodName = iModule["TenPhuongThuc"].ToString()
            //                    //, Parameter = iModule["ThamSo"].ToString()
            //                }
            //                , Hint = iModule["TenChucNang"].ToString()
            //                , Description = iModule["TenChucNang"].ToString() };
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

        /// <summary>
        /// Module select support treelist.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="pContainer"></param>
        /// <param name="e"></param>
        private static void ModuleSelect(Type t, GroupControl pContainer, FocusedNodeChangedEventArgs e)
        {
            try
            {
                AppModule objModule = e.Node.Tag as AppModule;
                if (objModule == null)
                {
                    objModule = new AppModule() { Id = (int)e.Node.GetValue("Id"), ModuleId = e.Node.GetValue("TenForm").ToString() };
                    //if (e.Node.GetValue("TenPhuongThuc") != null)
                    //    objModule.MethodName = e.Node.GetValue("TenPhuongThuc").ToString();
                    //if (e.Node.GetValue("ThamSo") != null)
                        objModule.Parameter = e.Node.GetValue("ThamSo").ToString();
                    if (e.Node.GetValue("KieuForm") != null)
                        objModule.Type = e.Node.GetValue("KieuForm").ToString();
                    if (e.Node.GetValue("TenChucNang") != null)
                        objModule.Caption = e.Node.GetValue("TenChucNang").ToString();
                    e.Node.Tag = objModule;
                }

                switch (t.BaseType.Name)
                {
                    case "XtraForm":
                        Cursor.Current = Cursors.WaitCursor;
                        XtraForm xForm = Activator.CreateInstance(t) as XtraForm;
                        if (xForm != null)
                        {
                            foreach (Form fr in frmMain.Instance.xtraTabbedMdiManager.MdiParent.MdiChildren)
                            {
                                if (fr.Name == string.Format("{0}{1}", t.Name, objModule.Id))
                                {
                                    fr.Focus();
                                    return;
                                }
                            }
                            xForm.Name += objModule.Id;
                            InvokeMethod(t, xForm, e);
                            if (objModule.Module == null)
                                objModule.Module = new ChucNang_Data().LayDuLieu(objModule.Id);
                            if (!string.IsNullOrEmpty(objModule.Type))
                            {
                                if (objModule.Type == "Popup")
                                {
                                    xForm.Tag = objModule;
                                    xForm.Text = objModule.Caption;
                                    xForm.ShowDialog();
                                }
                                else
                                {
                                    xForm.MdiParent = frmMain.Instance;
                                    xForm.Tag = objModule;
                                    xForm.Text = objModule.Caption;
                                    xForm.Show();
                                    xForm.Focus();
                                }
                            }
                            else
                            {
                                xForm.MdiParent = frmMain.Instance;
                                xForm.Tag = objModule;
                                xForm.Text = objModule.Caption;
                                xForm.Show();
                                xForm.Focus();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                        break;
                    case "Form":
                        Cursor.Current = Cursors.WaitCursor;
                        Form form = Activator.CreateInstance(t) as Form;
                        if (form != null)
                        {
                            foreach (Form fr in frmMain.Instance.xtraTabbedMdiManager.MdiParent.MdiChildren)
                            {
                                if (fr.Name == string.Format("{0}{1}", t.Name, objModule.Id))
                                {
                                    fr.Focus();
                                    return;
                                }
                            }
                            form.Name += objModule.Id;
                            InvokeMethod(t, form, e);
                            if (objModule.Module == null)
                                objModule.Module = new ChucNang_Data().LayDuLieu(objModule.Id);
                            if (!string.IsNullOrEmpty(objModule.Type))
                            {
                                if (objModule.Type == "Popup")
                                {
                                    form.Tag = objModule;
                                    form.Text = objModule.Caption;
                                    form.ShowDialog();
                                }
                                else
                                {
                                    form.MdiParent = frmMain.Instance;
                                    form.Tag = objModule;
                                    form.Text = objModule.Caption;
                                    form.Show();
                                    form.Focus();
                                }
                            }
                            else
                            {
                                form.MdiParent = frmMain.Instance;
                                form.Tag = objModule;
                                form.Text = objModule.Caption;
                                form.Show();
                                form.Focus();
                            }
                        }
                        Cursor.Current = Cursors.Default;
                        break;
                    case "XtraUserControl":
                        Cursor.Current = Cursors.WaitCursor;
                        if (!pContainer.Controls.ContainsKey(string.Format("{0}{1}", t.Name, objModule.Id)))
                        {
                            XtraUserControl xc = Activator.CreateInstance(t) as XtraUserControl;
                            if (xc != null)
                            {
                                if (!pContainer.Controls.Contains(xc))
                                {
                                    if (objModule.Module == null)
                                        objModule.Module = new ChucNang_Data().LayDuLieu(objModule.Id);
                                    xc.Name = string.Format("{0}{1}", t.Name, objModule.Id);
                                    xc.Dock = DockStyle.Fill;
                                    xc.Tag = objModule;
                                    pContainer.Text = objModule.Caption;
                                    InvokeMethod(t, xc, e);
                                    pContainer.Controls.Add(xc);
                                    xc.BringToFront();
                                    xc.Focus();
                                }
                            }
                        }
                        else
                        {
                            pContainer.Text = objModule.Caption;
                            pContainer.Controls[pContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, objModule.Id))].BringToFront();
                            pContainer.Controls[pContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, objModule.Id))].Focus();
                        }
                        Cursor.Current = Cursors.Default;
                        break;
                    case "UserControl":
                        Cursor.Current = Cursors.WaitCursor;
                        if (!pContainer.Controls.ContainsKey(string.Format("{0}{1}", t.Name, objModule.Id)))
                        {
                            UserControl uc = Activator.CreateInstance(t) as UserControl;
                            if (uc != null)
                            {
                                if (!pContainer.Controls.Contains(uc))
                                {
                                    if (objModule.Module == null)
                                        objModule.Module = new ChucNang_Data().LayDuLieu(objModule.Id);
                                    uc.Name = string.Format("{0}{1}", t.Name, objModule.Id);
                                    uc.Dock = DockStyle.Fill;
                                    uc.Tag = objModule;
                                    pContainer.Text = objModule.Caption;
                                    InvokeMethod(t, uc, e);
                                    pContainer.Controls.Add(uc);
                                    uc.BringToFront();
                                    uc.Focus();
                                }
                            }
                        }
                        else
                        {
                            pContainer.Text = objModule.Caption;
                            pContainer.Controls[pContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, objModule.Id))].BringToFront();
                            pContainer.Controls[pContainer.Controls.IndexOfKey(string.Format("{0}{1}", t.Name, objModule.Id))].Focus();
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
                XtraMessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}