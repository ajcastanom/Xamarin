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

namespace AccenturePeoplePCL.iOS
{
    [Register ("CellViewController")]
    partial class CellViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel description { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel name { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (description != null) {
                description.Dispose ();
                description = null;
            }

            if (image != null) {
                image.Dispose ();
                image = null;
            }

            if (name != null) {
                name.Dispose ();
                name = null;
            }
        }
    }
}