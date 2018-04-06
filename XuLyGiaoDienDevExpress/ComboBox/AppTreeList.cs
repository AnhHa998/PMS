using AppSupport;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System.Windows.Forms;

namespace XuLyGiaoDienDevExpress.ComboBox
{
    public static class AppTreeList
    {
        /// <summary>
        /// Thiết lập cấu hình TreeList
        /// </summary>
        /// <param name="tree">TreeList cần khởi gán</param>
        /// <param name="showFields">Tên các cột của datasource</param>
        /// <param name="showFieldNames">Tên các cột hiển thị</param>
        /// <param name="columnWidth">Độ rộng các cột</param>
        /// <param name="keyFieldName">Tên cột làm khóa</param>
        /// <param name="parentFieldName">Tên cột liên kết với node chứa nó</param>
        public static void Init(TreeList tree, string[] showFields, string[] showFieldNames, int[] columnWidth
            , string keyFieldName, string parentFieldName)
        {
            TreeListColumn treeCol;
            for (int i = 0; i < showFields.Length; i++)
            {
                treeCol = new TreeListColumn();
                treeCol.Caption = showFieldNames[i];
                treeCol.FieldName = showFields[i];
                treeCol.Name = "treeCol" + (i + 1);
                treeCol.Width = columnWidth[i];
                treeCol.Visible = true;
                treeCol.VisibleIndex = 0;
                tree.Columns.Add(treeCol);
            }
            tree.KeyFieldName = keyFieldName;
            tree.ParentFieldName = parentFieldName;
        }

        /// <summary>
        /// Duyệt TreeListNode và các TreeListNode con của nó
        /// </summary>
        /// <param name="node">TreeListNode cần duyệt</param>
        /// <param name="function">Delegate tới hàm cần thực hiện thao tác</param>
        public static void VisitNode (TreeListNode node, ConTroHam.void_object function)
        {
            function(node);
            foreach (TreeListNode nChild in node.Nodes)
            {
                VisitNode(nChild, function);
            }
        }

        /// <summary>
        /// Duyệt toàn bộ TreeList
        /// </summary>
        /// <param name="tree">TreeList cần duyệt</param>
        /// <param name="function">Delegate tới hàm cần thực hiện thao tác</param>
        public static void VisitTree(TreeList tree, ConTroHam.void_object function)
        {
            foreach (TreeListNode nRoot in tree.Nodes)
            {
                VisitNode(nRoot, function);
            }
        }

        /// <summary>
        /// Check node con
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        public static void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        
        /// <summary>
        /// Check node cha
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        public static void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }
    }
}
