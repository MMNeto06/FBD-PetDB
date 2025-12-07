using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    [Serializable()]
    public class Report
    {
        private String _codigo;
        private String _conteudo;

        public String Codigo
        {
            get { return _codigo; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Report Code field can’t be empty");
                    return;
                }
                _codigo = value;
            }
        }

        public String Conteudo
        {
            get { return _conteudo; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Treatment Description field can’t be empty");
                    return;
                }
                _conteudo = value;
            }
        }

        public override string ToString()
        {
            return _conteudo;
        }

        public Report() : base()
        {
        }
    }
}
