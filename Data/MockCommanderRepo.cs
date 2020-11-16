using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data

{
    public class MockCommanderRepo : ICommanderRepo //Usado para test
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0 , Como="Medir la humedad ambiente", Linea="Con un sensor de humedad ambiente" , Plataforma="RaspberryPi"},
                new Command{Id=1 , Como="Medir la humedad del suelo", Linea="Con un sensor de humedad para suelos" , Plataforma="Arduino"},
                new Command{Id=2 , Como="Pasar la información al servidor", Linea="Con la API de Spherag" , Plataforma="API"}
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0 , Como="Medir la humedad ambiente", Linea="Con un sensor de humedad" , Plataforma="RaspberryPi"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}