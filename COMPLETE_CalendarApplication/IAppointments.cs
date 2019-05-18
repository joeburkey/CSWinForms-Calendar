using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public interface IAppointments : IList<IAppointment>
    {
        bool Load();
        bool Save();
        IEnumerable<IAppointment> GetAppointmentsOnDate(DateTime date);
    }
}
