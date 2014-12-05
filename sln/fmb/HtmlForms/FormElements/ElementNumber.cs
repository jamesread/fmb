using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class ElementNumber : ElementTextbox 
    {   
        public ElementNumber(string name, string caption, int defaultValue) : base(name, caption) {
            this.value = defaultValue.ToString();
        }    

        internal override void Validate()
        {
            try {  
                string s = this.value;
                float.Parse(s);  
            } catch (Exception) {
                this.validationError = "That is not a number.";
            }
        }
    }
}
