namespace FileWatcherDAL.ContextFactory
{
    public interface IDataContextFactory<TContext>
    {
        TContext ContextObject { get; }
    }
}
