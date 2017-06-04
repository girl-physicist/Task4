using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDAL.ContextFactory
{
   public interface IDataContextFactory<TContext>
   {
        TContext ContextObject { get; }
    }

}
