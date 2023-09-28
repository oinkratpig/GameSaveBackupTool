using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    /// <summary>
    /// A <see cref="TreeNode"/> that represents a folder.
    /// </summary>
    public class TreeNodeFolderLink : TreeNode, IGameFolderLink
    {
        /// <summary>
        /// Path to the save folder.
        /// </summary>
        public string FolderPath { get; private set; }

        /* Constructor */
        public TreeNodeFolderLink(string folderPath)
        {
            FolderPath = folderPath;
            Text = FolderLinkData.GetFolderName(folderPath);

            BackColor = Color.Orange;

            ToolTipText = $"Folder Link: Copies all files inside every backup.\n{folderPath}";

        } // end constructor

    } // end class TreeNodeFolderLink

} // end namespace