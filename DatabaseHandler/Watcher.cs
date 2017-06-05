using System.CodeDom;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace DatabaseHandler
{
   public class Watcher
    {
        private Recorder _recorder;
        private FileSystemWatcher _fileWatcher;
        private Task _task;
       
        public Watcher()
        {
            _recorder = new Recorder();
            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.Path = ConfigurationManager.AppSettings["Path1"];
            _fileWatcher.Filter = "*.csv";
            _fileWatcher.NotifyFilter = NotifyFilters.FileName;

            _fileWatcher.Changed += OnChanged;
            _fileWatcher.Created +=OnChanged;
            _fileWatcher.EnableRaisingEvents = true;
        }
      
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            _task = new Task(() => CallParse(source, e));
            _task.Start();
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
