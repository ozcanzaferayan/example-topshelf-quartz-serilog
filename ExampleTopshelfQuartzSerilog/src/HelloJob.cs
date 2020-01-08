using Quartz;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleTopshelfQuartzSerilog.src
{
    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            
            var lastRun = context.PreviousFireTimeUtc?.DateTime.ToString() ?? string.Empty;
            Log.Warning($"Greetings from HelloJob!   Previous run: {lastRun}");
            Log.Warning(ConfigurationManager.AppSettings["serilog:write-to:File.path"]);
            ConfigurationManager.RefreshSection("appSettings");

        }
    }
}
