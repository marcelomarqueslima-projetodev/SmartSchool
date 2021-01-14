using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult Get ()
        {
            return Ok(_context.Alunos);
        }

        //[HttpGet("{id:int}")]
        [HttpGet("byId/{id}")]
        public IActionResult GetById (int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado.");
            return Ok(aluno);
        }

        [HttpGet("ByNome")]
        public IActionResult GetByNome (string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if(aluno == null) return BadRequest("Aluno não encontrado.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post (Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, Aluno aluno)
        {
            var alunos = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alunos == null)
            {
                return BadRequest("Aluno não encontrado!");
            }
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch (int id, Aluno aluno)
        {
            var alunos = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alunos == null)
            {
                return BadRequest("Aluno não encontrado!");
            }
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado!");
            }
            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}