﻿using System;
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
        public IActionResult Get()
        {
            return Ok(_rep.GetAll());
        }

        // GET: api/Autor/5
        [HttpGet("{id}", Name = "GetAutor")]
        public IActionResult Get(int id)
        {
            var autor = _rep.FindById(id);
            if (autor == null)
                return NotFound(id);
            return Ok(autor);
        }

        // POST: api/Autor
        [HttpPost]
        public IActionResult Post([FromBody] Autor autor)
        {
            try
            {
                _rep.Insert(autor);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetAutor", new { id = autor.Id }, autor);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }

        }

        // PUT: api/Autor/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Autor autor)
        {
            try
            {
                _rep.Update(autor);
                _rep.UnitOfWork.SaveChanges();
                return Ok(autor);
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
