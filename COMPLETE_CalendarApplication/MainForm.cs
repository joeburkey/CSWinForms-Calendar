using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

// Main form class for the Calendar application.
//
// The only change that should be made if required
// is the location of the appointments file. By
// default, this will be in your local profile so that
// it is always somewhere that can be written to. You
// might want to change it for testing purposes.

// Feel free to explore this code. I make no claims 
// that this code is the most efficent way of doing 
// things or that there are no bugs in the code.
// If you find bugs, let me know and I'll fix them.
// However, there should be no bugs that affect this
// assignment if you implement the assignment according
// to the specification.
//


namespace Calendar
{
    public partial class MainForm : Form
    {
        IAppointments _Appointments;
        IAppointments _TodaysAppointments;
        IAppointment _SelectedAppointment;
        int _SelectedRow;
        
        // Number of pixels in a row in the panel
        const int PanelRowHeight = 40;
        
        // X offset from left of panel to the start of
        // an appointment block
        const int ApptOffset = 50;

        public MainForm()
        {
            InitializeComponent();
        }

        // Replace the contents of mTodaysAppointments with
        // the appointments for the specified date.

        private void GetAppointmentsOnSelectedDate(DateTime date)
        {
            _TodaysAppointments.Clear();
            foreach (IAppointment appointment in _Appointments.GetAppointmentsOnDate(date))
            {
                _TodaysAppointments.Add(appointment);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _Appointments = new Appointments();

            // Initialise everything for 9am on today's date
            _TodaysAppointments = new Appointments();
            labelDisplayedDate.Text = DateTime.Now.ToLongDateString();
            GetAppointmentsOnSelectedDate(DateTime.Now);
            vScrollBar.Height = panelDailyView.ClientRectangle.Size.Height;
            vScrollBar.Maximum = 47 - (panelDailyView.ClientRectangle.Size.Height / PanelRowHeight);
            // 18 is the bar corresponding to 9am.
            vScrollBar.Value = 18;
            _SelectedRow = 18;
        }

        private void panelDailyView_Paint(object sender, PaintEventArgs e)
        {
            int paintWidth = panelDailyView.ClientRectangle.Size.Width - vScrollBar.Width;
            int paintHeight = panelDailyView.ClientRectangle.Size.Height;
            int displayedRowCount = paintHeight / PanelRowHeight;
            int panelTopRow;
            int nextRow;
            int apptStartRow;
            int apptLength;
            string dispTime; 
            
            Font font = new Font("Arial", 10);
            Brush drawBrush = new SolidBrush(Color.DarkBlue);
            Brush appointmentBrush = new SolidBrush(Color.LightBlue);

            Graphics g = e.Graphics;
            // Fill the background of the panel
            g.FillRectangle(new SolidBrush(Color.Linen), 0, 0, paintWidth, paintHeight);
            panelTopRow = vScrollBar.Value;
            if (_SelectedRow >= panelTopRow &&
                _SelectedRow <= panelTopRow + displayedRowCount)
            {
                // If the selected time is displayed, mark it
                g.FillRectangle(new SolidBrush(Color.DarkKhaki), 
                                0, 
                                (_SelectedRow - panelTopRow) * PanelRowHeight,
                                paintWidth,
                                PanelRowHeight);
            }
            // Display the times at the start of the rows and
            // the lines separating the rows
            nextRow = panelTopRow;
            for (int i = 0; i <= displayedRowCount; i++)
            {
                dispTime = (nextRow / 2).ToString("0#") + (nextRow % 2 == 0 ? ":00" : ":30");
                nextRow++;
                g.DrawString(dispTime, font, drawBrush, 2, (i * PanelRowHeight + 4));
                g.DrawLine(Pens.DarkBlue, 0, i * PanelRowHeight, paintWidth, i * PanelRowHeight);
            }
            // Now fill in the appointments
            foreach (IAppointment appointment in _TodaysAppointments)
            {
                apptStartRow = Utility.ConvertTimeToRow(appointment.Start);
                apptLength = Utility.ConvertLengthToRows(appointment.Length);
                // See if the appointment is inside the part of the day displayed on the panel
                if (((apptStartRow >= panelTopRow) && 
                     (apptStartRow <= panelTopRow + displayedRowCount)) ||
                    (apptStartRow + apptLength > panelTopRow))
                {
                    // Calculate the area of the panel occupied by
                    // the appointment
                    if (apptStartRow < panelTopRow)
                    {
                        apptLength = apptLength - (panelTopRow - apptStartRow);
                        apptStartRow = panelTopRow;
                    }
                    int apptDispStart = (apptStartRow - panelTopRow) * PanelRowHeight;
                    int apptDispLength = apptLength * PanelRowHeight;
                    if (apptDispStart + apptDispLength > paintHeight)  
                    {
                        apptDispLength = paintHeight - apptDispStart;
                    }
                    Rectangle apptRectangle = new Rectangle(ApptOffset,
                                                            apptDispStart,
                                                            paintWidth - (ApptOffset * 2),
                                                            apptDispLength);
                    // Draw the block of light blue
                    g.FillRectangle(appointmentBrush,
                                    apptRectangle);
                    // Draw the black line around it
                    g.DrawRectangle(Pens.Black, apptRectangle);
                    if (Utility.ConvertTimeToRow(appointment.Start) >= panelTopRow)
                    {
                        // If the top line of the appointment is displayed,
                        // write out the subject and location.  Temporarily
                        // reduce the clip area for the graphics object to ensure
                        // that the text does not extend beyond the rectangle
                        Region oldClip = g.Clip;
                        g.Clip = new Region(apptRectangle);
                        g.DrawString(appointment.DisplayableDescription,
                                     font,
                                     drawBrush,
                                     ApptOffset + 6,
                                     apptDispStart + 4);
                        g.Clip = oldClip;
                    }
                }
            }
        }

        private void panelDailyView_Resize(object sender, EventArgs e)
        {
            int oldMax = vScrollBar.Maximum;

            // Adjust the scroll bar range to reflect the
            // fact that the number of rows on the panel may
            // be different
            vScrollBar.Maximum = 47 - (panelDailyView.ClientRectangle.Size.Height / PanelRowHeight);
            if (vScrollBar.Value == oldMax)
            {
                vScrollBar.Value = vScrollBar.Maximum;
            }
            // Force a repaint of the panel
            panelDailyView.Invalidate();
        }

        private void panelDailyView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // See if we are on an appointment. If
                // so, display the context menu.
                IAppointment appointment = CheckForAppointment(e);
                if (appointment != null)
                {
                    _SelectedAppointment = appointment;
                    contextMenuStrip.Show(panelDailyView, new Point(e.X, e.Y));
                }
            }
            else
            {
                // Calculate the new selected row and force
                // a repaint of the panel
                int y = e.Y / PanelRowHeight;
                _SelectedRow = y + vScrollBar.Value;
                panelDailyView.Invalidate();
            }
        }

