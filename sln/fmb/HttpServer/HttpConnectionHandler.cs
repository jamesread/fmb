using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace fmb
{
    class HttpConnectionHandler
    {
        private readonly Socket socket;
        private readonly StreamReader sr;
        private HttpRequest request;

        internal readonly HttpServer server;
          
        public HttpConnectionHandler(HttpServer server, Socket s)
        {
            NetworkStream ns = new NetworkStream(s);

            this.socket = s;
            this.sr = new StreamReader(ns);
            this.server = server;
        }

        public void Handle()
        {    
            try  
            {
                this.HandleDefault();
            }  
            catch (Exception e) 
            {   
                this.HandleException(e); 
            }
                
            this.socket.Close();  
        } 

        private void HandleException(Exception e)
        { 
            Servlet responder = new ServletError(e);
            responder.output = new StreamWriter(new NetworkStream(this.socket));
            responder.WriteResponseHeader();
            responder.WriteResponse(this.request);
            responder.FlushAndclose();
        } 
         
        private void HandleDefault()
        {
            this.request = HttpRequest.ReadHttpRequest(this.sr);

            Servlet responder = this.server.Servlets.Find(this.request.urlArguments["servlet"]);
            this.CheckSessionId(responder);
            this.CheckAccessLevel(responder); 
                 
            responder.connectionHandler = this;
            responder.output = new StreamWriter(new NetworkStream(this.socket)); 
            responder.WriteResponse(this.request);
            responder.FlushAndclose();  
        }

        internal void CheckAccessLevel(Servlet responder)
        {
            if (GetAuthenticatedAccessLevel() < responder.GetAccessLevel())
            { 
                throw new HttpException(HttpException.ACCESS_FORBIDDEN, "Access level is not sufficient."); 
            }
        }
            
        internal void CheckSessionId(Servlet responder)
        { 
            if (string.IsNullOrEmpty(this.request.GetSessionId()))
            {
                string newSessionId = Guid.NewGuid().ToString();
                responder.SetCookie("sessionId", newSessionId);
                Program.sessionsCollection.InsertNewSession(newSessionId);
            }
        }  

        internal AccessLevel GetAuthenticatedAccessLevel()
        {
            return Program.sessionsCollection.SelectSession(request.GetSessionId()).GetAccessLevel();
        } 
         
        internal void UpdateAccessLevel(AccessLevel accessLevel)
        { 
        	Program.sessionsCollection.UpdateAccessLevel(this.request.GetSessionId(), accessLevel);
        }
    } 
}
