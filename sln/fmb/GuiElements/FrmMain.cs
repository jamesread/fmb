using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Windows.Forms;

namespace fmb
{
    public partial class FrmMain : Form
    {
        private MessageRenderer renderer;

        public FrmMain()
        {
            InitializeComponent();
            registerMessageRenders();
        }

        internal MessageRenderer getRenderer()
        {
            return this.renderer; 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);  
        }

        internal void registerMessageRenders()
        {
            Program.scheduler.AddRenderer(this.messageRendererVideo1);
            Program.scheduler.AddRenderer(this.messageRendererWebBrowser); 
            Program.scheduler.AddRenderer(this.messageRendererError1);
            Program.scheduler.AddRenderer(this.messageRendererPresentation1);
        }

        public void InvokeSetBounds(int x, int y, int w, int h)
        {
            this.Invoke(new MethodInvoker(delegate()
            {  
                this.SetBounds(x, y, w, h);
                this.Focus();
                this.BringToFront();
            }));
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            this.HandleKeypress(e.KeyCode);
        }

        internal void ShowSingleControl(MessageRenderer renderer)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                Control controlToShow = (Control)renderer; 

                if (!this.Controls.Contains(controlToShow))
                { 
                    this.messageRendererError1.renderError("Showing control that does not belong to form!");
                    controlToShow = this.messageRendererError1;
                }

                foreach (Control controlToHide in this.Controls)
                {
                    controlToHide.Visible = false;

                    if (controlToHide is MessageRenderer)
                    {
                        ((MessageRenderer)controlToHide).reset();
                    }
                }

                this.renderer = renderer;
                this.renderer.reset(); 
                controlToShow.Visible = true;
                  
                this.Text = "fmb - " + controlToShow.GetType().Name;
            })); 
        }

        internal void windowsMediaPlayer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.HandleKeypress(e.KeyCode);
        }
         
        internal void ToggleFullscreen()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                if (this.FormBorderStyle == FormBorderStyle.None)
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }

                this.Focus();
            })); 
        }

        private void HandleKeypress(Keys k)
        {
            // manual debounce mechanism

            switch (k)
            { 
                case Keys.F1:
                    this.ShowSingleControl(messageRendererWebBrowser);
                    break;
                case Keys.F2:
                    this.ShowSingleControl(messageRendererVideo1);
                    break;
                case Keys.F3:
                    this.ShowSingleControl(messageRendererPresentation1);
                    break; 
                case Keys.F4: 
                    this.ShowSingleControl(messageRendererError1);
                    break; 
                case Keys.F11:
                    this.ToggleFullscreen();
                    break; 
                case Keys.F10:
                    String errors = "";
                    
                    foreach (String error in Program.errors) {
                    	errors += error + "\n";
                    } 
                     
                    FrmSelectableMessage.ShowMessage(errors);
                    break;
                case Keys.Escape:
                    Environment.Exit(0); 
                    break; 
                default: 
                    break;
            } 
        }

        private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.HandleKeypress(e.KeyCode);
        }

        internal void ToggleVisibility() {
            this.Invoke(new MethodInvoker(delegate
            { 
                this.Visible = !this.Visible;
            }));
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = !this.Visible;
            e.Cancel = true; 
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            messageRendererWebBrowser.Dock = DockStyle.Fill;
            messageRendererVideo1.Dock = DockStyle.Fill; 
            messageRendererError1.Dock = DockStyle.Fill;
            messageRendererPresentation1.Dock = DockStyle.Fill;
        }

        private void messageRendererPresentation1_Click(object sender, EventArgs e)
        {

        }

        private void messageRendererPresentation1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.HandleKeypress(e.KeyCode);
        }

        private void mniExitToolStrip_Click(object sender, EventArgs e)
        {
            Program.Exit();
        }

        private void showMainFormToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            this.Visible = true; 
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true; 
        }

        public void HideTrayIcon()
        {
            this.trayIcon.Visible = false;
            this.trayIcon.Dispose();
        }
          
        internal bool IsFullScreen()
        {
            return this.WindowState == FormWindowState.Normal;
        }
    }
}
