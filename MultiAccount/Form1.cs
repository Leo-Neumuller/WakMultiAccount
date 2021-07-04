using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiAccount
{
    public partial class Form1 : Form
    {
        handle_key handlekey;
        bool started = false;
        bool lockform = true;

        public Form1()
        {
            InitializeComponent();
            listViewWithReordering1.item_drag_drop_event += new EventHandler<ItemDragDropEventArg>(item_listview_dragdrop);
            this.TopMost = true;
        }

        private void item_listview_dragdrop(object sender, ItemDragDropEventArg e)
        {
            Console.WriteLine(e.drag + " " + e.to);
            Process tmp = handlekey.changewindow.procs[e.drag];
            handlekey.changewindow.procs.RemoveAt(e.drag);
            handlekey.changewindow.procs.Insert(e.to, tmp);
            for (int i = 0; i < handlekey.changewindow.procs.Count; i++)
            {
                Console.WriteLine(handlekey.changewindow.procs[i].Id.ToString() + " " + i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (started == true)
            {
                for (int i = listViewWithReordering1.Items.Count - 1; i >= 0; i--)
                {
                    listViewWithReordering1.Items[i].Remove();
                }
                handlekey.stop_handle_key();
            }
            handlekey = new handle_key();

            started = true;
            handlekey.start_handle_key();
            for (int i = 0; i < handlekey.changewindow.procs.Count; i++)
            {
                listViewWithReordering1.Items.Add(new ListViewItem(handlekey.changewindow.procs[i].Id.ToString()));
            }
        }

        private void listViewWithReordering1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo item = listViewWithReordering1.HitTest(e.X, e.Y);

            if (item.Item == null)
                return;
            handlekey.changewindow.change_to_index(item.Item.Index);
        }

        private void listViewWithReordering1_DoubleClick(object sender, EventArgs e)
        {
            if (listViewWithReordering1.CheckedItems.Count == 1)
            {
                handlekey.changewindow.change_to_index(listViewWithReordering1.CheckedItems[0].Index);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lockform)
            {
                lockform = false;
                this.TopMost = false;
                button2.Text = "lock form";
            } else
            {
                lockform = true;
                this.TopMost = true;
                button2.Text = "delock form";
            }
        }
    }
}
