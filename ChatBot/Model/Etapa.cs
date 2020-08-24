using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.Model
{
    public class Etapa
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        public int ProxEtapaId { get; set; }

        public int Tipo { get; set; }
        public ICollection<Resposta> Respostas { get; set; } = new List<Resposta>();
        public Etapa()
        {
        }

        public Etapa(int id, string texto, int proxEtapaId, int tipo)
        {
            Id = id;
            Texto = texto;
            ProxEtapaId = proxEtapaId;
            Tipo = tipo;
        }


        //adciona Resposta na Etapa
        public void AddResposta(Resposta seller)
        {
            Respostas.Add(seller);
        }
    }
}
