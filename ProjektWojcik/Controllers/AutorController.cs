using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektWojcik.Models;

namespace ProjektWojcik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly KsiegarniaKontekst _db;

        public AutorController(KsiegarniaKontekst db) {
            _db = db;
        }

        // GET: api/Autor
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return _db.Autorzy.ToList();
        }

        // GET: api/Autor/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Autor
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Autor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
