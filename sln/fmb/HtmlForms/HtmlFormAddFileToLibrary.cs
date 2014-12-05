using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace fmb
{
    class HtmlFormAddFileToLibrary : HtmlForm
    {
        Library lib;
        HtmlFormElement ElFilename; 

        public HtmlFormAddFileToLibrary() {
            this.Title = "Add file to library";

            this.ElFilename = this.AddElement(new ElementTextbox("filename", "Filename (local to server)"));
            this.AddElementSubmit(); 
        }

        internal override void Inject(ServletForm servlet)
        {  
            this.lib = servlet.connectionHandler.server.library;
        }

        protected override void ValidateInternals()
        {
            string path = this.ElFilename.getValue();

            if (!System.IO.File.Exists(path))
            {
                this.ElFilename.validationError = "File does not exist.";
            }
        }
         
        internal override void Process()
        {
           this.lib.Add(ElFilename.getValue());
        }
    }
}
