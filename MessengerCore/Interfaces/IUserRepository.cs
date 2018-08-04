using MessengerCore.Models;
using System.Collections.Generic;

namespace MessengerCore.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<Messege> All<T>() where T : Entity;

        void Add<T>(T entity) where T : Entity;
    }
}
