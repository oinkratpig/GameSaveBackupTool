using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    /// <summary>
    /// A <see cref="TreeNode"/> that represents a file.
    /// </summary>
    public class TreeNodeFile : TreeNode
    {
        /// <summary>
        /// The system path of the save file.
        /// </summary>
        public string FilePath {
            get { return _filePath; }
            private set
            {
                _filePath = value;
                Text = Path.GetFileName(_filePath);
                ToolTipText = _filePath;
            }
        }

        // Fields
        private string _filePath = string.Empty;

        /* Constructor */
        public TreeNodeFile(string filePath)
        {
            FilePath = filePath;

        } // end constructor

    } // end class TreeNodeFile

} // end namespace