using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    [Serializable()]
    public class Treatment
    {
        private String _codigo;
        private String _descricao;

        public String Codigo
        {
            get { return _codigo; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Treatment Code field can’t be empty");
                    return;
                }
                _codigo = value;
            }
        }

        public String Descricao
        {
            get { return _descricao; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Treatment Description field can’t be empty");
                    return;
                }
                _descricao = value;
            }
        }

        public override string ToString()
        {
            return _descricao;
        }

        public Treatment() : base()
        {
        }
    }
}
