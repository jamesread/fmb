using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace fmb
{
    class Library
    {
        private readonly List<FileInfo> list = new List<FileInfo>();
        private CsvFile storage = new CsvFile(new FileInfo(Path.Combine(Application.CommonAppDataPath, "library.csv")));
         
        internal Library() {
        	storage.EnsureExists();
        	UpdateFromStorage();
        }

        internal int Size()
        { 
            return list.Count; 
        } 

        internal List<FileInfo> All()
        {
            return list; 
        }

        internal void Add(string path)
        {
        	list.Add(new FileInfo(path)); 
            storage.Add(path);  
        } 

        private void UpdateFromStorage()   
        { 
        	list.Clear();
        	storage.ReadFromDisk(); 

        	foreach (List<String> csvLine in storage.GetCache()) 
        	{
        		if (csvLine.Count > 1)  
        		{
        			String Path = csvLine[0]; 
        			
        			list.Add(new FileInfo(Path));
        		} 
        	}
        }
        
        internal void Save() 
        {
        	storage.WriteToDisk();
        }
    }
}
