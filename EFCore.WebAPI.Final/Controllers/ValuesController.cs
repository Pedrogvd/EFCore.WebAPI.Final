using EFCore.Dominio;
using EFCore.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public readonly HeroiContext _context;

        public ValuesController(HeroiContext context)
        {
            _context = context;

        }

        // GET: api/<ValuesController>
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
       
        {
            // linq method sem where -->  var listHeroi = _context.Herois.ToList();
            // linq query sem where --> var listHeroi = (from heroi in _context.Herois select heroi).ToList();
            // linq method com where -->
            var listHeroi = _context.Herois.Where(h => h.Nome.Contains(nome)).ToList(); //--> ps: nome é passado no parametro
            // linq query com where --> var listHeroi = (from heroi in _context.Herois where heroi.Nome.Contains(nome) select heroi).ToList();
            return Ok(listHeroi);
        }

        // GET api/<ValuesController>/5
        [HttpGet("Atualizar/{nameHero}")]
        public ActionResult Get(string nameHero)

        {
          //  var heroi = new Heroi {Nome = nameHero };

            var heroi = _context.Herois.Where(h => h.Id==3).FirstOrDefault();

            heroi.Nome = "Homem Aranha";
            //    _context.Herois.Add(heroi);
                _context.SaveChanges();
            
            return Ok();
        }


        // GET api/<ValuesController>/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange(string nameHero)

        {
            _context.AddRange(
                new Heroi { Nome = "Pedro" },
                new Heroi { Nome = "Luiz" },
                new Heroi { Nome = "Marcos" },
                new Heroi { Nome = "João" },
                new Heroi { Nome = "Leonardo" },
                new Heroi { Nome = "Fernando" }


                );


            _context.SaveChanges();

            return Ok();
        }










        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {

            var heroi = _context.Herois.Where(x => x.Id == id).Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();

        }
    }
}
