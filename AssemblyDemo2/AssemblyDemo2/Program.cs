using System;
using System.Reflection;

namespace AssemblyDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/usr/local/share/dotnet/packs/Microsoft.NETCore.App.Ref/3.1.0/ref/netcoreapp3.1/System.ServiceProcess.dll";
            
            // Using BindingFlags to only get declared and instance members
            BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;
            
            // Load the Assembly from the path
            Assembly theAssembly = Assembly.LoadFrom(path);
            Console.WriteLine(theAssembly.FullName);
            Type[] types = theAssembly.GetTypes();

            foreach (Type t in types)
            {
                Console.WriteLine("Type: {0}", t.Name);
                MemberInfo[] members = t.GetMembers(flags);

                foreach (MemberInfo member in members)
                {
                    Console.WriteLine("{0}: {1}", member.MemberType, member.Name);
                }
            }
        }
    }
}
