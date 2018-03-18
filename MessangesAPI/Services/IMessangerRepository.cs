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
        void AddUser(User user);
        bool UserExists(int userId);
        bool Save();
        IEnumerable<Message> getMessages(int userId);
    }
}
