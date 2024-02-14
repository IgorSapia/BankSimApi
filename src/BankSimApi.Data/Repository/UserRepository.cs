using BankSimApi.Business.Interfaces;
using BankSimApi.Business.Models;
using BankSimApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankSimApi.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyDbContext context) : base(context)
        {

        }
    }
}