        private void panelDailyView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            IAppointment appointment = CheckForAppointment(e);
            if (appointment != null)
            {
                
            }
        }        

        private IAppointment CheckForAppointment(MouseEventArgs e)
        {
            bool matchFound = false;
            IAppointment appointment = null;

            if (e.X < ApptOffset ||
                e.X > panelDailyView.ClientRectangle.Size.Width - vScrollBar.Width - ApptOffset)
            {
                // The X co-ordinate is not inside an appointment, so simply exit
                return null;
            }
            // Determine the row corresponding to the mouse position
            int row = e.Y / PanelRowHeight + vScrollBar.Value;
            // Look through todays appointments to see if we
            // are positioned on any of them
            IEnumerator<IAppointment> enumerator = _TodaysAppointments.GetEnumerator();
            while (enumerator.MoveNext() && !matchFound)
            {
                int apptRow = Utility.ConvertTimeToRow(enumerator.Current.Start);
                int apptLength = Utility.ConvertLengthToRows(enumerator.Current.Length);
                if (row >= apptRow &&
                    row <= apptRow + apptLength - 1)
                {
                    matchFound = true;
                    appointment = enumerator.Current;
                }
            }
            return appointment;
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            panelDailyView.Invalidate();
        }
        
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            labelDisplayedDate.Text = monthCalendar.SelectionRange.Start.ToLongDateString();
            GetAppointmentsOnSelectedDate(monthCalendar.SelectionRange.Start);
            // Force repaint of daily view panel
            panelDailyView.Invalidate();
        }

        private void buttonNewAppt_Click(object sender, EventArgs e)
        {
            NewAppointment();
        }

        private void newAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewAppointment();
        }

        private void NewAppointment()
        {
            // TODO - You need to complete this method
            AppointmentSingle eappForm = new AppointmentSingle(_SelectedAppointment, 1, monthCalendar.SelectionStart);
            eappForm.ShowDialog(); // Single Appointment
            if (eappForm.saved)
            {
                _Appointments.Add(eappForm._SelectedAppointment);
                GetAppointmentsOnSelectedDate(monthCalendar.SelectionRange.Start);
                // Force repaint of daily view panel
                panelDailyView.Invalidate();
                _Appointments.Save();
            }
        }

        private void buttonNewReccuringAppt_Click(object sender, EventArgs e)
        {
            NewRecurringAppointment();
        }

        private void newRecurringAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRecurringAppointment();
        }

        private void NewRecurringAppointment()
        {
            // TODO - You need to complete this method
            AppointmentRec eappForm = new AppointmentRec(_SelectedAppointment, 1, monthCalendar.SelectionStart);
            eappForm.ShowDialog(); // Recurring Appointment
            if (eappForm.saved)
            {
                _Appointments.Add(eappForm._SelectedAppointment);
                GetAppointmentsOnSelectedDate(monthCalendar.SelectionRange.Start);
                // Force repaint of daily view panel
                panelDailyView.Invalidate();
                _Appointments.Save();
            }            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Raised by selecting Edit on the content menu

            // TODO - You need to complete this method. 
            // _SelectedAppointment is set to the instance of the appointment to be edited
            if (((Appointment)_SelectedAppointment).TypeRecurring == 0)
            {
                AppointmentSingle eappForm = new AppointmentSingle(_SelectedAppointment, 0, monthCalendar.SelectionStart);
                eappForm.ShowDialog(); // Single Appointment
                if (_SelectedAppointment.Start != eappForm._SelectedAppointment.Start ||
                    _SelectedAppointment.Length != eappForm._SelectedAppointment.Length ||
                    _SelectedAppointment.DisplayableDescription != eappForm._SelectedAppointment.DisplayableDescription ||
                    ((Appointment)_SelectedAppointment).TypeRecurring != ((Appointment)eappForm._SelectedAppointment).TypeRecurring ||
                    ((Appointment)_SelectedAppointment).Times != ((Appointment)eappForm._SelectedAppointment).Times)
                { // If objects are different, we should update table and Save new edited appointment
                    _Appointments.Remove(_SelectedAppointment);
                    _Appointments.Add(eappForm._SelectedAppointment);
                    GetAppointmentsOnSelectedDate(monthCalendar.SelectionRange.Start);
                    // Force repaint of daily view panel
                    panelDailyView.Invalidate();
                    _Appointments.Save();
                }
            }
            else
            {
                AppointmentRec eappForm = new AppointmentRec(_SelectedAppointment, 0, monthCalendar.SelectionStart);
                eappForm.ShowDialog(); // Recurring Appointment
                if (_SelectedAppointment.Start != eappForm._SelectedAppointment.Start ||
                    _SelectedAppointment.Length != eappForm._SelectedAppointment.Length ||
                    _SelectedAppointment.DisplayableDescription != eappForm._SelectedAppointment.DisplayableDescription ||
                    ((Appointment)_SelectedAppointment).TypeRecurring != ((Appointment)eappForm._SelectedAppointment).TypeRecurring ||
                    ((Appointment)_SelectedAppointment).Times != ((Appointment)eappForm._SelectedAppointment).Times)
                { // If objects are different, we should update table and Save new edited appointment
                    _Appointments.Remove(_SelectedAppointment);
                    _Appointments.Add(eappForm._SelectedAppointment);
                    GetAppointmentsOnSelectedDate(monthCalendar.SelectionRange.Start);
                    // Force repaint of daily view panel
                    panelDailyView.Invalidate();
                    _Appointments.Save();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Raised by selecting Delete on the content menu

            // TODO - You need to complete this method
            // _SelectedAppointment is set to the instance of the appointment to be deleted
            if (_Appointments.Contains(_SelectedAppointment))
            {
                _Appointments.Remove(_SelectedAppointment);
                GetAppointmentsOnSelectedDate(monthCalendar.SelectionRange.Start);
                // Force repaint of daily view panel
                panelDailyView.Invalidate();
                _Appointments.Save();
            }
        }
    }
}