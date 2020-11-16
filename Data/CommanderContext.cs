using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext>opt) : base(opt)
        {

        }

        //Creamos una representación de nuestro modelo de BD como DbSet, y se llamará Commands
        public DbSet<Command> Commands { get; set; }

    }
}