using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using PMS.Core.Manager;
using PMS_Data;
using PMS_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XuLyChung.XuLyDuLieu;
using XuLyGiaoDienDevExpress.Grid;

namespace PMS.Modules
{
    public partial class ucTuDienDuLieu : XtraUserControl
    {
        ChucNang _chucNang;

        public ucTuDienDuLieu()
        {
            InitializeComponent();
        }

        public ChucNang ChucNang
        {   //get => _chucNang;
            set
            {
                _chucNang = value;

                List<BaseLayoutItem> listLayout = new List<BaseLayoutItem>();

                int emptyItemX = 0;

                foreach (PMSModule module in _chucNang.ListModuleGetData)
                {
                    Plugin plugin = AppPlugin.Plugins.Find(module.GUIName);
                    if (plugin != null)
                    {
                        Type t = Type.GetType(plugin.FullName);
                        object obj = Activator.CreateInstance(t);
                        switch (t.Name)
                        {
                            case "ucGridLookupEdit":

                                ucGridLookupEdit ucGrid = (ucGridLookupEdit)obj;
                                UI_ControlGridLookupEdit moduleGrid = (UI_ControlGridLookupEdit)module;
                                ucGrid.ModuleControl = moduleGrid;
                                //ucGrid.TabIndex = 6;
                                ucGrid.EditValueChanged += new EventHandler(this.ucGridLookupEdit_EditValueChanged);

                                LayoutControlItem layout_control_item = new LayoutControlItem();
                                layout_control_item.Control = ucGrid;
                                layout_control_item.Location = new System.Drawing.Point(ucGrid.Location.X - 12, ucGrid.Location.Y - 12);
                                layout_control_item.Name = "layoutControlItem2";
                                layout_control_item.Size = new System.Drawing.Size(ucGrid.Size.Width + 4, ucGrid.Size.Height + 4);
                                layout_control_item.MaxSize = layout_control_item.Size;
                                layout_control_item.TextSize = new System.Drawing.Size(0, 0);
                                layout_control_item.TextVisible = false;

                                this.layout_control.Controls.Add(ucGrid);
                                listLayout.Add(layout_control_item);
                                emptyItemX += moduleGrid.Width;

                                break;
                        }
                    }
                }
                EmptySpaceItem empty_space_item = new EmptySpaceItem();
                empty_space_item.AllowHotTrack = false;
                empty_space_item.Location = new System.Drawing.Point(emptyItemX, 0);
                empty_space_item.Name = "empty_space_item";
                empty_space_item.Size = new System.Drawing.Size(215, 25);
                empty_space_item.TextSize = new System.Drawing.Size(0, 0);
                listLayout.Add(empty_space_item);
                this.layout_control_group.Items.AddRange(listLayout.ToArray());
            }
        }

        private void ucTuDienDuLieu_Load(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.ExecQueryStore("sp_UI_GridView_LayTheoMa", new SqlParameter("@MaGridView", _chucNang.MaGridView));
            DataRow dr = dt.Rows[0];

            #region Init GridView
            AppGridView.Init(gridViewDuLieu
                , (bool)XuLyKieuDuLieu.ThayTheNull(dr["MultiSelect"], typeof(bool))
                , (string)XuLyKieuDuLieu.ThayTheNull(dr["MultiSelectMode"], typeof(string))
                , (bool)XuLyKieuDuLieu.ThayTheNull(dr["ShowDetailButtons"], typeof(bool))
                , (bool)XuLyKieuDuLieu.ThayTheNull(dr["ShowGroupPanel"], typeof(bool))
                , (int)XuLyKieuDuLieu.ThayTheNull(dr["WordWrapHeader"], typeof(int))
                , (string)XuLyKieuDuLieu.ThayTheNull(dr["NewItemRowText"], typeof(string))
                , (string)XuLyKieuDuLieu.ThayTheNull(dr["GroupPanelText"], typeof(string))
                , (string)XuLyKieuDuLieu.ThayTheNull(dr["ColumnFields"], typeof(string))
                , (string)XuLyKieuDuLieu.ThayTheNull(dr["ColumnNames"], typeof(string))
                , (string)XuLyKieuDuLieu.ThayTheNull(dr["ColumnWidths"], typeof(string))
                , (string)XuLyKieuDuLieu.ThayTheNull(dr["HideFields"], typeof(string))
                , (string)XuLyKieuDuLieu.ThayTheNull(dr["ReadOnlyFields"], typeof(string))
                , (string)XuLyKieuDuLieu.ThayTheNull(dr["FixedFields"], typeof(string))
                , (string)XuLyKieuDuLieu.ThayTheNull(dr["FixedStyle"], typeof(string))
            );

            dt = DataProvider.ExecQueryStore("sp_UI_GridView_AlignHeader_LayTheoMa", new SqlParameter("@MaGridView", _chucNang.MaGridView));
            foreach (DataRow row in dt.Rows)
            {
                AppGridView.AlignHeader(gridViewDuLieu
                    , (string)XuLyKieuDuLieu.ThayTheNull(row["AlignHeaders"], typeof(string))
                    , (string)XuLyKieuDuLieu.ThayTheNull(row["AlignStyle"], typeof(string))
                );
            }
            #endregion
        }

        private void ucGridLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            #region Init data
            bsDuLieu.DataSource = DataProvider.ExecQueryStore(_chucNang.SelectStore, ((PMSEventArgs)e).ListParameter);
            #endregion
        }
    }
}

