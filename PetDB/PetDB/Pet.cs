using System;
using System.Collections.Generic;
using System.Text;

namespace PetDB
{
    [Serializable()]
    public class Pet
    {
        private String _numero;
        private String _nome;
        private String _dataNascimento;
        private String _peso;
        private String _sexo;
        private String _especie;
        private String _dono;

        public String Numero
        {
            get { return _numero; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _numero = value;
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

        public String DataNascimento
        {
            get { return _dataNascimento; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _dataNascimento = value;
            }
        }

        public String Peso
        {
            get { return _peso; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _peso = value;
            }
        }

        public String Sexo
        {
            get { return _sexo; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _sexo = value;
            }
        }

        public String Especie
        {
            get { return _especie; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _especie = value;
            }
        }

        public String Dono
        {
            get { return _dono; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("Company Name field can’t be empty");
                    return;
                }
                _dono = value;
            }
        }

        public override string ToString()
        {
            return _nome;
        }

        public Pet() : base()
        {
        }
    }
}
