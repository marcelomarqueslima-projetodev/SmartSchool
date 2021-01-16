using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Disciplina
    {
        public Disciplina() { }

        public Disciplina(int id, string name, int professorId, int cursoId)
        {
            this.Id = id;
            this.Name = name;
            this.ProfessorId = professorId;
            this.CursoId = cursoId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CargaHoraria { get; set; }

        public int? PreRequisitoId { get; set; } = null;
        public Disciplina PreRequisito { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public IEnumerable<AlunoDisciplina> AlunoDisciplina { get; set; }
    }
}
