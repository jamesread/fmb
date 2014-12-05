using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using fmb.HtmlForms;
using System.IO;

namespace fmb
{
    static class Program
    {
        internal static DateTime canNextShoutout = DateTime.Now;
        internal static bool canShoutout = true; 
        internal readonly static Scheduler scheduler = new Scheduler();
        internal static FrmMain frmMain; 
        internal static HttpServer httpServer;
        internal readonly static Settings settings = new Settings(); 
        internal readonly static SessionsCollection sessionsCollection = new SessionsCollection(); 
        internal readonly static List<String> errors = new List<String>();
        internal static JsonGamesUpdater jsonGamesUpdater;
            
        /// <summary> 
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try 
            {
            	Program.settings.Load();
            	Program.sessionsCollection.Load();

                jsonGamesUpdater = new JsonGamesUpdater();
                httpServer = new HttpServer();
            	 
                SetupMainForm();
                StartWebserver();
                ShowInitialMessage(Program.frmMain);
                 
                Application.Run(Program.frmMain);
            }
            catch (Exception e)
            {
                FrmSelectableMessage.ShowException(e); 
            }
        }
           
        internal static String commonDataFile(String filename) {
            return Path.Combine(Application.CommonAppDataPath, filename); 
        }

        internal static string getVersion()
        { 
            return Application.ProductVersion.ToString(); 
        }
 
        public static void Exit()
        { 
            Program.sessionsCollection.Write();
            Program.settings.Write();
            Program.frmMain.HideTrayIcon();  
            Program.httpServer.library.Save();
            Environment.Exit(0);
        } 

        private static void SetupMainForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.frmMain = new FrmMain();

            /* 
             * The manual call to select here is so that the controls can be
             * manipulated before it is set to Visible for the first time.
             */ 
            frmMain.Select(); 
        }

        private static void StartWebserver()
        {
            httpServer.RegisterServlet(typeof(ServletActions));
            httpServer.RegisterServlet(typeof(ServletError));
            httpServer.RegisterServlet(typeof(ServletForm));
            httpServer.RegisterServlet(typeof(ServletIndex));
            httpServer.RegisterServlet(typeof(ServletLibrary));
            httpServer.RegisterServlet(typeof(ServletResource));  
            httpServer.RegisterServlet(typeof(ServletStartup));
            httpServer.RegisterServlet(typeof(ServletFlushQueue)); 
            httpServer.RegisterServlet(typeof(ServletYouTubeVideo)); 
            httpServer.RegisterServlet(typeof(ServletLog)); 
            httpServer.RegisterServlet(typeof(ServletQueueNext));  
            httpServer.RegisterServlet(typeof(ServletPostponeShoutouts));  

            ServletForm.forms.Register(typeof(HtmlFormAddFileToLibrary));
            ServletForm.forms.Register(typeof(HtmlFormExit));
            ServletForm.forms.Register(typeof(HtmlFormLogin));
            ServletForm.forms.Register(typeof(HtmlFormShowTextMessage));
            ServletForm.forms.Register(typeof(HtmlFormShowMedia));
            ServletForm.forms.Register(typeof(HtmlFormSetBounds));
            ServletForm.forms.Register(typeof(HtmlFormShowWebpage)); 
            ServletForm.forms.Register(typeof(HtmlFormShowPresentation));   
            ServletForm.forms.Register(typeof(HtmlFormShowYoutubeVideo)); 
            ServletForm.forms.Register(typeof(HtmlFormShoutout));
            new Thread(httpServer.Start).Start();  
        }

        private static void ShowInitialMessage(FrmMain frmMain)
        {
            DisplayableMessageArguments dma = new DisplayableMessageArguments(frmMain.messageRendererWebBrowser);
            dma.setArgument("url", "http://localhost:" + HttpServer.port +  "/?servlet=ServletStartup");

            Program.scheduler.add(dma);
            Program.scheduler.Run();   
        }
    }
}
