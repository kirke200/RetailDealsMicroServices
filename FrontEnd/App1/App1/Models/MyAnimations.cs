using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Models
{
    public class MyAnimations
    {
        public void TranslateStackLayout(StackLayout sl, double x, double y, uint length, Easing esFunc )
        {
            sl.TranslateTo(x, y, length, esFunc);
        }
    }
}
