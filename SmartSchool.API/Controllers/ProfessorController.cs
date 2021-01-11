using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public List<Professor> Professor = new List<Professor>(){
            new Professor(){
                Id = 1,
                Nome = "Marcos"
            },
            new Professor(){
                Id = 2,
                Nome = "João"
            },
            new Professor(){
                Id = 3,
                Nome = "Jhontan"
            }
        };
        public ProfessorController() {  }        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Professor);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById (int id)
        {
            var professor = Professor.FirstOrDefault(a => a.Id == id);
            if(professor == null) return BadRequest("Professor não encontrado.");
            return Ok(professor);
        }

        [HttpGet("{nome}")]
        public IActionResult GetByNome (string nome)
        {
            var professor = Professor.FirstOrDefault(a => a.Nome.Contains(nome));
            if(professor == null) return BadRequest("Aluno não encontrado.");
            return Ok(professor);
        }
    }
}