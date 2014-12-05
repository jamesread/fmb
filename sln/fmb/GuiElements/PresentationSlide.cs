using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace fmb
{
    class PresentationSlide
    {
        private Dictionary<string, string> headers = new Dictionary<string, string>();
        private string slideContent = "";
        internal static int defaultSlideDelaySeconds = 3; 
         
        public Color foreground = Color.White;
        public Color background = Color.Black;
        private int delaySeconds = defaultSlideDelaySeconds; 
        private FileInfo picture;
        private int fontSize = 32; 

        public int getFontSize()
        { 
            return this.fontSize;
        }

        public FileInfo getPicture()
        {
            return picture; 
        }
          
        public Color getForeground()
        {
            return foreground;
        }

        public Color getBackground()
        {
            return background;
        } 

        public PresentationSlide(string fulltext)
        {
            this.parseFulltext(fulltext);
        } 
 
        private void parseFulltext(string fulltext)
        {
            String content = "";
            List<String> headerParams = new List<String>();

            foreach (String line in fulltext.Split('\n'))
            {
                if (line.StartsWith("@"))
                {
                    headerParams.Add(line);
                }
                else
                {
                    content += line + "\n";
                } 
            }
             
            this.parseHeaders(headerParams);
            this.slideContent = content;
            
            this.processParams();
        } 

        private void processParams()
        {
            foreach (string headerName in this.headers.Keys) 
            {
                string value = headers[headerName].Trim();
                  
                switch (headerName) {
                    case "steamGamesList": 
                        this.slideContent = "These (steam) games are up right now:\n\n" + Program.jsonGamesUpdater.GetString(); 
                        break; 
                    case "foreground":
                        this.foreground = Color.FromName(value);
                        break;
                    case "background":
                        this.background = Color.FromName(value); 
                        break;
                    case "delaySeconds": 
                        try {
                            this.delaySeconds = int.Parse(value);
                        } catch (Exception) {
                            this.delaySeconds = defaultSlideDelaySeconds;
                        }
                        break; 
                    case "fontSize": 
                        try
                        {
                            this.fontSize = int.Parse(value);
                        }
                        catch (Exception)
                        {
                            this.fontSize = 32;
                        } 
                        break;
                    case "picture":
                        FileInfo fi = new FileInfo(value);

                        if (fi.Exists) 
                        {
                            if (supportedPictureExtensions.Contains(fi.Extension))
                            {
                                this.picture = fi;
                            }
                        }
                         
                        break;
                }
            }
        }

        private static List<String> supportedPictureExtensions = new List<String>(new string[] { ".png", ".jpeg", ".jpg", ".gif"});
          
        private void parseHeaders(List<String> headerBlock)
        {
            foreach (string line in headerBlock)
            {
               this.parseSingleHeader(line);  
            }
        }  

        private void parseSingleHeader(string line)
        {
            line = line.Replace("@", "");
            string[] parts = line.Split(new char[] {':'},2);

            if (parts.Length != 2)
            {
                return; 
            } 
            else
            { 
                string header = parts[0];
                string value = parts[1];
                
                if (headers.ContainsKey(header)) {
                    headers.Remove(header); 
                }   

                headers.Add(header, value); 
            } 
        }

        internal string GetText()
        {
            return this.slideContent.Trim(); 
        }

        internal int getDelayInMilliseconds()
        {   
            return delaySeconds * 1000;
        }

        internal int getHeaderCount()
        {
            return headers.Count;
        }
    }
}
