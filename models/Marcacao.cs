using System;

namespace TypePonto.Models
{
    public class Marcacao
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario funcionario { get; set; }

        public string DataMarcacao { get; set; }

        public string HoraEntrada { get; set; }

        public string HoraSaidaAlmoco { get; set; }

        public string HoraVoltaAlmoco { get; set; }

        public string Saida { get; set; }

        public string horasT { get; set; }


        public string calculo()
        {
            String entrada = HoraEntrada;
            String saidaAlmoco = HoraSaidaAlmoco;
            String voltaAlmoco = HoraVoltaAlmoco;
            String saida = Saida;
            String dataM = DataMarcacao;

            DateTime dM = DateTime.Parse(dataM);
            DateTime hE = DateTime.Parse(entrada);
            DateTime hSA = DateTime.Parse(HoraSaidaAlmoco);
            DateTime hVA = DateTime.Parse(HoraVoltaAlmoco);
            DateTime hS = DateTime.Parse(saida);


            TimeSpan horas = new TimeSpan((hSA.Ticks - hE.Ticks) + (hS.Ticks - hVA.Ticks));

            this.horasT = horas.ToString(@"t");
            this.HoraEntrada = hE.ToString(@"t");
            this.HoraSaidaAlmoco = hSA.ToString(@"t");
            this.HoraVoltaAlmoco = hVA.ToString(@"t");
            this.Saida = hS.ToString(@"t");
            this.DataMarcacao = dM.ToString(@"dd/MM/yyyy");



            return horasT;
        }


    }
}