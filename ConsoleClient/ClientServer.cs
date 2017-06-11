using FileWatcherManager;
using System.Threading;

namespace ConsoleClient
{
   public class ClientServer
    {
        private Logger _logger;
        
        public  void OnStart()
        {
            _logger = new Logger();
            Thread loggerThread = new Thread(_logger.Start);
            loggerThread.Start();
        }
        public void OnStop()
        {
           _logger.Stop();
            Thread.Sleep(1000);
        }
    }
}
