using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace ConsoleApp1
{
    public class DocumentsReceiver
    {
        private FileSystemWatcher _fileSystemWatcher;
        private Timer _timer;

        public event Action DocumentsReady;
        public event Action TimedOut;

        public void Start(string targetDirectory, int waitingInterval)
        {
            _fileSystemWatcher = new FileSystemWatcher(targetDirectory);
            _fileSystemWatcher.Created += FileSystemWatcher_Changed;
            _fileSystemWatcher.EnableRaisingEvents = true;

            _timer = new Timer(waitingInterval);
            _timer.Elapsed += Changed;
            _timer.Start();
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            var dir = Directory.GetFiles(@"C:\Users\33pro\OneDrive\Рабочий стол\test")
                .Select(p => Path.GetFileNameWithoutExtension(p))
                .ToList();

            if (dir.Contains("Паспорт") && dir.Contains("Заявление") && dir.Contains("Фото"))
                DocumentsReady.Invoke();
        }

        void Changed(Object source, ElapsedEventArgs e)
        {
            TimedOut.Invoke();
        }
    }
}
