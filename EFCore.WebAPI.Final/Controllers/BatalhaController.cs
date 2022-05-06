using EFCore.Dominio;
using EFCore.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {


        private readonly HeroiContext _context;

        public BatalhaController(HeroiContext context)
        {
            _context = context;
        }



        // GET: api/<BatalhaController>
        [HttpGet]
        public ActionResult Get()
        {

            try
            {
                var Batalha = new Batalha { };
                return Ok(Batalha);

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
           
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            
            return Ok();
        }

        // POST api/<BatalhaController>
        [HttpPost]
        public ActionResult Post(Batalha model)
        {

            try
            {

                _context.Add(model);
                _context.SaveChanges();
                return Ok("BAZINGA!");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha model)
        {

            try
            {
                if (_context
                    .Herois
                    .AsNoTracking()
                    .FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    return Ok("BAZINGA!");
                }
                return Ok("Não encontrado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }



        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
