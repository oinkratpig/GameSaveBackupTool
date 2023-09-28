﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    /// <summary>
    /// A folder contained in the archive.<br/>
    /// Used for organizing backup files.
    /// </summary>
    public interface IGameFolder
    {
        public string FolderName { get; }

    } // end interface IGameFolder

} // end namespace