using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace fmb
{
    class MessageRendererTextMessage : Label, MessageRenderer
    {
        public void render(DisplayableMessageArguments args) {
            this.Invoke(new MethodInvoker(delegate
            {
                this.SetColors(args);
                this.SetMessage(args);
            }));
        }

        public void renderError(String message)
        {
            DisplayableMessageArguments args = new DisplayableMessageArguments(this);
            args.setArgument("message", "Error: " + message);
            args.setArgument("foreground", "white");
            args.setArgument("background", "red");
             
            this.render(args); 
        }
         
        private void SetMessage(DisplayableMessageArguments args)
        {
            int fontSize = 15;

            try  
            {
                fontSize = int.Parse(args.getArgument("fontsize"));
            } 
            catch (Exception) 
            { }

            this.Font = new Font(this.Font.FontFamily, fontSize); 

            if (string.IsNullOrEmpty(args.getArgument("message")))
            {
                this.Text = "<empty message>!";
            }
            else
            { 
                this.Text = args.getArgument("message");
            } 
        }
         
        public void SetColors(DisplayableMessageArguments args)
        {
            Color foreground;
            Color background;

            try
            {
                foreground = Color.FromName(args.getArgument("forecolor"));
                background = Color.FromName(args.getArgument("backcolor"));
            }
            catch (Exception)
            {
                foreground = Color.FromName("red");
                background = Color.FromName("white");
            }

            this.ForeColor = foreground;
            this.BackColor = background;
        } 

        public void reset() { }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        public void OnTimerExpired()
        {
            Program.canShoutout = true; 
        }
    }
}
