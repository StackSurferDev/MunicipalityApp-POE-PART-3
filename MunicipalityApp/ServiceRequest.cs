using MunicipalityApp.DataStructures;
using System;

namespace MunicipalityApp
{
    // ServiceRequest class representing a service request with priority and comparison capabilities
    public class ServiceRequest : IPrioritizable, IComparable<ServiceRequest>
    {
        public Guid Id { get; private set; } // Unique Identifier
        public string ServiceType { get; set; } // Type of service requested
        public string Description { get; set; } // Description of the service request
        public DateTime ServiceDate { get; set; } // Date when the service is requested
        public int Priority { get; set; } // Priority of the service request
        public bool IsResolved { get; set; } // Whether the service request is resolved
        public int Progress { get; set; } // Progress Percentage of the service request

        // Constructor to initialize a ServiceRequest with the provided values
        public ServiceRequest(string serviceType, string description, DateTime serviceDate, int priority, bool isResolved)
        {
            Id = Guid.NewGuid(); // Generate a new unique identifier
            ServiceType = serviceType ?? throw new ArgumentNullException(nameof(serviceType)); // Ensure service type is not null
            Description = description ?? throw new ArgumentNullException(nameof(description)); // Ensure description is not null
            ServiceDate = serviceDate;
            Priority = priority;
            IsResolved = isResolved;
            Progress = 0; // Default progress starts at 0%
        }
        //------------------------------End of constructor--------------------------------//

        // Compare method for comparing two ServiceRequest objects based on their ServiceDate and Priority
        public int CompareTo(ServiceRequest? other)
        {
            if (other == null) return 1; // If other is null, this object is considered greater

            // Compare by ServiceDate first
            int dateComparison = ServiceDate.CompareTo(other.ServiceDate);
            if (dateComparison != 0) return dateComparison; // Return date comparison result if they are not the same

            // If ServiceDate is the same, compare by Priority
            return Priority.CompareTo(other.Priority);
        }
        //------------------------------End of method--------------------------------//

        // Override Equals method to compare ServiceRequest objects by their Id
        public override bool Equals(object? obj)
        {
            if (obj is ServiceRequest other)
            {
                return Id == other.Id; // Check if the Ids are equal
            }
            return false;
        }
        //------------------------------End of method--------------------------------//

        // Override GetHashCode method to generate a hash code based on the Id
        public override int GetHashCode()
        {
            return HashCode.Combine(Id); // Combine the Id into a hash code
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
