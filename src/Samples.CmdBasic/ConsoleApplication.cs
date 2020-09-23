#region Using Statements
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
#endregion

namespace Samples.CmdBasic
{
    public class ConsoleApplication
    {
        ILogger<ConsoleApplication> _logger;
        IConfiguration _configuration;

        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        public ConsoleApplication(ILogger<ConsoleApplication> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task Run()
        {
            //do work here (call a service)
            int wait = new Random().Next(1000, 3000);
            string startMessage = $"Executing Run in {_configuration.GetValue<string>("Environment")}. Waiting for {wait.ToString()} ms.";
            _logger.LogInformation(startMessage);
            System.Threading.Thread.Sleep(wait);
            //
            //
            //
            _logger.LogInformation("Run Completed.");
        }


    }
}
