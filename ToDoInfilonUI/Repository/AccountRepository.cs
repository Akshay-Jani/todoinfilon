using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoInfilonUI.Models;
using ToDoInfilonUI.Models.DB;
using ToDoInfilonUI.Repository.Interface;

namespace ToDoInfilonUI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ToDoInfilonContext _context;

        public AccountRepository(ToDoInfilonContext context)
        {
            _context = context;
        }

        public int IsUserAuthenticated(Login login)
        {
            AppUser appUser = _context.AppUser.Where(x => x.Name == login.Name && x.Pwd == login.Password).FirstOrDefault();
            if (appUser != null)
            {
                return appUser.Id;
            }
            return -1;
        }
    }
}
