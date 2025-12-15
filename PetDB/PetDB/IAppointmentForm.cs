using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    public interface IAppointmentForm
    {
        List<Treatment> GetTreatments(); 
        void AddTreatmentToAppointment(Treatment newTreatment, UC_ListTreatments uc);
        void UpdateReport(String reportContent);
    }
}
