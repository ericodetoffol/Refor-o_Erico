﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Dominio.Base
{
    public abstract class Entidade
    {
        public int Id { get; set; }

        public abstract void Valida();

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Entidade entidade = obj as Entidade;
            if (entidade == null)
                return false;
            else
                return Id.Equals(entidade.Id);
        }
    }
}
