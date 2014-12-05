using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace fmb
{ 
    abstract class HtmlFormElement 
    {
        internal readonly string name;
        protected string caption;
        protected string value;
        internal string validationError;
        internal string helpText = "";

        public HtmlFormElement(string name, string caption, string defaultValue)
        {
            this.name = name;
            this.caption = caption;
            this.validationError = null;
              
            this.value = defaultValue;
        } 

        public HtmlFormElement(string name, string caption) : this (name, caption, null) {}

        abstract internal void Validate();

        internal void SetValue(string value)
        { 
            this.value = value.Replace("+", " "); 
        }

        internal void SetValue(int value)
        { 
            this.value = value.ToString();
        }

        internal string getValue()
        {
            return this.value;
        }

        internal void setHelpText(string helpText)
        {
            this.helpText = helpText;
        }

        internal virtual void render(TextWriter output)
        {
            output.WriteLine("UNIMPLEMENTED FORM ELEMENT"); 
        }

        internal string GetCaption()
        { 
            return caption;
        }

        public bool hasFieldset = true;
        public bool hasLabel = true; 

        internal string getHelpText()
        {
            return this.helpText;
        }

        internal bool hasHelpText()
        {
            return !string.IsNullOrEmpty(this.helpText);
        }

        internal void SetCaption(string caption)
        { 
            this.caption = caption; 
        }
    }
}
