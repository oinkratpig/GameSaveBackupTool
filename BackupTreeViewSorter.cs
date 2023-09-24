using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    public class BackupTreeViewSorter : System.Collections.IComparer
    {
        public int Compare(object? x, object? y)
        {
            TreeNode? tx = x as TreeNode;
            TreeNode? ty = y as TreeNode;

            if (tx == null || ty == null)
                return 0;

            // Folders before files
            if (tx is TreeNodeFolder && ty is TreeNodeFile)
                return -1;
            // Files after folders
            else if (tx is TreeNodeFile && ty is TreeNodeFolder)
                return 1;

            // Sort by name
            return tx.Text.CompareTo(ty.Text);

        } // end Compare

    } // end class BackupTreeViewSorter

} // end namespace