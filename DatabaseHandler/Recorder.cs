namespace DatabaseHandler
{
   public class Recorder
    {
        private DatabaseHandler _dbHandler;
        private Parser _parser;
        public Recorder()
        {
            _dbHandler = new DatabaseHandler();
            _parser = new Parser();
        }
        public void SaveRecords(string path)
        {
            var records = _parser.ParseData(path);
            foreach (var record in records)
            {
                _dbHandler.AddToDatabase(record);
            }
        }
       }
}
