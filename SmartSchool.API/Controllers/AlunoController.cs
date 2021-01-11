using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Aluno = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Pereira",
                Telefone = "1234566"
            },
            new Aluno(){
                Id = 2,
                Nome = "João",
                Sobrenome = "Silva",
                Telefone = "3234566"
            },
            new Aluno(){
                Id = 3,
                Nome = "Jhontan",
                Sobrenome = "Oliveira",
                Telefone = "4234566"
            }
        };
        public AlunoController() { }   

        [HttpGet]
        public IActionResult Get ()
        {
            return Ok(Aluno);
        }

        //[HttpGet("{id:int}")]
        [HttpGet("byId/{id}")]
        public IActionResult GetById (int id)
        {
            var aluno = Aluno.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado.");
            return Ok(aluno);
        }

        [HttpGet("ByNome")]
        public IActionResult GetByNome (string nome, string sobrenome)
        {
            var aluno = Aluno.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if(aluno == null) return BadRequest("Aluno não encontrado.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post (Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch (int id, Aluno aluno)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            return Ok();
        }
    }
}