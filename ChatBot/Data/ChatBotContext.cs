using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatBot.Model;

namespace ChatBot.Data
{
    public class ChatBotContext : DbContext
    {
        public ChatBotContext (DbContextOptions<ChatBotContext> options)
            : base(options)
        {
        }

        public DbSet<ChatBot.Model.Etapa> Etapa { get; set; }

        public DbSet<ChatBot.Model.Resposta> Resposta { get; set; }
    }
}
