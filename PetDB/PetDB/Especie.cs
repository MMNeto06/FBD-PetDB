using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    [Serializable()]
    public class Especie
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
                    throw new Exception("Specialty Code field can’t be empty");
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
                    throw new Exception("Specialty Description field can’t be empty");
                    return;
                }
                _descricao = value;
            }
        }

        public override string ToString()
        {
            return _descricao;
        }

        public Especie() : base()
        {
        }
    }
}
