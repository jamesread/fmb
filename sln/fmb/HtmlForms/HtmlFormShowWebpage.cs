using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class HtmlFormShowWebpage : HtmlForm
    {
        private readonly HtmlFormElement ElUri; 
          
        public HtmlFormShowWebpage()
        { 
            this.Title = "Goto webpage";
            this.ElUri = this.AddElement(new ElementTextbox("url", "URL")); 
            //this.AddElement(new ElementNumber("autoRefresh", "Auto refresh", -1));  
            this.AddElementSubmit();
        }

        protected override void ValidateInternals()
        {
            try
            {
                new Uri(this.ElUri.getValue());
            }
            catch (ArgumentNullException)
            { 
                this.ElUri.validationError = "Cannot be blank.";
            }
            catch (UriFormatException)
            {
                this.ElUri.validationError = "That is not a valid URI.";
            }
        }


        internal override AccessLevel GetAccessLevel()
        {
            return AccessLevel.ADMIN;
        }

        internal override void Inject(ServletForm servletForm)
        {
            this.frmMain = Program.frmMain;  
        }

        internal override void Process()
        {
            Program.canShoutout = false; 
            this.frmMain.ShowSingleControl(this.frmMain.messageRendererWebBrowser);
            this.frmMain.messageRendererWebBrowser.Navigate(new Uri(this.getElementValue("url")));
        }
    }
}
