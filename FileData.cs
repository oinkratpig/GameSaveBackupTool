using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    public class FileData : GameData, IGameFile
    {
        public string FilePath { get; private set; }

        /* Constructor */
        public FileData(string path)
        {
            FilePath = path;

        } // end constructor

    } // end class FileData

} // end namespace