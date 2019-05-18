using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public interface IAppointment
    {
        DateTime Start { get; }
        int Length { get; }
        string DisplayableDescription { get; }
        bool OccursOnDate(DateTime date);
    }
}
