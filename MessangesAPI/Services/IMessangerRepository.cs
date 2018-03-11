using MessangesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Services
{
    public interface IMessangerRepository
    {
        User GetUser(int id);
        void AddMessage(int ReceiverId, int SenderId, Message message);
        bool UserExists(int userId);
    }
}
