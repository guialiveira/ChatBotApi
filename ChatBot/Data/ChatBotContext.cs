using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ChatBot.Data
{
    public class ChatBotContext : IdentityDbContext
    {
        public ChatBotContext (DbContextOptions<ChatBotContext> options)
            : base(options)
        {
        }

        public DbSet<ChatBot.Model.Etapa> Etapa { get; set; }

        public DbSet<ChatBot.Model.Resposta> Resposta { get; set; }
    }
}
