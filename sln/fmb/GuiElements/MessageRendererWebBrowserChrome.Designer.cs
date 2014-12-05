namespace fmb.GuiElements
{
    partial class MessageRendererWebBrowserChrome
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageRendererWebBrowser = new CefSharp.WinForms.WebView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.messageRendererWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageRendererWebBrowser.AutoSize = true;
            this.messageRendererWebBrowser.Location = new System.Drawing.Point(60, 60);
            this.messageRendererWebBrowser.Name = "label1";
            this.messageRendererWebBrowser.Size = new System.Drawing.Size(35, 13);
            this.messageRendererWebBrowser.TabIndex = 0;
            this.messageRendererWebBrowser.Text = "label1";
            this.Controls.Add(this.messageRendererWebBrowser);
            this.Name = "MessageRendererWebBrowserChrome";
            this.Size = new System.Drawing.Size(214, 150);
            this.ResumeLayout(false);  
            this.PerformLayout();

        }

        #endregion

        private CefSharp.WinForms.WebView messageRendererWebBrowser;

    }
}
