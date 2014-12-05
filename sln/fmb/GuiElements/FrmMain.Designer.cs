using fmb.GuiElements;

namespace fmb
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniExitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.showMainFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageRendererPresentation1 = new fmb.MessageRendererPresentation();
            this.messageRendererVideo1 = new fmb.MessageRendererVideo();
            this.messageRendererError1 = new fmb.MessageRendererTextMessage();
            this.messageRendererWebBrowser = new fmb.GuiElements.MessageRendererWebBrowserChrome(); 
            this.mnuTrayIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.mnuTrayIcon;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Main Tray Icon";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // mnuTrayIcon
            // 
            this.mnuTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniExitToolStrip,
            this.showMainFormToolStripMenuItem});
            this.mnuTrayIcon.Name = "mnuTrayIcon";
            this.mnuTrayIcon.Size = new System.Drawing.Size(163, 48);
            // 
            // mniExitToolStrip
            // 
            this.mniExitToolStrip.Name = "mniExitToolStrip";
            this.mniExitToolStrip.Size = new System.Drawing.Size(162, 22);
            this.mniExitToolStrip.Text = "Exit";
            this.mniExitToolStrip.Click += new System.EventHandler(this.mniExitToolStrip_Click);
            // 
            // showMainFormToolStripMenuItem
            // 
            this.showMainFormToolStripMenuItem.Name = "showMainFormToolStripMenuItem";
            this.showMainFormToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.showMainFormToolStripMenuItem.Text = "Show main form";
            this.showMainFormToolStripMenuItem.Click += new System.EventHandler(this.showMainFormToolStripMenuItem_Click);
            // 
            // messageRendererPresentation1
            // 
            this.messageRendererPresentation1.BackColor = System.Drawing.Color.Black;
            this.messageRendererPresentation1.ForeColor = System.Drawing.Color.White;
            this.messageRendererPresentation1.Location = new System.Drawing.Point(313, 229);
            this.messageRendererPresentation1.Name = "messageRendererPresentation1";
            this.messageRendererPresentation1.Size = new System.Drawing.Size(307, 216);
            this.messageRendererPresentation1.TabIndex = 6;
            // 
            // messageRendererVideo1
            // 
            this.messageRendererVideo1.Location = new System.Drawing.Point(12, 9);
            this.messageRendererVideo1.Name = "messageRendererVideo1";
            this.messageRendererVideo1.Size = new System.Drawing.Size(292, 202);
            this.messageRendererVideo1.TabIndex = 5;
            // 
            // messageRendererError1
            // 
            this.messageRendererError1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.messageRendererError1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageRendererError1.Location = new System.Drawing.Point(313, 9);
            this.messageRendererError1.Name = "messageRendererError1";
            this.messageRendererError1.Size = new System.Drawing.Size(301, 202);
            this.messageRendererError1.TabIndex = 2;
            this.messageRendererError1.Text = "[ ERROR ]";
            this.messageRendererError1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // messageRendererWebBrowser
            // 
            this.messageRendererWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageRendererWebBrowser.Location = new System.Drawing.Point(12, 229);
            this.messageRendererWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.messageRendererWebBrowser.Name = "messageRendererWebBrowser";
            this.messageRendererWebBrowser.Size = new System.Drawing.Size(295, 216);
            this.messageRendererWebBrowser.TabIndex = 0;
            this.messageRendererWebBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowser_PreviewKeyDown);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(632, 457);
            this.Controls.Add(this.messageRendererPresentation1);
            this.Controls.Add(this.messageRendererVideo1);
            this.Controls.Add(this.messageRendererError1);
            this.Controls.Add(this.messageRendererWebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "fmb";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyUp);
            this.mnuTrayIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }
         
        #endregion
          
        internal MessageRendererWebBrowserChrome messageRendererWebBrowser; 
        internal MessageRendererTextMessage messageRendererError1;
        internal MessageRendererVideo messageRendererVideo1;
        internal MessageRendererPresentation messageRendererPresentation1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip mnuTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem mniExitToolStrip;
        private System.Windows.Forms.ToolStripMenuItem showMainFormToolStripMenuItem;
    }
} 

