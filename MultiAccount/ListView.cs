using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiAccount
{

    public class ItemDragDropEventArg : EventArgs
    {
        public int drag { get; set; }
        public int to { get; set; }
        public ItemDragDropEventArg(int drag, int to)
        {
            this.drag = drag;
            this.to = to;
        }
    }
    public class ListViewWithReordering : ListView
    {
        public event EventHandler<ItemDragDropEventArg> item_drag_drop_event;
        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            base.OnItemDrag(e);
            //Begins a drag-and-drop operation in the ListView control.
            this.DoDragDrop(this.SelectedItems, DragDropEffects.Move);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
            int len = drgevent.Data.GetFormats().Length - 1;
            int i;
            for (i = 0; i <= len; i++)
            {
                if (drgevent.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    //The data from the drag source is moved to the target.	
                    drgevent.Effect = DragDropEffects.Move;
                }
            }

        }

        protected virtual void OnDragDropInList(int drag, int to)
        {
            var localcopy = item_drag_drop_event;

            item_drag_drop_event(this, new ItemDragDropEventArg(drag, to));
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            //Return if the items are not selected in the ListView control.
            if (this.SelectedItems.Count == 0)
            {
                return;
            }
            //Returns the location of the mouse pointer in the ListView control.
            Point cp = this.PointToClient(new Point(drgevent.X, drgevent.Y));
            //Obtain the item that is located at the specified location of the mouse pointer.
            ListViewItem dragToItem = this.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }
            //Obtain the index of the item at the mouse pointer.
            int dragIndex = dragToItem.Index;
            ListViewItem[] sel = new ListViewItem[this.SelectedItems.Count];
            for (int i = 0; i <= this.SelectedItems.Count - 1; i++)
            {
                sel[i] = this.SelectedItems[i];
            }
            for (int i = 0; i < sel.GetLength(0); i++)
            {
                //Obtain the ListViewItem to be dragged to the target location.
                ListViewItem dragItem = sel[i];
                int itemIndex = dragIndex;
                if (itemIndex == dragItem.Index)
                {
                    return;
                }
                if (dragItem.Index < itemIndex)
                    itemIndex++;
                else
                    itemIndex = dragIndex + i;
                OnDragDropInList(dragItem.Index, dragToItem.Index);
                //Insert the item at the mouse pointer.
                ListViewItem insertItem = (ListViewItem)dragItem.Clone();
                this.Items.Insert(itemIndex, insertItem);
                //Removes the item from the initial location while 
                //the item is moved to the new location.
                this.Items.Remove(dragItem);
            }
        }
    }
}