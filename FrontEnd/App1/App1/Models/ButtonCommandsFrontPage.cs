using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.Models
{
    class ButtonCommandsFrontPage
    {

    public ButtonCommandsFrontPage()
        {
            //GoToAddNewList = new Command( () => 2);
        }


    public ICommand GoToAddSpecialItem { private set; get; } 

    public ICommand GoToAddNewList { private set; get; }


    }
}
