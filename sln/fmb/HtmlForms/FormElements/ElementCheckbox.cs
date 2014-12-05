using System;

namespace fmb.HtmlForms.FormElements
{ 
	internal class ElementCheckbox : HtmlFormElement
	{
		public ElementCheckbox(string name, string caption) : base(name, caption)
		{
		}
		
		public ElementCheckbox(string name, string caption, string defaultValue) : base(name, caption, defaultValue)
		{
		}

        public ElementCheckbox(string name, string caption, bool defaultValue) : base (name, caption, ((defaultValue) ? "on" : "off"))
        {  
        }
		
		internal override void Validate()
		{ 
		}
		
		internal bool isChecked() {
			if (this.value == null) {
				return false;
			}
			
			if (this.value.Equals(this.name)) {
				return true;
			} 
			
			if (this.value.Equals("on")) {
				return true;
			}
			
			return false; 
		}
		
		internal override void render(System.IO.TextWriter output){ 
			string checkedValue = this.isChecked() ? " checked = \"checked\" " : string.Empty;
			 
			output.WriteLine("<input type = \"checkbox\" name = \"" + this.name +  "\" id = \"" + this.name +  "\" " + checkedValue + " />");
		}
	}
}
