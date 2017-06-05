using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService.DataBase
{
   public class Watcher
    {
        private Recorder _recorder;
        private FileSystemWatcher _fileWatcher;
        private Task task;

        public Watcher()
        {
            _recorder = new Recorder();
            _fileWatcher = new FileSystemWatcher("C:\\Temp");
            //_fileWatcher.Path = ConfigurationManager.AppSettings["Path"];
            //_fileWatcher.Filter = "*.csv";
            //_fileWatcher.NotifyFilter = NotifyFilters.FileName;

            _fileWatcher.Changed += OnChanged;
            _fileWatcher.Created +=OnChanged;
            _fileWatcher.EnableRaisingEvents = true;
        }
      
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            task = new Task(() => CallParse(source, e));
            task.Start();
        }
        public void CallParse(object source, FileSystemEventArgs e)
        {
            string path;
            path = e.FullPath;
            _recorder.SaveRecords(path);
        }
        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}
