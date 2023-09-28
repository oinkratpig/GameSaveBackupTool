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
    public class TreeNodeFolder : TreeNode, IGameFolder
    {
        /// <summary>
        /// Name of the folder.
        /// </summary>
        public string FolderName { get; private set; }

        /// <summary>
        /// Paths of ever file inside of the folder.
        /// </summary>
        public List<string> FilePaths
        {
            get
            {
                List<string> paths = new List<string>();
                foreach (TreeNode node in Nodes)
                    if (node is TreeNodeFile)
                        paths.Add(((TreeNodeFile)node).FilePath);
                return paths;
            }
        }

        /* Constructor */
        public TreeNodeFolder(string folderName)
        {
            FolderName = folderName;
            Text = folderName;
            ToolTipText = "Folder";

            BackColor = Color.LightGoldenrodYellow;

        } // end constructor

    } // end class TreeNodeFolder

} // end namespace