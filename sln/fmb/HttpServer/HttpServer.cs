using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace fmb
{ 
    class HttpServer  
    { 
        internal static int port = 80;
        private Socket sock;
        private bool run = true; 
        internal readonly Library library;

        internal TypeSafeRawList<Servlet> Servlets = new TypeSafeRawList<Servlet>();
           
        public HttpServer()
        {
            port = int.Parse(Program.settings.PORT);
            
            this.library = new Library();  
        }
         
        public void Start() 
        {
            Console.Out.WriteLine("Http server will use port: " + port);

            try
            {
                StartListening();
            }
            catch (Exception e) 
            {
                FrmSelectableMessage.ShowException(e);
            }
        }

        private void StartListening()
        {
            try
            {
                IPEndPoint listeningEndpoint = new IPEndPoint(IPAddress.Any, HttpServer.port);

                sock = new Socket(listeningEndpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                sock.Bind(listeningEndpoint);
                sock.Listen(3);
                this.run = true;
            }
            catch (Exception exceptionBinding)
            {
                MessageBox.Show("Unable to bind to the HTTP server port. This normally happens when you are trying to launch a second instances of FMB. \n\nException: " + exceptionBinding.Message, "fmb: Exception while binding HTTP listening socket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.Exit();
            }

            while (run)
            {
                try 
                {
                    new HttpConnectionHandler(this, sock.Accept()).Handle();
                }
                catch (Exception e) 
                { 
                    Program.errors.Add(e.ToString());
                }
            } 
        }

        public void Stop()
        {
            this.run = false;

            if (this.sock != null)
            {
                this.sock.Close();
            }

            this.sock = null;
        }
         
        internal bool IsStarted()
        {
            if (this.sock == null)
            {
                return false;
            } 

            return this.sock.IsBound;
        }

        public void RegisterServlet(Type s, params string[] aliases)
        {
            if (aliases.Length == 0)
            {
                this.Servlets.Register(s);
            }
            else
            {
                foreach (string alias in aliases)
                {
                    this.Servlets.Register(s);
                }
            }
        }
    }
}
