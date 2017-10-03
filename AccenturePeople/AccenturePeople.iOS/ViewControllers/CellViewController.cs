using Foundation;
using System;
using UIKit;
using AccenturePeople.iOS.Models;

namespace AccenturePeople.iOS
{
    public partial class CellViewController : UITableViewCell
    {
        public CellViewController (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(DataModel dataThings)
        {
            name.Text = (string)dataThings.Name;
            description.Text = (string)dataThings.Description;
            image.Image = UIImage.FromFile((string)dataThings.Image);
        }
    }
}