using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Disciplina
    {
        public Disciplina() { }

        public Disciplina(int id, string name, int professorId)
        {
            this.Id = id;
            this.Name = name;
            this.ProfessorId = professorId;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public IEnumerable<AlunoDisciplina> AlunoDisciplina { get; set; }
    }
}
