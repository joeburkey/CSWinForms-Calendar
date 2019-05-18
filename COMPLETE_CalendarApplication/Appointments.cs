using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calendar
{    
    class Appointments : List<IAppointment>, IAppointments
    {
        public Appointments() {}
        public bool Load()
        {
            string path = @"c:\temp\Appointments.txt";
            //string path_help = @"c:\temp\help.txt";
            string line1 = null;
            string line2 = null;
            string line3 = null;
            string line4 = null;
            string line5 = null;
            try {
                using (TextReader reader = File.OpenText(path))
                {
                   //using (TextWriter writer = File.CreateText(path_help))
                   //{
                        string line = reader.ReadLine();
                        bool ok = true;
                        while (line != null && line.Length > 0)
                        {
                            ok = true;
                            line1 = line;
                            if (line1 != null && line1.Length > 0)
                                line2 = reader.ReadLine();
                            else ok = false;
                            if (line2 != null && line2.Length > 0)
                                line3 = reader.ReadLine();
                            else ok = false;
                            if (line3 != null && line3.Length > 0)
                                line4 = reader.ReadLine();
                            else ok = false;
                            if (line4 != null && line4.Length > 0)
                                line5 = reader.ReadLine();
                            else ok = false;
                            /*try
                            {
                                writer.WriteLine(DateTime.Parse(line1).ToString("dd.MM.yyyy HH:mm:ss"));
                            }
                            catch (Exception e)
                            {
                                writer.WriteLine(e.Message);
                            }*/ 
                            if (ok)
                                this.Add(new Appointment(DateTime.Parse(line1), int.Parse(line2), line3, int.Parse(line4), int.Parse(line5)));
                            line = reader.ReadLine();                            
                        }    
                   //}                                   
                }
            }
            catch {
                return false;
            }
            return true;
        }
        public bool Save()
        {
            string path = @"c:\temp\Appointments.txt";
            try
            {
                using (TextWriter writer = File.CreateText(path))
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        writer.WriteLine(this.ElementAt(i).Start.ToString("dd.MM.yyyy HH:mm:ss"));
                        writer.WriteLine(this.ElementAt(i).Length.ToString());
                        writer.WriteLine(this.ElementAt(i).DisplayableDescription);
                        writer.WriteLine(((Appointment) this.ElementAt(i)).TypeRecurring.ToString());
                        writer.WriteLine(((Appointment) this.ElementAt(i)).Times.ToString());
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public IEnumerable<IAppointment> GetAppointmentsOnDate(DateTime date)
        {
            List <IAppointment> AppointmentsOnDateList = new List<IAppointment>();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.ElementAt(i).OccursOnDate(date))                
                    AppointmentsOnDateList.Add(this.ElementAt(i));                
            }
            IEnumerable<IAppointment> AppointmentsOnDate = AppointmentsOnDateList;
            return AppointmentsOnDate;
        }
    }
}
