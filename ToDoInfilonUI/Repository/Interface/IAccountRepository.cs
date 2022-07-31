using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoInfilonUI.Models;

namespace ToDoInfilonUI.Repository.Interface
{
    public interface IAccountRepository
    {
        int IsUserAuthenticated(Login login);
    }
}
