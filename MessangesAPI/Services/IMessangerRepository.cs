using MessangesAPI.Entities;
using MessangesAPI.Models;
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
        bool AddUser(User user);
        bool UserExists(int userId);
        bool Save();
        IEnumerable<Message> GetMessages(int userId);
        User GetLoggedUser(User user);
        bool UserWithUsernameAndPasswordExist(User user);
    }
}
