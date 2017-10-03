// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AccenturePeople.iOS
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableContacts { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TableContacts != null) {
                TableContacts.Dispose ();
                TableContacts = null;
            }
        }
    }
}