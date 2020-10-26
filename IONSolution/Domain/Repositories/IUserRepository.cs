using IONSolution.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONSolution.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        void GenerateToken(string userName);
        void DisposeToken(string userName);

    }
}
