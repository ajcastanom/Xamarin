using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using AccenturePeople.iOS.Models;

namespace AccenturePeople.iOS
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var menu = new List<DataModel>();

            menu.Add(new DataModel("Item 1", "D 1", ""));
            menu.Add(new DataModel("Item 2", "D 2", ""));
            menu.Add(new DataModel("Item 3", "D 3", ""));
            menu.Add(new DataModel("Item 4", "D 4", ""));

            TableContacts.Source = new TableViewSource(menu);
        }

        public override void DidReceiveMemoryWarning(){
            base.DidReceiveMemoryWarning();
        }
    }


}