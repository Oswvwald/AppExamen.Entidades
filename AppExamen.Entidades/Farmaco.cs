using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen.Entidades
{
    public class Farmaco
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? PrincipioActivo { get; set; }
        public string Dosis { get; set; } 
        public string FormaFarmaceutica { get; set; }
        
        public int MarcaId { get; set; } //fk
        public MarcaFarmaceutica? Marca {  get; set; }
    }
}
