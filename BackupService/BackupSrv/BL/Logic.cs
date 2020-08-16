﻿using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Timers;

namespace BackupSrv.BL
{
    //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
    public static class Logic
    {
        private static Timer _timer;
        private static string _destination = @"D:\Temp";//!get path from config
        public static void Start()
        {
            var folders = GetFoldersForBackup();
            if (folders.Any())
            {
                //_destination = "";//get folder to backup from app.config
                folders.ForEach(f =>
                {
                    string folderName = new string(f.Reverse().TakeWhile(ch => ch != '\\').Reverse().ToArray());
                    string destDirName = $"{_destination}\\{folderName}";
                    DirectoryCopy(f, destDirName);
                });
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            

            // Get the subdirectories for the specified directory.
            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string path = Path.Combine(destDirName, file.Name);
                file.CopyTo(path, false);
            }

            //Copying subdirectories and their contents to new location.
            foreach (DirectoryInfo subDir in dirs)
            {
                string path = Path.Combine(destDirName, subDir.Name);
                DirectoryCopy(subDir.FullName, path);
            }
        }


        /// <summary>
        /// Get folders to be backuped from app.config
        /// </summary>
        private static List<string> GetFoldersForBackup()
        {
            var collection = ConfigurationManager.GetSection("BackupFromFolders") as NameValueCollection;
            List<string> folders = new List<string>();
            if (collection != null)
            {
                foreach (var key in collection.AllKeys)
                {
                    folders.Add(collection[key]);
                }

                return folders;
            }
            return null;
        }

        /// <summary>
        /// delete old backups
        /// </summary>
        private static bool ClearOldData()
        {
            return true;
        }
    }
}