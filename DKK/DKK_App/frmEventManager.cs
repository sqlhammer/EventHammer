using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DKK_App.Entities;

namespace DKK_App
{
    public partial class frmEventManager : Form
    {
        private List<Event> AllEvents = new List<Event>();

        public frmEventManager()
        {
            InitializeComponent();
        }

        private void frmEventManager_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
        {
            RefreshAllEvents();

            this.lstvEvents.Items.Clear();
            foreach (Event Event in AllEvents)
            {
                ListViewItem item = new ListViewItem(Event.EventId.ToString());
                item.SubItems.Add(Event.EventName);
                item.SubItems.Add(Event.EventType.EventTypeName);
                item.SubItems.Add(Event.Date.ToString("MM/dd/yyyy"));
                this.lstvEvents.Items.Add(item);
            }
            this.lstvEvents.Refresh();
        }

        private void RefreshAllEvents()
        {
            AllEvents = DataAccess.GetEventInformation();
        }

        private void ShowNewEventForm()
        {
            frmEditEvent frm = new frmEditEvent();
            frm.EventTypes = DataAccess.GetEventTypes();
            frm.IsEdit = false;
            frm.EventManager = this;
            frm.Show();
        }

        private void ShowEditEventForm()
        {
            /* Unnecessary because the ListView MultiSelect is set to false
            if(lstvEvents.SelectedItems.Count != 1)
            {
                MessageBox.Show("You must select one, and only one, event to edit at a time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            */

            int id = -1;

            foreach (ListViewItem item in lstvEvents.SelectedItems)
            {
                id = Convert.ToInt32(item.Text);
                break;
            }
            
            Event Event = DataAccess.GetEventInformationById(id);
            
            frmEditEvent frm = new frmEditEvent();

            frm.SelectedEvent = Event;
            frm.EventTypes = DataAccess.GetEventTypes();

            frm.IsEdit = true;
            frm.EventManager = this;
            frm.Show();
        }

        private void DeleteEvents()
        {
            int cnt = lstvEvents.SelectedItems.Count;
            DialogResult result = MessageBox.Show(String.Format("Permanently delete {0} event(s)?", cnt.ToString()), "Confirm permanent delete", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);

            if (result == DialogResult.OK)
            {
                result = MessageBox.Show(String.Format("This cannot be undone. Are you certain you want to delete?", cnt.ToString()), "Confirm permanent delete, again", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in lstvEvents.SelectedItems)
                    {
                        DataAccess.DeleteEvent(Convert.ToInt32(item.Text));
                    }
                }
            }            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ShowNewEventForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.lstvEvents.SelectedItems.Count > 0)
            {
                ShowEditEventForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lstvEvents.SelectedItems.Count > 0)
            {
                DeleteEvents();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
