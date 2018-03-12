using MessangesAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Services
{
    public class MessangerRepository : IMessangerRepository
    {
        private readonly MessagesContext _context;

        public MessangerRepository(MessagesContext context)
        {
            _context = context;
        }

        //Add Message object to list of Messages Received for Receiver and Sent for Sender
        public void AddMessage (int ReceiverId, int SenderId, Message message)
        {
            var receiver = GetUser(ReceiverId);
            var sender = GetUser(SenderId);

            receiver.MessagesReceived.Add(message);
            sender.MessagesSent.Add(message);
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
    }
}
