using System;
using System.Threading.Tasks;

namespace First_Slack_App
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = "xoxp-532079122384-532814801122-546875286194-3a8402049f6206ad01760a53a3bdb069";
            var writer = new SlackMessageWriter(token);
            Task.WaitAll(writer.WriteMessage("Hello from C#!"));
            Task.WaitAll(writer.WriteSecretMessage("14144246"));
        }
    }
}
