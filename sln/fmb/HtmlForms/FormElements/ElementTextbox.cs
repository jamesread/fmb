using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class ElementTextbox : HtmlFormElement 
    {
        internal ElementTextbox(string name, string caption) : base(name, caption) { }
          
        internal ElementTextbox(string name, string caption, string defaultValue) : base(name, caption, defaultValue) { }

        internal override void render(System.IO.TextWriter output)
        {   
            output.WriteLine("<input id = \"" + this.name + "\" name = \"" + this.name + "\" value = \"" + this.value + "\" />");
        }

        internal override void Validate()
        {
            if (string.IsNullOrEmpty(this.value))
            {
                this.validationError = "Cannot be empty."; 
            }
        }
    }
}
