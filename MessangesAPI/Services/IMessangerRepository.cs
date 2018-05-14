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
        void AddMessage(Message message);
        bool AddUser(User user);
        bool UserExists(int userId);
        bool Save();
        User GetLoggedUser(User user);
        bool UserWithUsernameAndPasswordExist(User user);
        bool CaseExists(int caseId);
        IEnumerable<Message> GetMessagesForCase(int caseId);
        IEnumerable<Case> GetCasesForUser(int userId);
        void AddCase(Case casetoadd);
        Case GetCase (int id);
        void UpdateCase(Case casetoreturn);
        IEnumerable<User> GetListOfUsers();
    }
}
