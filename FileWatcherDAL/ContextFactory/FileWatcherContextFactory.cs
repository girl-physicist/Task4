using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWatcherModel;


namespace FileWatcherDAL.ContextFactory
{
   public class FileWatcherContextFactory:IDataContextFactory<SaleInfoEntities>
    {
        public SaleInfoEntities ContextObject => new SaleInfoEntities();
    }
}
