using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    [Serializable()]
    public class Med
    {
        private String _codigo;
        private String _dose;
        private String _nome;

        public String Codigo
        {
            get { return _codigo; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Med Number field can’t be empty");
                    return;
                }
                _codigo = value;
            }
        }

        public String Dose
        {
            get { return _dose; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Med Dose field can’t be empty");
                    return;
                }
                _dose = value;
            }
        }

        public String Nome
        {
            get { return _nome; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Med Name field can’t be empty");
                    return;
                }
                _nome = value;
            }
        }

        public override string ToString()
        {
            return _nome;
        }

        public Med() : base()
        {
        }
    }
}
