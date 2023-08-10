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
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Backups";

        } // end GetDefaultBackupDirectory

        public void Backup()
        {
            if (BackupDirectory == null) return;

            // Create backup directory if it doesn't already exist
            string backupGameDirectory = @$"{BackupDirectory}\{GameName}";
            Directory.CreateDirectory(backupGameDirectory);

            // Zip all save files to backup directory
            string dateTime = DateTime.Now.ToString().Replace("/", "_").Replace(":", "-");
            FileStream zipStream = File.Create(backupGameDirectory + @$"\save {dateTime}.zip");
            using (MemoryStream ms = new MemoryStream())
            {
                using (ZipArchive zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    foreach (string file in FileNames)
                        zip.CreateEntryFromFile(file, Path.GetFileName(file));
                }
                ms.WriteTo(zipStream);
            }
            zipStream.Close();

            // Done
            MessageBox.Show($"Backed up.");

        } // end Backup

    } // end class SaveFiles

} // end namespace