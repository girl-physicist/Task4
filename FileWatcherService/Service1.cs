using System.ServiceProcess;
using System.Threading;
using FileWatcherService.DataBase;

namespace WatcherService
{
    public partial class Service1 : ServiceBase
    {
        private Logger _logger;
        private Watcher _watcher;
        public Service1()
        {
            InitializeComponent();
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            _watcher = new Watcher();
            _logger = new Logger();
            Thread loggerThread = new Thread(_logger.Start);
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            _watcher.Dispose();
            _logger.Stop();
            Thread.Sleep(1000);
        }
    }
}
