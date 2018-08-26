using System;
using System.Collections.Generic;
using AssistantWebMySql.Models.DbSets;

namespace AssistantWebMySql.Interfaces
{
    public interface IConsoleRepository
    {
        /// <summary>
        /// Add new user to database.
        /// </summary>
        /// <param name="registeredUser">Registered user object.</param>
        /// <returns>Result: true or false.</returns>
        bool AddNewUser(RegisteredUser registeredUser);

        /// <summary>
        /// Get all registered users.
        /// </summary>
        /// <returns>List of registered users.</returns>
        List<RegisteredUser> GetAllUsers();

        /// <summary>
        /// Get user for authorization by name and key hash.
        /// </summary>
        /// <param name="name">User name string.</param>
        /// <param name="keyHash">Key hash string.</param>
        /// <returns>Registered user object or null.</returns>
        RegisteredUser GetUser(string name, string keyHash);

        /// <summary>
        /// Update license date and time by user id.
        /// </summary>
        /// <param name="id">User id value.</param>
        /// <param name="newLicenseDate">New license date and time.</param>
        void UpdateLicense(int id, DateTime newLicenseDate);

        /// <summary>
        /// Delete user from database by id value.
        /// </summary>
        /// <param name="id">User id value.</param>
        void Delete(int id);
    }
}
