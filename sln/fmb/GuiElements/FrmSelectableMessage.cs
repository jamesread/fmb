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
    public partial class FrmSelectableMessage : Form
    {
        public FrmSelectableMessage()
        {
            InitializeComponent();
        }

        internal static void ShowException(Exception e)
        {
            FrmSelectableMessage frm = new FrmSelectableMessage();
            frm.Text = "fmb - Exception: " + e.GetType().Name;
            frm.textBox1.Text = e.Message;
            frm.textBox1.Text += e.StackTrace.ToString();
            frm.ShowDialog();   
        }

        internal static void ShowMessage(string p)
        {
            FrmSelectableMessage frm = new FrmSelectableMessage();
            frm.Text = "fmb - Message";
            frm.textBox1.Text = p;
            frm.ShowDialog();  
        }
    }
}
