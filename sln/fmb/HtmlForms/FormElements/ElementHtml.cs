using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb.HtmlForms
{
    class ElementHtml : HtmlFormElement
    {
        public ElementHtml(string name) : base (name, name)
        {
            this.hasLabel = false; 
        }

        internal override void Validate() { }

        internal override void render(System.IO.TextWriter output)
        {
            output.Write(this.value);
        }
    }
}
