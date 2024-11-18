using MunicipalityApp.DataStructures;
using System;

namespace MunicipalityApp
{
    // LocalEvent class representing an event with priority and comparison capabilities
    public class LocalEvent : IPrioritizable, IComparable<LocalEvent>
    {
        public string Name { get; set; } // The name of the event
        public string Location { get; set; } // The location of the event
        public string Category { get; set; } // The category of the event
        public string Province { get; set; } // The province where the event takes place
        public string Description { get; set; } // A description of the event
        public string MediaPath { get; set; } // Path to media related to the event
        public DateTime Date { get; set; } // The date of the event
        public int Priority { get; set; } // Priority of the event for sorting
        public bool IsReportedIssue { get; set; } // Whether the event is a reported issue

        // Constructor to initialize a LocalEvent with provided properties
        public LocalEvent(string name, string location, string category, string province, string description, string mediaPath, DateTime date, int priority, bool isReportedIssue)
        {
            Name = name;
            Location = location;
            Category = category;
            Province = province;
            Description = description;
            MediaPath = mediaPath;
            Date = date;
            Priority = priority;
            IsReportedIssue = isReportedIssue;
        }
        //------------------------------End of constructor--------------------------------//

        // Compare method for comparing two LocalEvent objects based on their Date and Priority
        public int CompareTo(LocalEvent other)
        {
            if (other == null) return 1; // If other is null, this object is considered greater

            // Compare by Date first
            int dateComparison = Date.CompareTo(other.Date);
            if (dateComparison != 0)
                return dateComparison; // Return date comparison result if they are not the same

            // If dates are the same, compare by Priority
            return Priority.CompareTo(other.Priority);
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
