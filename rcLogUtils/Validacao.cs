using System.Text.RegularExpressions;

namespace rcLogUtils
{
    public static class Validacao
    {
        //-- A = letras maiúsculas (A-Z)
        static string mai = "A-Z";

        //-- a = letras minúsculas (a-z)
        static string min = "a-z";

        //-- B = espaço em branco (\s)
        static string bra = @"\s";

        //-- C = acentuação maiúscula (ÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ)
        static string ama = "ÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ";

        //-- c = acentuação minúscula (áàâãéèêíïóôõöúçñ)
        static string ami = "áàâãéèêíïóôõöúçñ";

        //-- E = especiais !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~´
        static string esp = @"\!""#\$%&'\(\)\*\+,\-\./:;<=>\?@\[\\\]\^_`\{\|\}~´";

        //-- N = números (0-9)
        static string num = "0-9";

        //-- T = traços = sublinhado e hífen (_\-)
        static string tra = @"_\-";

        public static bool ValidarCharAaBCcNT(string pValor) {
            if (Regex.IsMatch(pValor, $"^[{num}{mai}{min}{ami}{ama}{tra}{bra}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaNT(string pValor) {
            if (Regex.IsMatch(pValor, $"^[{num}{mai}{min}{tra}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaBCc(string pValor) {
            if (Regex.IsMatch(pValor, $"^[{mai}{min}{ami}{ama}{bra}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaBEN(string pValor) {
            if (Regex.IsMatch(pValor, $"^[{num}{mai}{min}{bra}{esp}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaB(string pValor) {
            if (Regex.IsMatch(pValor, $"^[{mai}{min}{bra}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaBN(string pValor) {
            if (Regex.IsMatch(pValor, $"^[{num}{mai}{min}{bra}]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarCharAaN(string pValor) {
            if (Regex.IsMatch(pValor, $"^[{num}{mai}{min}]+$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool ValidarBrancoIniFim(string pValor) {
            if (pValor.StartsWith(" ") || pValor.EndsWith(" ")) {
                return false;
            } else {
                return true;
            }
        }
    }
}