using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb.HtmlForms.FormElements
{
    class ElementSelect : HtmlFormElement
    {
        private Dictionary<string, int> values = new Dictionary<string, int>();

        public ElementSelect(string name, string caption) : base (name, caption)
        {
        }

        internal override void Validate()
        {
        } 

        internal void AddOption(string caption, int value)
        {
            this.values.Add(caption, value);
        }
    }
}
