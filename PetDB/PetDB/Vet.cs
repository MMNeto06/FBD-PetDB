using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    [Serializable()]
    public class Vet
    {
        private String _numOMV;
        private String _nome;
        private String _telefone;
        private String _email;
        private String _endereco;
        private String _clinica;

        public String NIF
        {
            get { return _numOMV; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _numOMV = value;
            }
        }

        public String Nome
        {
            get { return _nome; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _nome = value;
            }
        }

        public String Telefone
        {
            get { return _telefone; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _telefone = value;
            }
        }

        public String Email
        {
            get { return _email; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _email = value;
            }
        }

        public String Endereco
        {
            get { return _endereco; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _endereco = value;
            }
        }

        public String Clinica
        {
            get { return _clinica;  }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Clinica Name field can't be empty");
                    return; 
                }
                _clinica = value;
            }
        }

        public override string ToString()
        {
            return _nome;
        }

        public Vet() : base()
        {
        }
    }
}
