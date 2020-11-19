using System;
using System.Reflection;

namespace DynamicCodeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/usr/local/share/dotnet/packs/Microsoft.NETCore.App.Ref/3.1.0/ref/netcoreapp3.1/System.Web.dll";

            // Get the Assembly from the file
            Assembly webAssembly = Assembly.LoadFile(path);

            // Get the Type from the HttpUtility class
            Type utilType = webAssembly.GetType("System.Web.HttpUtility");

            // Get the static HtmlEncode and HtmlDecode methods
            MethodInfo encode = utilType.GetMethod("HtmlEncode", new Type[] { typeof(string) });
            MethodInfo decode = utilType.GetMethod("HtmlDecode", new Type[] { typeof(string) });

            // Create a string to be encoded
            string originalString = "This is Sally & Jack's Anniversary <sic>";

            // Encode it and show the encoded value
            string encoded = (string)encode.Invoke(null, new object[] { originalString });

            Console.WriteLine(encoded);

            // Decode it to make sure it comes back right
            string decoded = (string)decode.Invoke(null, new object[] { encoded });

            Console.WriteLine(decoded);
        }
    }
}
