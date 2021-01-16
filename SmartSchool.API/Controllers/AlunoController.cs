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
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get ()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        //[HttpGet("{id:int}")]
        [HttpGet("{id}")]
        public IActionResult GetById (int id)
        {
            var aluno = _repo.GetAlunoId(id, false);
            if(aluno == null) return BadRequest("Aluno não encontrado.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post (Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, Aluno aluno)
        {
            var alunos = _repo.GetAlunoId(id);
            if (alunos == null)
            {
                return BadRequest("Aluno não encontrado!");
            }
            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não Atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch (int id, Aluno aluno)
        {
            var alunos = _repo.GetAlunoId(id);
            if (alunos == null)
            {
                return BadRequest("Aluno não encontrado!");
            }
            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não Atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var aluno = _repo.GetAlunoId(id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado!");
            }
            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno excluido com sucesso");
            }
            return BadRequest("Aluno não excluido.");
        }
    }
}