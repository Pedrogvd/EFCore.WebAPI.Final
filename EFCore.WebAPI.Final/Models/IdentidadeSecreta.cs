
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Final.Models
{
    public class IdentidadeSecreta
    {

        public int Id { get; set; }

        public int NomeReal { get; set; }

        public Heroi Heroi { get; set; }

        public int HeroiId { get; set; }

    }
}
