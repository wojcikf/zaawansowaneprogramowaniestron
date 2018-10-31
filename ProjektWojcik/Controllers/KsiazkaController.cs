using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektWojcik.Infrastructure;

namespace ProjektWojcik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsiazkaController : ControllerBase
    {
        private Repo<Ksiazka> _rep;

        public KsiazkaController(Repo<Ksiazka> rep)
        {
            _rep = rep;
        }

        // GET: api/Ksiazka
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rep.GetAll());
        }

        // GET: api/Ksiazka/5
        [HttpGet("{id}", Name = "GetKsiazka")]
        public IActionResult Get(int id)
        {
            var ksiazka = _rep.FindById(id);
            if (ksiazka == null)
                return NotFound(id);
            return Ok(ksiazka);
        }

        // POST: api/Ksiazka
        [HttpPost]
        public IActionResult Post([FromBody] Ksiazka ksiazka)
        {
            try
            {
                _rep.Insert(ksiazka);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetKsiazka", new { id = ksiazka.Id }, ksiazka);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Ksiazka/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ksiazka ksiazka)
        {
            try
            {
                _rep.Update(ksiazka);
                _rep.UnitOfWork.SaveChanges();
                return Ok(ksiazka);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _rep.Delete(id);
                _rep.UnitOfWork.SaveChanges();
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
