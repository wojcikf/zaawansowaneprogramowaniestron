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
    public class GatunekController : ControllerBase
    {
        private Repo<Gatunek> _rep;

        public GatunekController(Repo<Gatunek> rep)
        {
            _rep = rep;
        }

        // GET: api/Gatunek
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rep.GetAll());
        }

        // GET: api/Gatunek/5
        [HttpGet("{id}", Name = "GetGatunek")]
        public IActionResult Get(int id)
        {
            var gatunek = _rep.FindById(id);
            if (gatunek == null)
                return NotFound(id);
            return Ok(gatunek);
        }

        // POST: api/Gatunek
        [HttpPost]
        public IActionResult Post([FromBody] Gatunek gatunek)
        {
            try
            {
                _rep.Insert(gatunek);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetAutor", new { id = gatunek.Id }, gatunek);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Gatunek/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Gatunek gatunek)
        {
            try
            {
                _rep.Update(gatunek);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetAutor", new { id = gatunek.Id }, gatunek);
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
