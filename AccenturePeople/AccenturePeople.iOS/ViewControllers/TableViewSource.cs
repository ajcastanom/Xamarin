using System;
using System.Collections.Generic;
using AccenturePeople.iOS.Models;
using Foundation;
using UIKit;

namespace AccenturePeople.iOS
{
    internal class TableViewSource : UITableViewSource
    {
        private List<DataModel> menu;

        public TableViewSource(List<DataModel> menu)
        {
            this.menu = menu;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (CellViewController)tableView.DequeueReusableCell("mainCell", indexPath);
            var dataThings = menu[indexPath.Row];
            cell.UpdateCell(dataThings);
            return cell;

        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return menu.Count;
        }
    }
}