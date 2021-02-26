using System;

namespace rcLogUtils
{
    public class Conversao
    {
        public static Int32 RetornarInt32(object objeto)
        {
            int? valor = RetornarInt32N(objeto);

            return valor.HasValue ? valor.Value : 0;
        } 

        public static Int32? RetornarInt32N(object objeto)
        {
            if (objeto == null) {
                return null;
            } else if (objeto == DBNull.Value) {
                return null;
            } else {
                return Convert.ToInt32(objeto);
            }
        }

        public static String RetornarString(object objeto)
        {
            if (objeto == null) {
                return null;
            } else if (objeto == DBNull.Value) {
                return null;
            } else {
                return objeto.ToString();
            }
        }

        public static bool RetornarBoolean(object objeto)
        {
            if (objeto == null) {
                return false;
            } else if (objeto == DBNull.Value) {
                return false;
            } else {
                return Convert.ToBoolean(objeto);
            }
        }
    }
}