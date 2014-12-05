using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class ElementHidden : HtmlFormElement 
    {
        internal ElementHidden(string name, string caption, string defaultValue) : base(name, caption, defaultValue) {
            this.hasFieldset = false;
        } 

        internal override void render(System.IO.TextWriter output)
        {   
            output.WriteLine("<input type = \"hidden\" id = \"" + this.name + "\" name = \"" + this.name + "\" value = \"" + this.value + "\" />");
        }

        internal override void Validate()
        {
            
        }
    }
}
