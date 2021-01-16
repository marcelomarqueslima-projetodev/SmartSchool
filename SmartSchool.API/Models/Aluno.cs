using System;
using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Aluno
    {
        public Aluno() { }

        public Aluno(int id, string nome, string sobrenome, 
                     string telefone, int matricula, DateTime dataNasc)
        {
            this.Id = id;
            this.Nome = nome;
            this.Matricula = Matricula;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DataNasc = dataNasc;
        }
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;

        public IEnumerable<AlunoDisciplina> AlunoDisciplina { get; set; }
    }
}