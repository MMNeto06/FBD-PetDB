using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    [Serializable()]
    public class Payment
    {
        private String _id;
        private String _data;
        private String _valor;
        private String _estado;
        private String _metodo;
        private String _animal;
        private String _medico;

        public String Id
        {
            get { return _id; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Payment Id field can’t be empty");
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
                    throw new Exception("Payment Data field can’t be empty");
                    return;
                }
                _data = value;
            }
        }

        public String Valor
        {
            get { return _valor; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Payment Value field can’t be empty");
                    return;
                }
                _valor = value;
            }
        }

        public String Estado
        {
            get { return _estado; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Payment State field can’t be empty");
                    return;
                }
                _estado = value;
            }
        }

        public String Metodo
        {
            get { return _metodo; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Payment Method field can’t be empty");
                    return;
                }
                _metodo = value;
            }
        }

        public String Animal
        {
            get { return _animal; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Payment Animal field can’t be empty");
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
                    throw new Exception("Payment Doctor field can’t be empty");
                    return;
                }
                _medico = value;
            }
        }

        public override string ToString()
        {
            return _animal + ", " + _data + ", " + _valor + " EUR";
        }

        public Payment() : base()
        {
        }
    }
}
