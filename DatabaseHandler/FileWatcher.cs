using System.CodeDom;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace FileWatcherManager
{
   public class FileWatcher
    {
        private readonly Recorder _recorder;
        private readonly FileSystemWatcher _fileWatcher;
        private Task _task;
       
        public FileWatcher()
        {
            _recorder = new Recorder();
            _fileWatcher = new FileSystemWatcher
            {
                Path = ConfigurationManager.AppSettings["Path1"],
                Filter = "*.csv",
                NotifyFilter = NotifyFilters.FileName,
                EnableRaisingEvents = true
            };
        }
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            _task = new Task(() => CallParse(source, e));
            _task.Start();
        }
        public void CallParse(object source, FileSystemEventArgs e)
        {
            var path = e.FullPath;
            _recorder.SaveRecords(path);
        }
        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}
