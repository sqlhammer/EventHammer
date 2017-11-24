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
        List<Event> AllEvents = new List<Event>();

        public frmEventManager()
        {
            InitializeComponent();
        }

        private void frmEventManager_Load(object sender, EventArgs e)
        {
            RefreshAllEvents();
            this.cbView.SelectedIndex = 1;
            foreach(Event Event in AllEvents)
            {
                ListViewItem item = new ListViewItem(Event.EventName);
                item.SubItems.Add(Event.EventTypeName);
                item.SubItems.Add(Event.Date.ToString("MM/dd/yyyy"));
                this.lstvEvents.Items.Add(item);
            }
            this.lstvEvents.Refresh();
        }

        private void RefreshAllEvents()
        {
            AllEvents = DataAccess.GetEventInformation();
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.cbView.SelectedText)
            {
                case "Tile": { this.lstvEvents.View = View.Tile; break; }
                case "Large Icon": { this.lstvEvents.View = View.LargeIcon; break; }
                case "Detail": { this.lstvEvents.View = View.Details; break; }
            }
            this.lstvEvents.Refresh();
        }
    }
}
