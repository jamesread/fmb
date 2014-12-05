namespace fmb
{
    partial class MessageRendererPresentation : MessageRenderer
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
            this.components = new System.ComponentModel.Container();
            this.txt = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.nextSlideTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.processLabelTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.Location = new System.Drawing.Point(4, 7);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(274, 78);
            this.txt.TabIndex = 0;
            this.txt.Text = "[PRESENTATION]";
            this.txt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Red;
            this.pic.Location = new System.Drawing.Point(0, 88);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(278, 72);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 1;
            this.pic.TabStop = false;
            // 
            // nextSlideTimer
            // 
            this.nextSlideTimer.Interval = 3000;
            this.nextSlideTimer.Tick += new System.EventHandler(this.nextSlideTimer_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTimer.Location = new System.Drawing.Point(0, 142);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(57, 13);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "Timer: ???";
            // 
            // processLabelTimer
            // 
            this.processLabelTimer.Interval = 500;
            this.processLabelTimer.Tick += new System.EventHandler(this.processLabelTimer_Tick);
            // 
            // MessageRendererPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.txt);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MessageRendererPresentation";
            this.Size = new System.Drawing.Size(274, 155);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Timer nextSlideTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer processLabelTimer;
    }
}
