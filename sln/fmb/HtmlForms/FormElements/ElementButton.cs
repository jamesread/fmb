using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace fmb
{ 
    class ElementButton : HtmlFormElement
    {
        internal ElementButton(string name, string caption) : base(name, caption)
        {
            this.hasFieldset = false;
        }

        internal override void render(TextWriter output) { 
            output.WriteLine("<button type = \"submit\" value = \"" + this.value + "\" name = \"" + this.name + "\">" + this.caption + "</button>");
        }

        internal override void Validate() { }
    }
}
