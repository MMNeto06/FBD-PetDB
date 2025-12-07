using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    [Serializable()]
    public class Appointment
    {
        private String _id;
        private String _data;
        private String _animal;
        private String _medico;

        public String Id
        {
            get { return _id; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Appointment Id field can’t be empty");
                    return;
                }
                _id = value;
            }
        }

        public String Data
        {
            get { return _data; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Appointment Date field can’t be empty");
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
                    throw new Exception("Appointment Animal field can’t be empty");
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
                    throw new Exception("Appointment Animal field can’t be empty");
                    return;
                }
                _medico = value;
            }
        }

        public override string ToString()
        {
            return _data + " " + _animal;
        }

        public Appointment() : base()
        {
        }
    }
}
