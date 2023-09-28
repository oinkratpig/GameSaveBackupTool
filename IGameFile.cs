using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    /// <summary>
    /// A specific filepath to backup every time a backup is made.
    /// </summary>
    internal interface IGameFile
    {
        public string FilePath { get; }

    } // end interface IGameFile

} // end namespace