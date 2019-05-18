using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class Appointment : IAppointment
    {
        private DateTime _Start;
        private int _Length;
        private string _DisplayableDescription;
        private int _TypeRecurring;
        private int _Times;
        public Appointment(DateTime _Start_, int _Length_, string _DisplayableDescription_, int _TypeRecurring_, int _Times_)
        {
            _Start = _Start_;
            _Length = _Length_;
            _DisplayableDescription = _DisplayableDescription_;
            _TypeRecurring = _TypeRecurring_;
            _Times = _Times_;
        }
        public DateTime Start { get { return _Start; } }
        public int Length { get { return _Length; } }
        public string DisplayableDescription { get { return _DisplayableDescription; } }
        public int TypeRecurring { get { return _TypeRecurring; } }
        public int Times { get { return _Times; } }

        public bool OccursOnDate(DateTime date)
        {
            if (_TypeRecurring == 0) // Single appointment
            {
                if (date.Date == _Start.Date) return true;
                return false;
            }
            else if (_TypeRecurring == 1)
            { // Daily
                for (int i = 0; i < _Times; i++)
                {
                    if (date.Date == _Start.AddDays(i).Date)
                        return true;
                }
                return false;
            }
            else if (_TypeRecurring == 2)
            { // Weekly
                for (int i = 0; i < _Times; i++)
                {
                    if (date.Date == _Start.AddDays(i * 7).Date)
                        return true;
                }
                return false;
            }
            else if (_TypeRecurring == 3)
            { // Monthly
                for (int i = 0; i < _Times; i++)
                {
                    if (date.Date == _Start.AddMonths(i).Date)
                        return true;
                }
                return false;
            }
            else if (_TypeRecurring == 4)
            { // Yearly
                for (int i = 0; i < _Times; i++)
                {
                    if (date.Date == _Start.AddYears(i).Date)
                        return true;
                }
                return false;
            }
            else return false;  
        }
    }
}
