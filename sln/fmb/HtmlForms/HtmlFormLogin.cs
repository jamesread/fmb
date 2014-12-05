using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fmb.HtmlForms.FormElements;
using System.Windows.Forms;

namespace fmb 
{
    class HtmlFormLogin : HtmlForm
    {
    	private string password = Program.settings.ADMIN_PASSWORD;
          
        public HtmlFormLogin() {         		
            this.Title = "Login";
            this.AddElement(new ElementPassword("password", "Admin password", string.Empty));
            this.GetElement("password").setHelpText("The default password is 'password'. It can be changed in settings.ini on the configuration directory."); 
            this.AddElementSubmit(); 
        } 

        protected override void ValidateInternals()
        {
            this.ValidatePassword(); 
        }

        private void ValidatePassword()
        {
            if (!this.getElementValue("password").Equals(password))
            {
                this.GetElement("password").validationError = "Incorrect password";
            }
        }

        internal override void Process()
        {
            this.servlet.connectionHandler.UpdateAccessLevel(AccessLevel.ADMIN); 
              
            this.postProcessContent = "You have logged in! <a href = '?servlet=ServletActions'>View privileged actions.</a>";  
        } 

        internal override AccessLevel GetAccessLevel()
        {
            return AccessLevel.GUEST; 
        }
    }
}
