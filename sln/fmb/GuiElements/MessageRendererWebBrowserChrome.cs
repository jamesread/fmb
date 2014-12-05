using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CefSharp;

namespace fmb.GuiElements
{
    public partial class MessageRendererWebBrowserChrome : UserControl, MessageRenderer
    {
        public MessageRendererWebBrowserChrome()  
        {
            var settings = new CefSharp.Settings
            {
                PackLoadingDisabled = true,
                
            };

            if (CEF.Initialize(settings))
            {
                InitializeComponent();
            }
            else
            { 
                Console.Out.WriteLine("CANNOT INITIALIZE");
            }
        }
         
        public void reset() 
        {
            if (CEF.IsInitialized)
            {
                Navigate(new Uri("about:blank?isReset"));
            }
        }

        public void Navigate(Uri uri) 
        {
            Console.Out.WriteLine("Navigating to: " + uri.ToString());
            
            if (this.messageRendererWebBrowser.IsBrowserInitialized)
            {
                this.messageRendererWebBrowser.Load(uri.ToString());
            }
        } 
        
        public void render(DisplayableMessageArguments args)
        {
            try
            {
                this.Navigate(new Uri(args.getArgument("url")));
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Web browser cannot navigate: " + e.ToString()); 
                this.reset();
            }
        }

        public void OnTimerExpired() { }
    } 
}
