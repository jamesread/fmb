using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace fmb 
{
    internal partial class MessageRendererPresentation : UserControl, MessageRenderer
    {
        public const string SLIDE_SEPARATOR = "!SEP_SLIDE";
        public const string DEFAULT_PRESENTATION = "slide1" + SLIDE_SEPARATOR + "slide2" + SLIDE_SEPARATOR + "slide3";
          
        List<PresentationSlide> slides = new List<PresentationSlide>();
        private int slideIndex = 0;
        private bool picIsRendered = false;
        private bool textIsRendered = false;

        public MessageRendererPresentation()
        { 
            InitializeComponent();
        } 
         
        public void reset() { 
            DisplayableMessageArguments dma = new DisplayableMessageArguments(this);
            dma.setArgument("message", "PRESENTATION\nWaiting for first slide.");
            this.slideIndex = 0;

            this.render(dma);
            processLabelTimer.Enabled = false; 
        }
         
        public void render(DisplayableMessageArguments args)
        {
            this.Invoke(new MethodInvoker(delegate{
                this.resizeControls(); // to handle a nice reset();

                this.allocate(args);
                nextSlideTimer.Enabled = true;
                processLabelTimer.Enabled = true;
            })); 
        }

        private void allocate(DisplayableMessageArguments args)
        { 
            string message = args.getArgument("message");

            this.slides.Clear();
            StringBuilder sb = new StringBuilder();

            try 
            {
                PresentationSlide.defaultSlideDelaySeconds = Int32.Parse(args.getArgument("defaultDelay"));
            }
            catch (Exception) 
            {
            } 

            foreach (string slideContent in Regex.Split(message, SLIDE_SEPARATOR)) {
                PresentationSlide slide = new PresentationSlide(slideContent);
                slides.Add(slide);  
            }  
        } 

        private void resizeControls()
        {
            int middle = this.Width / 2;

            txt.Top = 0;
            txt.Height = this.Height;
            pic.Top = 0;
            pic.Height = this.Height;

            if (picIsRendered && textIsRendered)
            {
                this.txt.Left = middle;
                this.txt.Width = middle;
                this.pic.Width = middle;
            } 
            else if (!picIsRendered && textIsRendered)
            {
                this.txt.Left = 0;
                this.txt.Width = this.Width;
                this.pic.Width = 0; 
            }  
            else
            {
            	this.txt.Left = this.Width;
            	this.txt.Width = 0;
            	this.pic.Width = this.Width;
            }
        }

        private void renderSlide() 
        {
            PresentationSlide slide = this.slides[slideIndex]; 
            this.txt.ForeColor = slide.getForeground();
            this.txt.BackColor = slide.getBackground();
            this.pic.BackColor = slide.getBackground();
            int fontSize = slide.getFontSize(); 

            this.txt.Font = new Font(this.txt.Font.FontFamily, fontSize);

            nextSlideTimer.Interval = slide.getDelayInMilliseconds();

            picIsRendered = false; 
            if (slide.getPicture() != null)
            {
                this.pic.ImageLocation = slide.getPicture().FullName;
                picIsRendered = true;
            }

            var textToDisplay = slide.GetText();
            textIsRendered = false;
            if (!string.IsNullOrWhiteSpace(textToDisplay))
            {
            	this.txt.Text = textToDisplay;
            	textIsRendered = true;
            }            
        }

        private void nextSlideTimer_Tick(object sender, EventArgs e)
        {           
            if (slides.Count == 0)
            {
                nextSlideTimer.Enabled = false;
                return; 
            }

            if ((this.slideIndex +1 )== this.slides.Count)
            {
                this.slideIndex = 0;
            }
            else  
            {
                this.slideIndex++;
            }

            started = DateTime.Now;
            this.renderSlide();
            this.resizeControls();
        }

        private DateTime started;  

        private void processLabelTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeTillNextSlide = (started.AddMilliseconds(nextSlideTimer.Interval)) - DateTime.Now;   
            lblTimer.Text = "Slide " + (this.slideIndex + 1) + " of " + this.slides.Count + ". Next slide: " + timeTillNextSlide.Seconds; 
        }

        public void OnTimerExpired() { }
    }
}
