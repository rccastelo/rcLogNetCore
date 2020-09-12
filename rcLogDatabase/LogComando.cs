using System;
using System.Data;
using System.Data.Common;

namespace rcLogDatabase
{
    public class LogComando
    {
        public ILogComando cmd = null;

        public void IncluirParametro(string pNome, DbType? pTipo, int? pTamanho, object pValor)
        {
            Type tipo;
            DbType tipoDB;
            int? tamanho;

            tipo = pValor.GetType();

            tamanho = pTamanho.HasValue ? (int)pTamanho : int.MaxValue;

            if (pTipo.HasValue) {
                tipoDB = (DbType)pTipo;
            } else {
                if (tipo == typeof(String)) {
                    tipoDB = DbType.String;
                } else if (tipo == typeof(Int64)) {
                    tipoDB = DbType.Int64;
                    tamanho = sizeof(Int64);
                } else if (tipo == typeof(Int32)) {
                    tipoDB = DbType.Int32;
                    tamanho = sizeof(Int32);
                } else if (tipo == typeof(Int16)) {
                    tipoDB = DbType.Int16;
                    tamanho = sizeof(Int16);
                } else if (tipo == typeof(long)) {
                    tipoDB = DbType.Int64;
                    tamanho = sizeof(Int64);
                } else if (tipo == typeof(int)) {
                    tipoDB = DbType.Int32;
                    tamanho = sizeof(Int32);
                } else if (tipo == typeof(short)) {
                    tipoDB = DbType.Int16;
                    tamanho = sizeof(Int16);
                } else if (tipo == typeof(double)) {
                    tipoDB = DbType.Double;
                    tamanho = sizeof(double);
                } else if (tipo == typeof(decimal)) {
                    tipoDB = DbType.Decimal;
                    tamanho = sizeof(decimal);
                } else if (tipo == typeof(byte)) {
                    tipoDB = DbType.Byte;
                    tamanho = sizeof(byte);
                } else if (tipo == typeof(bool)) {
                    tipoDB = DbType.Boolean;
                    tamanho = sizeof(bool);
                } else if (tipo == typeof(DateTime)) {
                    tipoDB = DbType.DateTime;
                    tamanho = null;
                } else {
                    tipoDB = DbType.Object;
                }
            }

            cmd.IncluirParametro(pNome, tipoDB, tamanho, pValor);
        }

        public void ExcluirParametros()
        {
            this.cmd.ExcluirParametros();
        }

        public void Comando(string pComando)
        {
            this.cmd.Comando(pComando);
        }

        public void Tempo(int pTempoConexao)
        {
            this.cmd.Tempo(pTempoConexao);
        }

        public int? ExecutarComando()
        {
            return this.cmd.ExecutarComando();
        }

        public object ExecutarComandoObjeto()
        {
            return this.cmd.ExecutarComandoObjeto();
        }

        public DbDataReader ExecutarComandoLista()
        {
            return this.cmd.ExecutarComandoLista();
        }

        public int? ExecutarProcedimento()
        {
            return this.cmd.ExecutarProcedimento();
        }

        public object ExecutarProcedimentoObjeto()
        {
            return this.cmd.ExecutarProcedimentoObjeto();
        }

        public DbDataReader ExecutarProcedimentoLista()
        {
            return this.cmd.ExecutarProcedimentoLista();
        }
    }
}