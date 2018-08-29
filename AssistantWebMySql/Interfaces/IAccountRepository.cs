using System.Collections.Generic;
using AssistantWebMySql.Models.Accounts;

namespace AssistantWebMySql.Interfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Get all users from identity context.
        /// </summary>
        /// <returns></returns>
        List<ApplicationUser> GetAllUsers();
    }
}
