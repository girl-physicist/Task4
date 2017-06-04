using System;
using System.IO;
using System.Threading;

namespace WatcherService
{
  public  class Logger
    {
        private readonly FileSystemWatcher _watcher;
        private readonly object _obj = new object();
        private bool _enabled = true;
            public Logger()
            {
                _watcher = new FileSystemWatcher("C:\\Temp");
                _watcher.Deleted += Watcher_Deleted;
                _watcher.Created += Watcher_Created;
                _watcher.Changed += Watcher_Changed;
                _watcher.Renamed += Watcher_Renamed;
            }

            public void Start()
            {
                _watcher.EnableRaisingEvents = true;
                while (_enabled)
                {
                    Thread.Sleep(1000);
                }
            }
            public void Stop()
            {
                _watcher.EnableRaisingEvents = false;
                _enabled = false;
            }
            // переименование файлов
            private void Watcher_Renamed(object sender, RenamedEventArgs e)
            {
                string fileEvent = "renamed to " + e.FullPath;
                string filePath = e.OldFullPath;
                RecordEntry(fileEvent, filePath);
            }
            // изменение файлов
            private void Watcher_Changed(object sender, FileSystemEventArgs e)
            {
                string fileEvent = "amended";
                string filePath = e.FullPath;
                RecordEntry(fileEvent, filePath);
            }
            // создание файлов
            private void Watcher_Created(object sender, FileSystemEventArgs e)
            {
                string fileEvent = "created";
                string filePath = e.FullPath;
                RecordEntry(fileEvent, filePath);
            }
            // удаление файлов
            private void Watcher_Deleted(object sender, FileSystemEventArgs e)
            {
                string fileEvent = "deleted";
                string filePath = e.FullPath;
                RecordEntry(fileEvent, filePath);
            }

            private void RecordEntry(string fileEvent, string filePath)
            {
                lock (_obj)
                {
                    using (StreamWriter writer = new StreamWriter("C:\\templog.txt", true))
                    {
                        writer.WriteLine($"{DateTime.Now:dd/MM/yyyy hh:mm:ss} file {filePath} was {fileEvent}");
                        writer.Flush();
                    }
                }
            }
        
    }
}
