using System;
using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoId(int alunoId, bool includeProfessor = false);

        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorId(int professorId, bool includeAlunos = false);
    }
}
