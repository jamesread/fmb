using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fmb.HtmlForms.FormElements;

namespace fmb
{ 
    class HtmlFormSetBounds : HtmlForm
    {
        private ElementCheckbox elToggleFullscreen;

        public HtmlFormSetBounds()
        {
            this.Title = "Set Main Window Bounds (location & size)";

            this.AddElement(new ElementNumber("x", "X (from left of screen)", 0));
            this.AddElement(new ElementNumber("y", "Y (from top of screen)", 0));
            this.AddElement(new ElementNumber("w", "Width", 0)); 
            this.AddElement(new ElementNumber("h", "Height", 0));
              
            this.elToggleFullscreen = new ElementCheckbox("windowState", "Toggle window fullscreen?");
            this.elToggleFullscreen.setHelpText("If you tick this checkbox, then the fullscreen will be <em>toggled</em> when the form is submitted. If FMB is in a window, it will become fullscreen. If it is fullscreen it will become a window.");
            this.AddElement(this.elToggleFullscreen);  
            this.AddElementSubmit();   
        } 
         
        internal override void Inject(ServletForm servlet) 
        {
            this.frmMain = Program.frmMain; 
             
            this.GetElement("x").SetValue(frmMain.Left);
            this.GetElement("y").SetValue(frmMain.Top);
            this.GetElement("w").SetValue(frmMain.Width);
            this.GetElement("h").SetValue(frmMain.Height);
        } 

        internal override void Process()
        {
            int x = this.ParseFloatOrReturnDefault(this.getElementValue("x"), 10);
            int y = this.ParseFloatOrReturnDefault(this.getElementValue("y"), 10);
            int w = this.ParseFloatOrReturnDefault(this.getElementValue("w"), 320);
            int h = this.ParseFloatOrReturnDefault(this.getElementValue("h"), 240);
                 
            this.frmMain.InvokeSetBounds(x, y, w, h);

            if (this.elToggleFullscreen.isChecked())
            { 
                this.frmMain.ToggleFullscreen();
            }
        }
         
        private int ParseFloatOrReturnDefault(string input, int def)
        {
            try
            { 
                return int.Parse(input);
            } catch (Exception) { 
                return def;  
            }
        }
       
    }
}
