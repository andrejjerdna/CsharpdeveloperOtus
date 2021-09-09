using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Events
{
    /// <summary>
    /// Просмотрщик каталога.
    /// </summary>
    public sealed class CatalogWatcher
    {
        private const string TempFileName = "temp.dat";
        private readonly string _path;
        private readonly Func<string, float> _getFileSize;

        public event EventHandler<FileArgs>? FileFound;
        public event EventHandler<FileArgs>? MaxFileFound;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="catalogPath"></param>
        public CatalogWatcher(string catalogPath)
        {
            _path = catalogPath;
            _getFileSize = GetSizeObject;
        }
        
        /// <summary>
        /// Поиск файлов в указанной папке.
        /// </summary>
        public void SearchingFilesStart()
        {
            var files = Directory.GetFiles(_path);
            var maxFile = files.GetMax(_getFileSize);

            foreach (var file in files)
            {
                var fileArgs = new FileArgs
                {
                    FileName = Path.GetFileName(file)
                };

                OnFileFound(fileArgs);

                if (file == maxFile)
                {
                    OnMaxFileFound(fileArgs);
                    break;
                }
            }
        }
        
        /// <summary>
        /// Файл найден.
        /// </summary>
        /// <param name="e"></param>
        private void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }
        
        /// <summary>
        /// Найден максимальный файл.
        /// </summary>
        /// <param name="e"></param>
        private void OnMaxFileFound(FileArgs e)
        {
            MaxFileFound?.Invoke(this, e);
        }
        
        /// <summary>
        /// Получение самого большого файла из папки на основе размера файла, в который он сериализуется.
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private float GetSizeObject<T>(T? obj)
        {
            if (obj == null)
                return 0f;
            
            var formatter = new BinaryFormatter();
            
            using (var fs = new FileStream(TempFileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }

            if (File.Exists(TempFileName))
            {
                var lenght = File.ReadAllBytes(TempFileName).Length;
                File.Delete(TempFileName);
                return lenght;
            }
            else
            {
                return 0f;
            }
        }
    }
}