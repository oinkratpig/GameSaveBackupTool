using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    /// <summary>
    /// A link to a folder.<br/>
    /// Backup targets all files within the folder at the time of backup.
    /// </summary>
    public interface IGameFolderLink
    {
        public string FolderPath { get; }

    } // end interface IGameFolder

} // end namespace