using System.IO;
using System.Collections.Generic;
using System;

namespace IOSerialize
{
    public static class Common
    {
        public static List<DirectoryInfo> GetAllDir(string rootPath)
        {
            if (!Directory.Exists(rootPath))
            {
                return new List<DirectoryInfo>();
            }

            List<DirectoryInfo> direList = new List<DirectoryInfo>();
            DirectoryInfo directory = new DirectoryInfo(rootPath);
            direList.Add(directory);
            GetChild(direList, directory);

            return direList;
        }

        private static List<DirectoryInfo> GetChild(List<DirectoryInfo> direList, DirectoryInfo directoryCurrent)
        {
            var childArray = directoryCurrent.GetDirectories();
            if (childArray != null && childArray.Length > 0)
            {
                direList.AddRange(childArray);
                foreach (var child in childArray)
                {
                    GetChild(direList, child);
                }
            }
            return direList;
        }
    }
}
