using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hellper.Algorithm
{
    class FileWorker
    {
        /// <summary>
        /// Получение файлов из каталога и подкаталогов
        /// </summary>
        /// <param name="path">Путь</param>
        /// <param name="searchPattern">Паттерн</param>
        /// <returns></returns>
        private IEnumerable<string> FindFilesPath(string path, string searchPattern)
        {
            string[] files;
            try
            {
                files = Directory.GetFiles(path, searchPattern);
            }
            catch (UnauthorizedAccessException)
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
