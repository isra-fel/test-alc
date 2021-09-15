using Newtonsoft.Json;
using PluginBase;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace HelloPlugin
{
    public class HelloCommand : ICommand
    {
        public string Name { get => "hello"; }
        public string Description { get => "Displays hello message."; }

        public int Execute()
        {
            object json = JsonConvert.DeserializeObject("{}");
            Debug.Assert(json != null);
            Assembly newtonsoftJson = AssemblyLoadContext.GetLoadContext(Assembly.GetAssembly(typeof(JsonConvert))).Assemblies.First(
                a => a.FullName.StartsWith("Newtonsoft.Json")
            );
            Debug.Assert(newtonsoftJson != null);
            Console.WriteLine($"{newtonsoftJson.FullName} is loaded.");
            return 0;
        }
    }
}