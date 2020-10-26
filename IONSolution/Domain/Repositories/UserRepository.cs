using IONSolution.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONSolution.Domain.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        private IONDBContext _context;

        public UserRepository(IONDBContext context) : base(context)
        {
            _context = context;
            _context.Users.Count();
            _context.Users.Add(new User { UserName = "user1", Password = "pass1" });
            _context.SaveChangesAsync();
        }

        public void GenerateToken(string user)
        {            
            User usr = _context.Users.Find(user);
            usr.Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()); 
            _context.SaveChangesAsync();
        }

        public void DisposeToken(string user)
        {
            User usr = _context.Users.Find(user);
            usr.Token = "";
            _context.SaveChangesAsync();
        }
    }
}
