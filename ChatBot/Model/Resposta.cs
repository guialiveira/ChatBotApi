using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.Model
{
    public class Resposta
    {
        public int Id { get; set; }
        public string Legenda { get; set; }
        public int ProxEtapaId { get; set; }

        public Etapa Etapa { get; set; }

        public int EtapaId { get; set; }

        public Resposta()
        {
        }

        public Resposta(int id, string legenda, int proxEtapaId, Etapa etapa)
        {
            Id = id;
            Legenda = legenda;
            ProxEtapaId = proxEtapaId;
            Etapa = etapa;
        }
    }
}
