using DKK_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DKK_App
{
    public partial class frmEditEvent : Form
    {
        public Event SelectedEvent = new Event();
        public List<EventType> EventTypes = new List<EventType>();
        public bool IsEdit = false;
        public frmEventManager EventManager;

        public frmEditEvent()
        {
            InitializeComponent();
        }

        public void InitializeNew()
        {
            IsEdit = false;
            this.Text = "Create New Event";
            this.txtName.Text = "";
            this.dtpDate.Value = DateTime.Now;
            foreach (EventType type in EventTypes)
            {
                this.cbType.Items.Add(type.EventTypeName);
            }
            this.cbType.SelectedIndex = 0;
        }

        public void InitializeEdit()
        {
            IsEdit = true;
            this.Text = "Edit Event";
            this.dtpDate.Value = SelectedEvent.Date;
            this.txtName.Text = SelectedEvent.EventName;
            foreach (EventType type in EventTypes)
            {
                this.cbType.Items.Add(type.EventTypeName);

                if (type.EventTypeName.CompareTo(SelectedEvent.EventType.EventTypeName) == 0)
                {
                    this.cbType.SelectedIndex = this.cbType.Items.Count - 1;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetForm()
        {
            if (IsEdit)
            {
                InitializeEdit();
            }
            else
            {
                InitializeNew();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void frmEditEvent_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private new void Close()
        {
            EventManager.RefreshList();
            base.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.lblStatus.Text = "";

            EventType type = DataAccess.GetEventTypeByName(this.cbType.SelectedItem.ToString()).First();

            if (EqualityComparer<EventType>.Default.Equals(type, default(EventType)))
            {
                this.lblStatus.Text = "Error: Invalid EventTypeId.";
            }

            Event Event = new Event
            {
                EventId = SelectedEvent.EventId,
                Date = this.dtpDate.Value,
                EventName = this.txtName.Text,
                EventType = type
            };

            if (IsEdit)
            {                
                DataAccess.UpdateEvent(Event);
                MessageBox.Show("Update complete.");
                this.Close();
            }
            else
            {
                DataAccess.InsertEvent(Event);
                MessageBox.Show("Creation complete.");
                this.Close();
            }
        }
    }
}
