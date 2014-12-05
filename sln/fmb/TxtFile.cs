/*
 * Created by SharpDevelop.
 * User: root
 * Date: 01/04/2012
 * Time: 21:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace fmb
{
	/// <summary>
	/// Description of TxtFile.
	/// </summary>
	public class TxtFile
	{ 
		private string data;
		private FileInfo file; 
		
		public TxtFile(FileInfo file)
		{
			this.file = file;
		} 
		
		public void Write() 
		{
			StreamWriter writer = new StreamWriter(this.file.FullName); 
			
			writer.Write(data);
			writer.Close();
		}
		
		public void Read() 
		{
			StreamReader reader = new StreamReader(file.FullName);
			string buf = string.Empty; 
			string line = string.Empty;
			 
			while ((line = reader.ReadLine()) != null) 
			{
				buf += line + "\n"; 
			}
			
			reader.Close(); 
			
			this.data = buf;
		}
		 
		public void Set(string data) {
			this.data = data;
		}
		 
		public string Get() 
		{
			return data;
		}  
		
		internal void EnsureExists()
		{
            if (!file.Exists)
            {
                file.Create().Close();
            }
		}
	} 
}
