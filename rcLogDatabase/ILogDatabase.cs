namespace rcLogDatabase
{
    public interface ILogDatabase
    {
        LogComando Comando();

        void ConfirmarTransacao();

        void CancelarTransacao();
    }
}
