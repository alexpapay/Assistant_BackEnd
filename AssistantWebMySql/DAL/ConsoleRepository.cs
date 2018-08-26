using System;
using System.Collections.Generic;
using System.Linq;
using AssistantWebMySql.Interfaces;
using AssistantWebMySql.Models;
using AssistantWebMySql.Models.DbSets;
using AssistantWebMySql.Models.Json;
using AssistantWebMySql.Utils;
using Newtonsoft.Json;

namespace AssistantWebMySql.DAL
{
    public class ConsoleRepository : IConsoleRepository
    {
        private readonly AssistantContext _db;

        public ConsoleRepository(AssistantContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Add new user to database.
        /// </summary>
        /// <param name="registeredUser">Registered user object.</param>
        /// <returns>Result: true or false.</returns>
        public bool AddNewUser(RegisteredUser registeredUser)
        {
            try
            {
                KeyHash keyHash = new KeyHash();
                DateTime currentDate = DateTime.Now;

                registeredUser.RegistrationDate = currentDate;

                registeredUser.KeyHash = keyHash.Decrypt(JsonConvert.SerializeObject(new UserJson
                {
                    Name = registeredUser.Name,
                    MacAdress = registeredUser.MacAdress,
                    LicenseFinishDate = registeredUser.LicenseFinishDate,
                    RegistrationDate = currentDate
                }), "AssisTant321", "AlphaPeriod");

                _db.RegisteredUsers.Add(registeredUser);
                _db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// Get all registered users.
        /// </summary>
        /// <returns>List of registered users.</returns>
        public List<RegisteredUser> GetAllUsers()
        {
            List<RegisteredUser> registeredUsers = _db.RegisteredUsers.ToList();

            return registeredUsers;
        }

        /// <summary>
        /// Get user for authorization by name and key hash.
        /// </summary>
        /// <param name="name">User name string.</param>
        /// <param name="keyHash">Key hash string.</param>
        /// <returns>Registered user object or null.</returns>
        public RegisteredUser GetUser(string name, string keyHash)
        {
            RegisteredUser foundUser = _db.RegisteredUsers
                .FirstOrDefault(x => x.Name == name && x.KeyHash == keyHash);

            return foundUser;
        }

        /// <summary>
        /// Update license date and time by user id.
        /// </summary>
        /// <param name="id">User id value.</param>
        /// <param name="newLicenseDate">New license date and time.</param>
        public void UpdateLicense(int id, DateTime newLicenseDate)
        {
            RegisteredUser updatingUser = _db.RegisteredUsers
                .FirstOrDefault(x => x.Id == id);

            if (updatingUser == null)
            {
                // TODO: Add logging
                return;
            }

            KeyHash keyHash = new KeyHash();
            DateTime currentDate = DateTime.Now;

            updatingUser.RegistrationDate = currentDate;
            updatingUser.LicenseFinishDate = newLicenseDate;
            updatingUser.KeyHash = keyHash.Decrypt(JsonConvert.SerializeObject(new UserJson
            {
                Name = updatingUser.Name,
                MacAdress = updatingUser.MacAdress,
                LicenseFinishDate = newLicenseDate,
                RegistrationDate = currentDate
            }), "AssisTant321", "AlphaPeriod");

            _db.SaveChanges();
        }

        /// <summary>
        /// Delete user from database by id value.
        /// </summary>
        /// <param name="id">User id value.</param>
        public void Delete(int id)
        {
            RegisteredUser deletingUser = new RegisteredUser { Id = id };

            _db.RegisteredUsers.Attach(deletingUser);
            _db.RegisteredUsers.Remove(deletingUser);
            _db.SaveChanges();
        }
    }
}