using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    [Serializable()]
    public class Prescription
    {
        private String _numero;
        private String _data;
        private String _animal;
        private String _medico;
        public String Numero
        {
            get { return _numero; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Prescription Number field can’t be empty");
                    return;
                }
                _numero = value;
            }
        }

        public String Data
        {
            get { return _data; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Prescription Date field can’t be empty");
                    return;
                }
                _data = value;
            }
        }

        public String Animal
        {
            get { return _animal; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Prescription Animal field can’t be empty");
                    return;
                }
                _animal = value;
            }
        }

        public String Medico
        {
            get { return _medico; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Prescription Vet field can’t be empty");
                    return;
                }
                _medico = value;
            }
        }

        public override string ToString()
        {
            return _animal + " " + _data;
        }

        public Prescription() : base()
        {
        }
    }
}
