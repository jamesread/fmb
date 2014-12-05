/*
 * Created by SharpDevelop.
 * User: root
 * Date: 01/04/2012
 * Time: 16:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace fmb
{
	/// <summary>
	/// Description of IniFile.
	/// </summary>
	public abstract class IniFile
	{
		internal FileInfo underlyingFile; 
		
		public IniFile(FileInfo file)
		{
            this.underlyingFile = file;
		}
		  
        internal Dictionary<string, string> cache = new Dictionary<string, string>(); 
		
        private void ParseLine(string line)
        {
            if (line.StartsWith("#"))
            {
                return;
            }

            string[] parts = line.Split(new char[] {'='}, 2);

            if (parts.Length == 2)
            {
                string key = parts[0].Trim();
                string val = parts[1].Trim();
                
                this.cache[key] = val; 

                this.OnReadLine(key, val);
            }
        }
         
        public virtual void OnReadLine(string k, string v) {}
		
		protected void EnsureExists()
		{
            Console.Out.WriteLine("Using INI File: " + this.underlyingFile.FullName);

            if (!underlyingFile.Exists)
            {
                underlyingFile.Create().Close();
            }
		}
				
        protected void WriteToDisk()
        {
            StreamWriter writer = new StreamWriter(this.underlyingFile.FullName); 

            foreach (string sessionId in this.cache.Keys) { 
            	this.WriteLine(writer, sessionId, this.cache[sessionId]); 
            }

            writer.Close();
        }
        
        protected void WriteLine(StreamWriter writer, String key, String val) { 
        	writer.WriteLine(key + "=" + val);
        } 
          
        protected void ReadFromDisk()
        {
            StreamReader reader = new StreamReader(underlyingFile.FullName);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                { 
                    continue; 
                }

                this.ParseLine(line);
            }

            reader.Close();
        }
	}
} 
