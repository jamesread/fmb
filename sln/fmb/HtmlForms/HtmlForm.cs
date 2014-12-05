using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using fmb.HtmlForms.FormElements;

namespace fmb
{ 
    abstract class HtmlForm   
    {
        protected List<HtmlFormElement > elements = new List<HtmlFormElement >();
        internal string Title = "untitled form";
        protected FrmMain frmMain;
        internal string action; 
        public string postProcessContent; 

        public void Render(TextWriter output) 
        {  
            output.WriteLine("<form method = \"get\" action = \"" + this.action + "\" >");

            foreach (HtmlFormElement el in this.elements)
            {
                if (el.hasFieldset) 
                {   
                    output.WriteLine("<fieldset>");
                    if (el.hasLabel)
                    {
                        output.WriteLine("<label for = \"" + el.name + "\">" + el.GetCaption() + "</label>");
                    }

                    el.render(output);

                    if (el.hasHelpText())
                    {
                        output.WriteLine("<span style = \"\">" + el.getHelpText() + "</span>");
                    }

                    if (el.validationError != null)
                    {  
                        output.WriteLine("<span style = \"color:red;\">" + el.validationError + "</span>");
                    }

                    output.WriteLine("</fieldset>");
                }
                else
                {
                    output.WriteLine("<p>");
                    el.render(output);
                    output.WriteLine("</p>");  
                }
            }
             
            output.WriteLine("</form>");  
        } 
        
        internal HtmlFormElement AddElementSubmit(string title) 
        { 
            HtmlFormElement el = this.AddElement(new ElementButton("submit", title));
            el.SetValue(this.GetType().Name);
             
            return el; 
        }

        internal HtmlFormElement AddElementSubmit()
        {  
        	return AddElementSubmit("Submit");
        }

        internal HtmlFormElement AddElement(HtmlFormElement el)
        { 
            elements.Add(el);

            return el;
        }

        internal HtmlFormElement GetElement(string name)
        {
            foreach (HtmlFormElement element in this.elements)
            {
                if (element.name.Equals(name))
                {
                    return element;
                }
            }

            throw new Exception("Element not found");
        }

        internal string getElementValue(string elementName)
        {
            foreach (HtmlFormElement el in this.elements)
            {
                if (el.name.Equals(elementName))
                {
                    return el.getValue();
                }
            }
             
            return string.Empty;
        }

        abstract internal void Process();

        protected virtual void ValidateInternals() { }

        internal bool Validate(Dictionary<string, string> args)
        {
            if (!args.ContainsKey("submit"))
            {
                return false; 
            }

            if (args["submit"] != this.GetType().Name)
            {
                return false;
            }

            foreach (HtmlFormElement el in this.elements)
            {
                if (args.ContainsKey(el.name))
                {
                	if (el is ElementCheckbox) {
                		el.SetValue(el.name);
                	}  
                	else
                	{
                		el.SetValue(args[el.name]);
                	}
                }   
            }   

            this.ValidateInternals();

            foreach (HtmlFormElement el in this.elements)
            { 
                if (args.ContainsKey(el.name))
                {
                    el.SetValue(args[el.name]);
                } 

                el.Validate();
                  
                if (el.validationError != null)
                {
                    return false; 
                }
            }



            return true;
        }
         
        protected ServletForm servlet;

        internal virtual void Inject(ServletForm servletForm)
        {
            this.servlet = servletForm;
        }
         
        internal virtual AccessLevel GetAccessLevel()
        {
            return AccessLevel.MODERATOR;
        }
    }
}
