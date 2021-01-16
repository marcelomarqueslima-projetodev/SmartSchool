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
    public class ProfessorController : ControllerBase
    {
        public readonly IRepository _repo;

        public ProfessorController(SmartContext context, IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        //[HttpGet("{id:int}")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorId(id, false);
            if (professor == null) return BadRequest("Professor não encontrado.");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professors = _repo.GetProfessorId(id);
            if (professors == null)
            {
                return BadRequest("Professor não encontrado!");
            }
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não altualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professors = _repo.GetProfessorId(id);
            if (professors == null)
            {
                return BadRequest("Professor não encontrado!");
            }
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorId(id);
            if (professor == null)
            {
                return BadRequest("Professor não encontrado!");
            }
            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor excluido com sucesso.");
            }
            return BadRequest("Professor não excluido.");
        }
    }
}