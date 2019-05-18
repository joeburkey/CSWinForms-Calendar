using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class AppointmentRec : Form
    {
        public bool saved;
        public int _model;
        public DateTime _starting;
        public IAppointment _SelectedAppointment;
        public AppointmentRec(IAppointment _SelectedAppointment_, int model, DateTime starting)
        {
            saved = false;
            InitializeComponent();
            _model = model;
            if (model == 0)
            {
                _SelectedAppointment = _SelectedAppointment_;

                Subject.Text = getSubject(_SelectedAppointment.DisplayableDescription);
                Subject.SelectionStart = Subject.Text.Length;
                Subject.SelectionLength = 0;
                Location1.Text = getLocation(_SelectedAppointment.DisplayableDescription);
                Location1.SelectionStart = Location1.Text.Length;
                Location1.SelectionLength = 0;

                Datum.Text = _SelectedAppointment.Start.Date.ToString("dd MMMM yyyy");
                comboBox1.SelectedIndex = Utility.ConvertTimeToRow(_SelectedAppointment.Start);
                comboBox2.SelectedIndex = (_SelectedAppointment.Length / 30) - 1;
                comboBox3.SelectedIndex = ((Appointment)_SelectedAppointment).TypeRecurring - 1;
                textBox1.Text = ((Appointment)_SelectedAppointment).Times.ToString();
            }
            else
            {
                _starting = starting;
                Datum.Text = starting.Date.ToString("dd MMMM yyyy");
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                textBox1.Text = "1";
            }
                            
        }

        private void Subject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',' || e.KeyChar == '(' || e.KeyChar == ')')
            {
                e.Handled = true;
                // Disable these characters in these textboxes, because that's how we devide string into Subject, Location etc...
            }
        }

        private void Location_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',' || e.KeyChar == '(' || e.KeyChar == ')')
            {
                e.Handled = true;
                // Disable these characters in these textboxes, because that's how we devide string into Subject, Location etc...
            }
        }
        public string getSubject(string Description)
        {
            string subject = "";
            for (int i = 0; i < Description.Length; i++)
            {
                if (Description[i] != ',') subject += Description[i];
                else break;
            }
            return subject;
        }
        public string getLocation(string Description)
        {
            string location = "";
            int i = 0;
            for (i = 0; i < Description.Length; i++) // Jump over the Subject
            {
                if (Description[i] == ',') break;
            }
            i = i + 2; // Jump over ', ' -> two letters
            int k = i;
            for (k = i; k < Description.Length; k++)
            {
                if (k + 1 < Description.Length && (Description[k] != ' ' || Description[k + 1] != '('))
                    location += Description[k];
                else break;
            }
            return location;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "";
            if (Subject.Text.Length <= 0)
                message += "You must define Subject!";
            if (Location1.Text.Length <= 0)
            {
                if (message.Length > 0)
                    message += "\n";
                message += "You must define Location!";
            }
            if (message.Length > 0)
                MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                // Edit this Appointment info
                DateTime newStart;
                if (_model==0) 
                    newStart = Utility.ConvertRowToDateTime(_SelectedAppointment.Start, comboBox1.SelectedIndex);
                else                
                    newStart = Utility.ConvertRowToDateTime(_starting, comboBox1.SelectedIndex);
                int newLength = (comboBox2.SelectedIndex + 1) * 30;
                string recurring="(Recurring "+comboBox3.SelectedItem.ToString()+")";
                string newDescription = Subject.Text + ", " + Location1.Text+" "+recurring;
                int newTimes = Int32.Parse(textBox1.Text);
                int newTypeRecurring=comboBox3.SelectedIndex+1;
                _SelectedAppointment = new Appointment(newStart, newLength, newDescription, newTypeRecurring, newTimes);
                saved = true;
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(textBox1.Text) < 1)
            {
                MessageBox.Show("This number must be >=1 and <=999", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Text = "1";  
            }
            else if (Int32.Parse(textBox1.Text) > 999)
            {
                MessageBox.Show("This number must be >=1 and <=999", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Text = "999";
            }
        }
    }
}
