using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    public interface IMedForm
    {
        List<Med> GetMeds(); 
        void AddMedToPrescription(Med newMed, UC_ListMeds uc);
    }
}
