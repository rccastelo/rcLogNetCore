using System;

namespace rcLogUtils
{
    public class Conversao
    {
        public static Int32 RetornarInt32(object pObjeto)
        {
            int? valor = RetornarInt32N(pObjeto);

            return valor.HasValue ? valor.Value : 0;
        } 

        public static Int32? RetornarInt32N(object pObjeto)
        {
            if (pObjeto == null) {
                return null;
            } else if (pObjeto == DBNull.Value) {
                return null;
            } else {
                return Convert.ToInt32(pObjeto);
            }
        }

        public static String RetornarString(object pObjeto)
        {
            if (pObjeto == null) {
                return null;
            } else if (pObjeto == DBNull.Value) {
                return null;
            } else {
                return pObjeto.ToString();
            }
        }
    }
}