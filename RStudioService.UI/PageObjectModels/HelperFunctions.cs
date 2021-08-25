using System;
using System.Threading;

namespace RStudioService.UI
{
   public  class HelperFunctions
    {
       //Thred Sleep function to wait for a fixed amount of time incase if we need it
        public static void Pause(int timeToPause = 1000)
        {
            Thread.Sleep(timeToPause);

        }

        
    }
}
