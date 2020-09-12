using rcLogDatabase;

namespace rcLogDatas
{
    public abstract class Data
    {
        protected LogDatabase db;

        public Data(LogDatabase pDB) 
        {
            this.db = pDB;
        }
    }
}