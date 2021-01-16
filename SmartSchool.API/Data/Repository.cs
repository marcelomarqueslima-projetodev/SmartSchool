﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SmartSchool.API.Models;
using SQLitePCL;

namespace SmartSchool.API.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;

        public Repository(SmartContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplina)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplina)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(aluno => aluno.AlunoDisciplina.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Aluno GetAlunoId(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplina)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id)
                .Where(aluno => aluno.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(a => a.Disciplina)
                    .ThenInclude(ad => ad.AlunoDisciplina)
                    .ThenInclude(d => d.Aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Professor[] GetProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(a => a.Disciplina)
                    .ThenInclude(ad => ad.AlunoDisciplina)
                    .ThenInclude(d => d.Aluno);
            }

            query = query.AsNoTracking()
                .OrderBy(aluno => aluno.Id)
                .Where(aluno =>aluno.Disciplina.Any(
                    ad => ad.AlunoDisciplina.Any(
                    ad => ad.DisciplinaId == disciplinaId)));

            return query.ToArray();
        }

        public Professor GetProfessorId(int professorId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(a => a.Disciplina)
                    .ThenInclude(ad => ad.AlunoDisciplina)
                    .ThenInclude(d => d.Aluno);
            }

            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(professor  => professor.Id == professorId);

            return query.FirstOrDefault();
        }
    }
}
