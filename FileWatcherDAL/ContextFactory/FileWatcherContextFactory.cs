using FileWatcherModel;

namespace FileWatcherDAL.ContextFactory
{
    public class FileWatcherContextFactory : IDataContextFactory<SaleInfoEntities>
    {
        public SaleInfoEntities ContextObject => new SaleInfoEntities();
    }
}
