namespace rcLogDatabase
{
    public class LogDatabaseFactory
    {
        public static ILogDatabase Selecionar(string pTipoDB) {
            ILogDatabase logDatabase;

            switch (pTipoDB) {
                case "sqlserver":
                    logDatabase = new LogSqlServerDatabase();
                    break;
                case "mysql":
                    logDatabase = new LogMySqlDatabase();
                    break;
                default:
                    logDatabase = null;
                    break;
            }

            return logDatabase;
        }        
    }
}