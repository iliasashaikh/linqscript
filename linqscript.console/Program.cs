using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace linqscript.console
{

    class Trade
    {
        public int Id { get; set; }
        public DateTime TradeDate { get; set; }
        public string Security { get; set; }
        public int Quantity { get; set; }
        //public decimal Bookcost { get; set; }

    }
    class Program
    {

        static ILogger Logger = Util.MakeLogger();
        static void Main(string[] args)
        {

            var trade = new Trade() { Id = 1, Quantity = 1000, Security = "VOD LN", TradeDate = DateTime.Now };
            Logger.Information("Traded {Trade}", trade);
            Logger.Information("Name {name}", "ilias");

            try
            {
                throw new NullReferenceException("test");
            }
            catch (Exception error)
            {
                
            }
        }
    }

    public static class Util
    {
        public static ILogger MakeLogger()
        {
            StackFrame frame = new StackFrame(1, true);
            var type = frame.GetMethod().DeclaringType;
            const string messageTemplate = "[{Timestamp:dd-MMM-yyyy HH:mm:ss}][{SourceContext}][{Level}]:{Message:j}{NewLine}{Exception}";
            var logger = new LoggerConfiguration()
                 .WriteTo.Console(outputTemplate: messageTemplate )
                 .WriteTo.File(@"_trace.log", outputTemplate: messageTemplate)
                 .CreateLogger()
                 .ForContext(type);

            return logger;
        }
    }
}
