/*
 * Created by SharpDevelop.
 * User: root
 * Date: 01/04/2012
 * Time: 20:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace fmb
{ 
	public class CsvFile
	{
		private FileInfo file; 
		private List<List<String>> cache = new List<List<String>>();
		 
		public CsvFile(FileInfo file)
		{
			this.file = file;
		}
		
		public List<List<String>> GetCache() {
			return cache; 
		}
		
        internal void WriteToDisk()
        {   
            StreamWriter writer = new StreamWriter(this.file.FullName); 

            foreach (List<String> csvLine in this.cache) { 
            	this.WriteLine(writer, csvLine); 
            }

            writer.Close();
        }
        
        private void WriteLine(StreamWriter writer, List<String> line) 
        {
        	foreach (String cellValue in line) 
        	{ 
        		writer.Write('"' + cellValue + '"' + ',');
        	}
        	
        	writer.Write("\n");
        }
        
        public void ReadFromDisk()
        { 
        	cache.Clear();
        	 
            StreamReader reader = new StreamReader(file.FullName);

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
          
        private void ParseLine(string line) 
        {
        	List<String> cellValues = new List<String>();
        	String currentCellValue = string.Empty;
        	bool quoteOpen = false;
        	
        	foreach (char c in line) {
        		if (c == '"') {
        			quoteOpen = !quoteOpen;
        		} 
        		else if (c == ',')
        		{
        			if (!quoteOpen) {
        				cellValues.Add(currentCellValue);
        				currentCellValue = string.Empty;
        			}
        		}
        		else 
        		{
        			currentCellValue += c;
        		}
        	} 
        	
        	cache.Add(cellValues);
        } 
		
        public void Add(params string[] csvValueList)
		{
			List<String> stuff = new List<String>();
			
			foreach (String csvValue in csvValueList) {
				stuff.Add(csvValue);
			}
			
			cache.Add(stuff); 
		}
		
		public void Clear()
		{ 
			cache.Clear();
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
