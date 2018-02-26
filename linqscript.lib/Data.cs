using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqscript.lib
{
    public interface IData
    {
        string ConnectionString { get; set; }
        List<dynamic> Get(string query);
        List<dynamic> Filter(string expression);
    }

    public class Data //: IData
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<dynamic> Filter(string expression)
        {
            var result = CSharpScript.EvaluateAsync<object>("list.Where(l => l > 2); Console.WriteLine(list.Where(l => l > 2));",
                                                        globals: Rows, globalsType: Rows.GetType(),
                                                        options: ScriptOptions.Default.WithReferences(typeof(System.Linq.Enumerable).Assembly, typeof(string).Assembly)
                                                                                      .WithImports("System.Linq", "System")).Result;

            return result as List<dynamic>;
        }

        IEnumerable<dynamic> Rows { get; set; }
        public List<dynamic> GetDynamic(string query)
        {
            return null;
        }
    }
}
