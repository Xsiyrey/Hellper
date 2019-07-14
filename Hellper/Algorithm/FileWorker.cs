using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hellper.Algorithm
{
    public class FileWorker
    {
        /// <summary>
        /// Get files from catalog
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="searchPattern">Pattern</param>
        /// <returns></returns>
        public static IEnumerable<string> FindFilesPath(string path, string searchPattern)
        {
            if (!Directory.Exists(path))
                yield break;
            List<string> files = new List<string>();
            try
            {
                string[] searchPatterns = searchPattern.Split('|');
                foreach (string sp in searchPatterns)
                    files.AddRange(Directory.GetFiles(path, sp));
            }
            catch (Exception)
            {
                yield break;
            }

            foreach (string file in files)
            {
                yield return file;
            }

            string[] directories;
            try
            {
                directories = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException)
            {
                yield break;
            }

            foreach (string subdirectory in directories)
            {
                foreach (string file in FindFilesPath(subdirectory, searchPattern))
                {
                    yield return file;
                }
            }
        }
    }
}
