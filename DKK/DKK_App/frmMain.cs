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
    public partial class frmMain : Form
    {
        public Event CurrentEvent = new Event();
        public List<Event> AllEvents = new List<Event>();

        public frmMain()
        {
            InitializeComponent();
        }

        #region EventTriggers
        private void pbCompany_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.danburykarate.com");
        }

        private void pbCompany_MouseEnter(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbCompany_MouseHover(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbCompany_MouseLeave(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void pbPoweredBy_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.sqlhammer.com");
        }
        
        private void pbPoweredBy_MouseEnter(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbPoweredBy_MouseHover(object sender, System.EventArgs e)
        {           
            this.Cursor = Cursors.Hand;
        }

        private void pbPoweredBy_MouseLeave(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cbEventSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentEvent = AllEvents[this.cbEventSelect.SelectedIndex];
            EnableAllTabs();
            RefreshFormTitle();
            DisplayEventInformation();
        }

        private void dtpEventFrom_ValueChanged(object sender, EventArgs e)
        {
            RefreshAllEvents();
            RefreshEventSelect();
        }

        private void dtpEventTo_ValueChanged(object sender, EventArgs e)
        {
            RefreshAllEvents();
            RefreshEventSelect();
        }
        #endregion EventTriggers

        private void RefreshAllEvents()
        {
            AllEvents = DataAccess.GetEventInformationByDateRange(dtpEventFrom.Value,dtpEventTo.Value);
        }

        private Event SetCurrentEvent(List<Event> events)
        {
            return events.FirstOrDefault();
        }

        private void RefreshFormTitle()
        {
            CurrentEvent = SetCurrentEvent(AllEvents);
            this.Text = "Event Hammer - " + CurrentEvent.EventName + " - " + CurrentEvent.Date.ToString("MM/dd/yyyy");
        }

        private void RefreshEventSelect()
        {
            this.cbEventSelect.Items.Clear();
            foreach(Event Event in AllEvents)
            {
                this.cbEventSelect.Items.Add(Event.EventName + " - " + Event.Date.ToString("MM/dd/yyyy"));
            }
        }

        private void SetEventSearchDateRange()
        {
            DateTime minDate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime maxDate = new DateTime(DateTime.Now.Year + 1, 12, 31);

            this.dtpEventFrom.Value = minDate;
            this.dtpEventTo.Value = maxDate;
        }

        private void DisplayEventInformation()
        {
            this.txtEventInfo.Text = "Event Id:\t\t" + CurrentEvent.EventId.ToString();
            this.txtEventInfo.Text = this.txtEventInfo.Text + System.Environment.NewLine + "Event Name:\t" + CurrentEvent.EventName;
            this.txtEventInfo.Text = this.txtEventInfo.Text + System.Environment.NewLine + "Event Type:\t" + CurrentEvent.EventTypeName;
            this.txtEventInfo.Text = this.txtEventInfo.Text + System.Environment.NewLine + "Event Date:\t" + CurrentEvent.Date.ToString("MM/dd/yyyy");
        }

        private void EnableAllTabs()
        {
            foreach (TabPage pg in this.tab1.TabPages)
            {
                if (pg.Enabled == false)
                {
                    pg.Enabled = true;
                }
            }
        }

        private void DisableAllTabs()
        {
            foreach(TabPage pg in this.tab1.TabPages)
            {
                pg.Enabled = (pg.Name.CompareTo("tabHome") == 0);
            }
        }

        private void ToggleTabStatuses()
        {
            if(this.cbEventSelect.SelectedIndex != -1)
            {
                EnableAllTabs();
                return;
            }

            DisableAllTabs();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DisableAllTabs();
            SetEventSearchDateRange();
            RefreshAllEvents();
            RefreshEventSelect();
        }
    }
}
