using System.Data;
using System.Data.Common;

namespace rcLogDatabase
{
    public interface ILogComando
    {
        void IncluirParametro(string pNome, DbType pTipo, int? pTamanho, object pValor);

        void ExcluirParametros();

        void Comando(string pComando);

        void Tempo(int pTempoConexao);

        int? ExecutarComando();

        object ExecutarComandoObjeto();

        DbDataReader ExecutarComandoLista();

        int? ExecutarProcedimento();

        object ExecutarProcedimentoObjeto();

        DbDataReader ExecutarProcedimentoLista();
    }
}