namespace mvc.Extensions
{
    public static class StringExtensions
    {
        public static string LimparCNPJCPF(this string CNPJCPF)
        {
            CNPJCPF = CNPJCPF.Trim();

            if(string.IsNullOrEmpty(CNPJCPF))return null;

            return CNPJCPF.Replace(",", "").Replace("-", "").Replace(".", "").Replace("/", "");
        }
    }
}