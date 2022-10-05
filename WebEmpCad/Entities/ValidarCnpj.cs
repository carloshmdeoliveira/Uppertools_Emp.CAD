namespace WebEmpCad.Entities
{
    public class ValidarCnpj
    {
        public static bool Validar(string cnpj)
        {
            int[] fator1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] fator2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (!IsCnpj(cnpj))
                return false;
            // Chegar o primeiro digito

            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(cnpj[i].ToString()) * fator1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();

            // Checar o segundo digito

            if (digito == cnpj[12].ToString())
            {
                soma = 0;

                for (int i = 0; i < 13; i++)
                    soma += int.Parse(cnpj[i].ToString()) * fator2[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();
                return cnpj.EndsWith(digito);
            }
            else
                return false;
        }

        public static string RetirarMascara(string cnpjMascara)
        {
            return cnpjMascara.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        // Formatar
        public static string Formatar(string cnpj)
        {
            if (IsCnpj(cnpj))
                return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
            else
                return cnpj;
        }

        // Validar
        private static bool IsCnpj(string cnpj)
        {
            if (cnpj.Length != 14)
            {
                return false;
            }
            else
            {
                // Verificar se todos os 14 dígitos são números
                for (int i = 0; i < cnpj.Length; i++)
                {
                    if (!Char.IsDigit(cnpj[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

