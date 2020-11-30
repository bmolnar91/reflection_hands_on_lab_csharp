using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DemoDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an Assembly name
            AssemblyName theName = new AssemblyName();
            theName.Name = "DemoAssembly";
            theName.Version = new Version("1.0.0.0");

            // Get the AppDomain to put our assembly in
            AppDomain domain = AppDomain.CurrentDomain;

            // Create the Assembly
            AssemblyBuilder assemBldr = AssemblyBuilder.DefineDynamicAssembly(theName, AssemblyBuilderAccess.Run);

            // Define a module to hold our Type
            ModuleBuilder modBldr = assemBldr.DefineDynamicModule("DemoAssembly.dll");

            // Create a new Type
            TypeBuilder animalBldr = modBldr.DefineType("Animal", TypeAttributes.Public);

            // Display new Type
            Type animal = animalBldr.CreateType();
            System.Console.WriteLine(animal.FullName);

            foreach (MemberInfo info in animal.GetMembers())
            {
                System.Console.WriteLine("Member ({0}): {1}", info.MemberType, info.Name);
            }
        }
    }
}
