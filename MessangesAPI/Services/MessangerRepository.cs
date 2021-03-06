﻿using MessangesAPI.Entities;
using MessangesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Remotion.Linq.Clauses;

namespace MessangesAPI.Services
{
    public class MessangerRepository : IMessangerRepository
    {
        private readonly MessagesContext _context;

        public MessangerRepository(MessagesContext context)
        {
            _context = context;
        }

        public MessangerRepository()
        {
        }

        public void AddMessage(Message message)
        {   
            //var currentcase = GetCase(message.CaseId);
            //currentcase.Messages.Add(message);
            _context.Messages.Add(message);
        }

        public Case GetCase (int id)
        {
            return _context.Cases.FirstOrDefault(c => c.CaseId == id);
        }
        public User GetUser(int id)
        {
            //Get user by ID
            return _context.Users.FirstOrDefault(c => c.UserId == id);
        }
        public bool UserExists(int userId)
        {
            return _context.Users.Any(c => c.UserId == userId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        /// <summary>
        /// Returns true if user added
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            if (!UsernameExist(user))
            {
                _context.Users.Add(user);
                return true;
            }

            return false;
        }

        public void UpdateCase(Case casetoreturn)
        {
            _context.Cases.Update(casetoreturn);
        }

        public void UpdateUser(User userToReturn)
        {
            _context.Users.Update(userToReturn);
        }

        /// <summary>
        /// True if username Exist, false if not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UsernameExist(User user)
        {
            IEnumerable<User> users = _context.Users.Where(e => e.UserName == user.UserName);
            foreach (var usersloop in users)
            {
                return true;
            }
            return false;
        }

        public bool UserWithUsernameAndPasswordExist(User user)
        {
            var users = _context.Users.Where(c => c.UserName == user.UserName && c.Password == user.Password);
            foreach (var usersloop in users)
            {
                return true;
            }
            return false;
        }

        public User GetLoggedUser(User user)
        {
            return _context.Users.Where(c => c.UserName == user.UserName && c.Password == user.Password).FirstOrDefault();
        }

        public bool CaseExists(int caseId)
        {
            return _context.Cases.Any(c => c.CaseId == caseId);
        }

        public IEnumerable<Message> GetMessagesForCase(int caseId)
        {
            return _context.Messages.Where(c => c.CaseId == caseId).ToList();
        }

        public IEnumerable<Case> GetCasesForUser(int userId)
        {
            var currentuser = GetUser(userId);
            if(userId==17)
            {
                return _context.Cases.ToList();
            }
            return _context.Cases.Where(c => c.OfficerId == userId || c.Email == currentuser.Email).ToList();
        }
        //TODO
        public void AddCase(Case casetoadd)
        {
            var policeman = GetUser(casetoadd.OfficerId);

            policeman.Cases.Add(casetoadd);
        }

        public IEnumerable<User> GetListOfUsers()
        {
            return _context.Users.ToList();
        }
    }
}
