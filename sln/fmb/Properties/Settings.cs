/*
 * Created by SharpDevelop.
 * User: root
 * Date: 01/04/2012
 * Time: 16:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace fmb
{
	/// <summary>
	/// Description of Settings.
	/// </summary>
	public class Settings : IniFile
	{
        internal String ADMIN_PASSWORD
        {
            get
            {
                return this.get("adminPassword"); 
            }
        }

        internal String PORT
        {  
            get { 
                return this.get("port"); 
            }
        } 

        internal String GAMES_URL 
        {
            get 
            {
                return this.get("gamesUrl");
            } 
        } 
		    
		private String get(String key) {
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }
            else
            {
                Console.Out.WriteLine("Cannot find key in ini file:" + key + " in " + this.underlyingFile.FullName);
                return ""; 
            }
		}
		 
		public void set(String key, String val) {
			cache[key] = val; 
		}  
		
		public Settings() : base(new FileInfo(Path.Combine(Application.CommonAppDataPath, "settings.ini")))
		{ 
			this.EnsureExists();
			this.cache[ADMIN_PASSWORD] = "password";
            this.cache[PORT] = "6543";
            this.cache[GAMES_URL] = "http://localhost";
		}
		
		public void Load() {
			this.ReadFromDisk(); 
		}
		                           
		public void Write() {
			this.WriteToDisk();
		}
	}
}
