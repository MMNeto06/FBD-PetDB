using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    public interface IMedForm
    {
        List<Med> GetMeds(String searchContent); 
        void AddMedToPrescription(Med newMed, UC_ListMeds uc);
        void RemoveMedFromPrescription(int medID, UC_ListMeds uc);
    }
}
