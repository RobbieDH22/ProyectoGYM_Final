using System;
using System.Collections.Generic;

namespace ProyectoGYM.DOMAIN.Core.Entities
{
    public partial class TbSede
    {
        public TbSede()
        {
            TbEvento = new HashSet<TbEvento>();
        }

        public int CodigoSede { get; set; }
        public string Provincia { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public string Direccion { get; set; } = null!;

        public virtual ICollection<TbEvento> TbEvento { get; set; }
    }
}
