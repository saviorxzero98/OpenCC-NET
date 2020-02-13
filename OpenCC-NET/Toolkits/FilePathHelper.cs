using System;
using System.IO;

namespace OpenCC.NET.Toolkits
{
    /// <summary>
    /// File Path Converter
    /// </summary>
    public class FilePathHelper
    {
        public string BasePath { get; set; }

        public FilePathHelper()
        {
            BasePath = AppDomain.CurrentDomain.BaseDirectory;
        }
        public FilePathHelper(string basePath)
        {
            BasePath = basePath;
        }

        /// <summary>
        /// Get Absolute Path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetAbsolutePath(string path)
        {
            // Releation File Path
            if (path.StartsWith("~/") || path.StartsWith("~\\"))
            {
                path = path.Replace("~/", string.Empty).Replace("~\\", string.Empty);
            }

            // Combine Base Path
            path = CombinePath(BasePath, path);

            return Path.GetFullPath(path);
        }

        /// <summary>
        /// Combine Path
        /// </summary>
        /// <param name="parentPath"></param>
        /// <param name="childPath"></param>
        /// <returns></returns>
        public string CombinePath(string parentPath, string childPath)
        {
            // Combine Path
            string path = (Path.Combine(parentPath, childPath));

            // Directory Separator
            path = FormatDirectorySeparatorChar(path);

            return Path.GetFullPath(path);
        }

        /// <summary>
        /// Format Directory Separator
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string FormatDirectorySeparatorChar(string path)
        {
            // Directory Separator
            string slash = Path.DirectorySeparatorChar.ToString();
            path = path.Replace("\\", slash).Replace("/", slash);

            return Path.GetFullPath(path);
        }
    }
}
