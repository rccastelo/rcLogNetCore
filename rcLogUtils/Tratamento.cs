using System;

namespace rcLogUtils
{
    public static class Tratamento
    {
        public static string TratarStringNuloBranco(string pValor) {
            string retorno;

            if (pValor == null) {
                retorno = null;
            } else {
                retorno = pValor.Trim();

                if (retorno == string.Empty) {
                    retorno = null;
                }
            }

            return retorno;
        }
    }
}
