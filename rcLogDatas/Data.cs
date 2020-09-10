using rcLogDatabase;

namespace rcLogDatas
{
    public abstract class Data
    {
        protected LogDatabase db;

        public Data(LogDatabase dbDataModel) 
        {
            this.db = dbDataModel;
        }
    }
}