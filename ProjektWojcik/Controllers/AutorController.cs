using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektWojcik.Infrastructure;
using ProjektWojcik.Models;

namespace ProjektWojcik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        
        private Repo<Autor> _rep;

        public AutorController(Repo <Autor> rep) {
            _rep = rep;
        }

        // GET: api/Autor
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return _rep.GetAll();
        }

        // GET: api/Autor/5
        [HttpGet("{id}", Name = "Get")]
        public Autor Get(int id)
        {
            return _rep.FindById(id);
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
