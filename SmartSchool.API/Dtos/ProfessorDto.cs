﻿using System;
using System.Collections.Generic;
using SmartSchool.API.Models;

namespace SmartSchool.API.Dtos
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataIni { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Ativo { get; set; }
    }
}
