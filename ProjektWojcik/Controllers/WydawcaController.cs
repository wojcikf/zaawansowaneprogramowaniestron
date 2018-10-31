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
    public class WydawcaController : ControllerBase
    {
        private Repo<Wydawca> _rep;

        public WydawcaController(Repo<Wydawca> rep)
        {
            _rep = rep;
        }

        // GET: api/Wydawca
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rep.GetAll());
        }

        // GET: api/Wydawca/5
        [HttpGet("{id}", Name = "GetWydawca")]
        public IActionResult Get(int id)
        {
            var wydawca = _rep.FindById(id);
            if (wydawca == null)
                return NotFound(id);
            return Ok(wydawca);
        }

        // POST: api/Wydawca
        [HttpPost]
        public IActionResult Post([FromBody] Wydawca wydawca)
        {
            try
            {
                _rep.Insert(wydawca);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetAutor", new { id = wydawca.Id }, wydawca);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Wydawca/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Wydawca wydawca)
        {
            try
            {
                _rep.Update(wydawca);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetAutor", new { id = wydawca.Id }, wydawca);
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
