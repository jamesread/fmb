using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb.HtmlForms.FormElements
{ 
    class ElementPassword : ElementTextbox
    {
        internal ElementPassword(string name, string caption, string defaultValue) : base(name, caption, defaultValue) { }

        internal override void render(System.IO.TextWriter output)
        {  
            output.WriteLine("<input type = \"password\" id = \"" + this.name + "\" name = \"" + this.name + "\" value = \"" + this.value + "\" />");
        }
    }
}
