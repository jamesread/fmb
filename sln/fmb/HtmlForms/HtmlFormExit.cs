using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class HtmlFormExit : HtmlForm
    {
        public HtmlFormExit()
        {
            this.AddElementSubmit();
            this.Title = "Exit FMB?";
        }

        internal override void Process()
        {
            Program.Exit();
        }
    }
}
