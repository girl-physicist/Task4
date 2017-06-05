using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DatabaseHandler;

namespace ConsoleClient
{
   public class ClientServer
    {
        private Logger _logger;
        private Watcher _watcher;
        public  void OnStart()
        {
            _watcher = new Watcher();
            _logger = new Logger();
            Thread loggerThread = new Thread(_logger.Start);
            loggerThread.Start();
        }
        public void OnStop()
        {
            _watcher.Dispose();
            _logger.Stop();
            Thread.Sleep(1000);
        }
    }
}
