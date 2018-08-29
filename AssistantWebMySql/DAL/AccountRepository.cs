using System.Collections.Generic;
using System.Linq;
using AssistantWebMySql.Interfaces;
using AssistantWebMySql.Models;
using AssistantWebMySql.Models.Accounts;

namespace AssistantWebMySql.DAL
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext _accountContext;

        public AccountRepository()
        {
            _accountContext = new AccountContext();
        }

        /// <summary>
        /// Get all users from identity context.
        /// </summary>
        /// <returns></returns>
        public List<ApplicationUser> GetAllUsers()
        {
            return _accountContext.Users.ToList();
        }
    }
}