namespace mvc.Extensions
{
    public static class StringExtensions
    {
        public static string LimparCNPJ(this string CNPJ)
        {
            if(string.IsNullOrEmpty(CNPJ))return null;
            return CNPJ.Replace(",", "").Replace("-", "").Replace(".", "").Replace("/", "");
        }
    }
}