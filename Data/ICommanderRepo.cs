using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable <Command> GetAllCommands();
        Command GetCommandById(int id);
        //Creamos 
        void CreateCommand(Command cmd);
        //Actualizamos
        void UpdateCommand(Command cmd);
        //Borramos
        void DeleteCommand(Command cmd);
    }
}