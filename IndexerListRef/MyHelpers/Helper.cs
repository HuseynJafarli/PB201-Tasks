using System.Net;

namespace MyHelpers
{
    public static class Helper
    {
        public static string CreateBookCode(string name , int id)
        {
            string code = string.Concat(char.ToUpper(name[0]), char.ToUpper(name[1]), id.ToString());

            return code;
        }
    }
}
