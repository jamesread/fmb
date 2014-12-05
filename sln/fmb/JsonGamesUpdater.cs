using System;
using System.Net;
using System.Threading;
using System.Runtime.Serialization.Json;

namespace fmb
{
    class JsonGamesUpdater
    {
        public JsonGamesUpdater()
        {
            new Thread(Run).Start(); 
        }

        private String text = ""; 

        public void Run()
        {
            try
            {  
                while (true)
                {
                    this.text = new WebClient().DownloadString(Program.settings.GAMES_URL);
                    Thread.Sleep(new TimeSpan(0, 2, 0));   
                }  
            }  
            catch (Exception e)

            {
                Console.Out.WriteLine(e.ToString());
                Program.errors.Add(e.ToString());  
            }
        }

        internal string GetString()
        {
            return this.text; 
        }
    }
}