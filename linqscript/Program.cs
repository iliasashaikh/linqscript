using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqscript
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var global = new Global();
            var result = await CSharpScript.EvaluateAsync<object>("list.Where(l => l > 2); Console.WriteLine(list.Where(l => l > 2));",
                                                                    globals: global, globalsType: global.GetType(),
                                                                    options: ScriptOptions.Default.WithReferences(typeof(System.Linq.Enumerable).Assembly, typeof(string).Assembly)
                                                                                                  .WithImports("System.Linq", "System"));
            Console.WriteLine(result);
        }


    }

    public class Global
    {
        public List<int> list = new List<int> { 1, 2, 3, 4, 0 };
    }
}
