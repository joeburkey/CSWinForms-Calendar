using System;
using System.Collections.Generic;
using System.Text;

// Utility class for the calendar application. 
// Contains methods useful for converting between
// fields in the Appointment objects and what's 
// needed for the display of the appointments.

namespace Calendar
{
    class Utility
    {
        // Convert the time portion of the start time into
        // a row number on the panel display

        public static int ConvertTimeToRow(DateTime start)
        {
            int row = start.Hour * 2;
            if (start.Minute >= 30)
            {
                row++;
            }
            return row;
        }

        // Update the time part of the specified date to include the 
        // time indicated by the specified index.

        public static DateTime ConvertRowToDateTime(DateTime date, int row)
        {
            int hours = row / 2;
            int minutes = 0;
            if (row % 2 != 0)
            {
                minutes = 30;
            }
            return date.Date.AddHours(hours).AddMinutes(minutes);
        }

        // Convert a number of rows (each representing 30 minutes)
        // into a length in minutes

        public static int ConvertRowsToLength(int row)
        {
            return row * 30;
        }

        // Convert an appointment length (in minutes) into
        // the number of rows needed to represent it

        public static int ConvertLengthToRows(int length)
        {
            if (length % 30 != 0)
            {
                return length / 30 + 1;
            }
            else
            {
                return length / 30;
            }
        }
    }
}
