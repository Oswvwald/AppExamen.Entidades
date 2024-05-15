using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppExamen.Entidades
{
    public class MarcaFarmaceutica
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nombre del Marca")]
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }
        public int AñoFundacion { get; set; }

        public List<Farmaco>? Farmacos { get; set; }
    }
}
