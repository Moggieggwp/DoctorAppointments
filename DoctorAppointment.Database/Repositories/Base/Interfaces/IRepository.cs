using System;
using System.Collections.Generic;
using DoctorAppointment.Database.Commands;

namespace DoctorAppointment.Database.Repositories.Base.Interfaces
{
    public interface IRepository<T>
    {
        CommandResult<T> ExecuteCommand(Command command);
        T GetById(int id, string tableName);
        List<T> GetAll(string tableName);
    }
}
