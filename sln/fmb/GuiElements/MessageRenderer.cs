using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    public interface MessageRenderer
    { 
        void render(DisplayableMessageArguments message);

        void OnTimerExpired(); 

        void reset();
    }
}  
