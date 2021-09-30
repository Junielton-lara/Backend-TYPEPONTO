using System;
using System.Collections.Generic;

namespace TypePonto.Models
{
    public class Funcionario
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Pis { get; set; }
        public double ValorHora { get; set; }
        public string DataAdm { get; set; }

        public override string ToString() =>
            $"Nome: {Nome} | PIS: {Pis} | Valor Hora: {ValorHora} | Data de Admição:";


        public string calculoData()
        {

            DateTime data = DateTime.Now;

            this.DataAdm = data.ToString(@"d");

            return DataAdm;

        }

    }
}