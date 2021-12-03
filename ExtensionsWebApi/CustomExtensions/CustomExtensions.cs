namespace ExtensionsWebApi.CustomExtensions
{
    public static class CustomExtensions
    {
        public static string GetShortName(this string name)// İsmi kısaltılmış olarak geri döndüren extension
        {
            string result = name.Substring(0, 1) + ". ";
            //adın ilk harflerini kaydeder.

            return result;
        }

        public static string getProtectedPhoneNumber(this string value)
        {
            string result = "*******" + value.Substring(value.Length - 4, value.Length);
            return value;
        }
        public static string getProtectedEmail(this string value)
        {
            string result = value.Substring(0, 4) + "********";
            return result;
        }

    }
}