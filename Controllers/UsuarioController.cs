using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.Context;
using webApi.Entities;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ListaContext _context;
        public UsuarioController(ListaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id} , usuario);
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }        

        [HttpGet("PorNome")]
        public IActionResult GetByNome(string nome)
        {
            var usuarios = _context.Usuarios.Where(x => x.Nome.Contains(nome));
            if (usuarios == null)
                return NotFound();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Usuario usuario)
        {
            var usuarioDB = _context.Usuarios.Find(id);
            if (usuarioDB == null)
                return NotFound();
            
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Sobrenome = usuario.Sobrenome;
            _context.Update(usuarioDB);
            _context.SaveChanges();

            return Ok(usuarioDB);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var usuarioDB = _context.Usuarios.Find(id);
            if (usuarioDB == null)
                return NotFound();

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return NoContent();
        }

    }
}