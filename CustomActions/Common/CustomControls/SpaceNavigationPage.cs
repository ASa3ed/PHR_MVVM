using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomActions.Common.CustomControls
{
    public class SpaceNavigationPage : NavigationPage
    {
        public SpaceNavigationPage(Page root) : base(root)
        {
            //BarBackgroundColor = Color.DarkBlue;
            //BarTextColor = Color.White;
            FontAttributes = FontAttributes.Italic;
        }

        public FontAttributes FontAttributes { get; private set; }
    }
}
