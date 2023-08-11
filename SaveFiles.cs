using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameSaveBackupTool
{
    public class SaveFiles
    {
        public static string? BackupDirectory;

        public string SaveDirectory { get; private set; }

        public string GameName { get; private set; }

        public List<string> FileNames { get; private set; }

        public SaveFiles(string directory, string gameName, List<string> fileNames)
        {
            SaveDirectory = directory;
            GameName = gameName;
            FileNames = fileNames;

        } // end constructor

        public static string GetDefaultBackupDirectory()
        {
            return ProgramSave.GetLocalPath() + @"Backups";

        } // end GetDefaultBackupDirectory

        public static string GetDefaultSaveName()
        {
            string dateTime = DateTime.Now.ToString().Replace("/", "_").Replace(":", "-");
            return $"save {dateTime}";

        } // end GetDefaultSaveName

        public void Backup(string? saveName)
        {
            if (BackupDirectory == null) return;

            // Output msg
            FormMain.outputText = $"({DateTime.Now}) Backing up...";

            // Invalid save name
            if (saveName != null)
                foreach (char ch in Path.GetInvalidFileNameChars())
                    if (saveName.Contains(ch))
                    {
                        FormMain.outputText += $"\r\nSave name \"{saveName}\" invalid. Using default name.";
                        saveName = null;
                        break;
                    }

            // Set save name
            if (string.IsNullOrWhiteSpace(saveName))
                saveName = GetDefaultSaveName();

            // Create backup directory if it doesn't already exist
            string backupGameDirectory = @$"{BackupDirectory}\{GameName}";
            Directory.CreateDirectory(backupGameDirectory);

            // Save name already taken
            if (File.Exists(backupGameDirectory + @$"\{saveName}.zip"))
                FormMain.outputText += $"\r\nSave name \"{saveName}\" already taken. Overwriting.";

            // Zip all save files to backup directory
            FileStream zipStream = File.Create(backupGameDirectory + @$"\{saveName}.zip");
            using (MemoryStream ms = new MemoryStream())
            {
                using (ZipArchive zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    foreach (string file in FileNames)
                    {
                        if (!File.Exists(file))
                            FormMain.outputText += $"\r\nNo file found \"{file}\".";
                        else
                            zip.CreateEntryFromFile(file, Path.GetFileName(file));
                    }
                }
                ms.WriteTo(zipStream);
            }
            zipStream.Close();

            // Done
            FormMain.outputText += "\r\nDone.";

        } // end Backup

    } // end class SaveFiles

} // end namespace