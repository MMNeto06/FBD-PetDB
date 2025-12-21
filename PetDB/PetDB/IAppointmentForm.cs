using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    public interface IAppointmentForm
    {
        List<Treatment> GetTreatments(String searchContent); 
        void AddTreatmentToAppointment(Treatment newTreatment, UC_ListTreatments uc);
        void UpdateReport(String reportContent);
        void RemoveTreatmentFromAppointment(int treatmentID, UC_ListTreatments uc);
    }
}
