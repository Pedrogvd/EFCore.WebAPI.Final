using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Final.Models
{
    public class Batalha
    {

        public int Id { get; set; }

        public string nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DtInicio { get; set; }

        public DateTime DtFim { get; set; }

        public List<HeroiBatalha> HeroisBatalhas { get; set; }

    }
}
