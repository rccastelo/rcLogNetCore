using rcLogDatabase;

namespace rcLogDataModels
{
    public class DataModel
    {
        protected readonly LogDatabase db;

        public DataModel() 
        {
            db = new LogDatabase();
        }
    }
}