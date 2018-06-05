using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DoctorAppointment.Database.Commands;
using DoctorAppointment.Database.Repositories.Base.Interfaces;

namespace DoctorAppointment.Database.Repositories.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly string connectionString;

        public BaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public CommandResult<T> ExecuteCommand(Command command)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                switch (command.CommandType)
                {
                    case CommandType.Select:
                        {
                            return new CommandResult<T>
                            {
                                Data = command.Parametrs == null
                                    ? connection.Query<T>(command.Query)
                                    : connection.Query<T>(command.Query, command.Parametrs),
                                IsSuccess = true
                            };
                        }
                    case CommandType.Insert:
                        {
                            connection.Execute(command.Query, command.Parametrs);
                            return new CommandResult<T>
                            {
                                IsSuccess = true
                            };
                        }
                    default: { break; }
                }

                return null;
            }
        }

        public List<T> GetAll(string tableName)
        {
            var result = this.ExecuteCommand(new Command
            {
                Query = $"select * from {tableName}",
                CommandType = CommandType.Select
            });

            return result.Data.ToList();
        }

        public T GetById(Guid id, string tableName)
        {
            var result = this.ExecuteCommand(new Command
            {
                Query = $"select * from {tableName} where Id = @id",
                Parametrs = new { Id = id },
                CommandType = CommandType.Select
            });

            return result.Data.FirstOrDefault();
        }
    }
}
