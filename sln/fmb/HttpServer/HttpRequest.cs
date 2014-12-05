using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace fmb
{
    class HttpRequest
    {
        public string url;
        public Dictionary<string, string> urlArguments = new Dictionary<string, string>();
        public Dictionary<string, string> headers = new Dictionary<string, string>();
        public Dictionary<string, string> cookies;
        private string sessionId = string.Empty; 
         
        internal static HttpRequest ReadHttpRequest(StreamReader sr)
        {
            string line;  
            HttpRequest req = null;

            try
            {
                while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                {
                    if (req == null)
                    {
                        req = ReadRequestHttpMethod(line);
                    }
                    else
                    {
                        ReadHttpHeader(req, line);
                    }
                }
            }
            catch (IOException)
            {
                return null;
            }

            if (!req.urlArguments.ContainsKey("servlet"))
            {
                req.urlArguments["servlet"] = typeof(ServletIndex).Name;
            }

            return req;
        }

        private static HttpRequest ReadRequestHttpMethod(string line)
        {
            string[] components = line.Split(' ');
            HttpRequest req = new HttpRequest();

            if (components.Length != 3)
            {
                throw new HttpException(400); // FIXME bad request.
            }

            if (!components[0].Equals("GET"))
            {
                throw new HttpException(401, "Unsupported HTTP method: " + line);
            }

            req.url = Uri.UnescapeDataString(components[1]);
            req.url = req.url.Replace("&amp;", "&");

            if (req.url.Contains("?"))
            {
                string query = req.url.Split(new char[] { '?' }, 2)[1];

                foreach (string s in query.Split('&'))
                {
                    string[] s2 = s.Split(new char[] { '=' }, 2);

                    if (s2.Length == 2)
                    {
                        req.urlArguments[s2[0]] = s2[1];
                    }
                    else
                    {
                        req.urlArguments[s2[0]] = string.Empty;
                    }
                }
            } 

            return req;
        }

        private static void ReadHttpHeader(HttpRequest req, string line)
        {
            string[] parts = line.Split(new char[] { ':' }, 2);

            if (parts.Length == 2)
            {
                req.headers[parts[0]] = parts[1];
            }
        }

        internal Dictionary<string, string> GetCookies()
        {
            UpdateCookies();
             
            return this.cookies;
        }

        private void UpdateCookies()
        {
            if (cookies == null)
            {
                cookies = new Dictionary<string, string>();

                if (this.headers.ContainsKey("Cookie"))
                {
                    parseCookies(headers["Cookie"]);
                }
            }
        }

        public string GetSessionId()
        {
            UpdateCookies();

            if (string.IsNullOrEmpty(sessionId))
            {
                if (cookies.ContainsKey("sessionId"))
                {
                    sessionId = cookies["sessionId"];
                }
                else
                { 
                    sessionId = string.Empty;
                }
            }  

            return this.sessionId;
        }

        private void parseCookies(String cookieJar)
        {
            foreach (String fullCookie in cookieJar.Split(';'))
            {
                string[] cookieCrumbs = fullCookie.Split(new char[] { '=' }, 2);

                if (cookieCrumbs.Length >= 2)
                {
                    cookies[cookieCrumbs[0].Trim()] = cookieCrumbs[1].Trim();
                }
                else
                { 
                    cookies[cookieCrumbs[0].Trim()] = string.Empty; 
                }
            }
        }
    }
}
