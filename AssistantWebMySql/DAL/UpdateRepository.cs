using System.Collections.Generic;
using System.Linq;
using AssistantWebMySql.Interfaces;
using AssistantWebMySql.Models;
using AssistantWebMySql.Models.DbSets;

namespace AssistantWebMySql.DAL
{
    public class UpdateRepository : IUpdateRepository
    {
        private readonly AssistantContext _db;

        public UpdateRepository(AssistantContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get all assistant updates rows from database.
        /// </summary>
        /// <returns>List of updates or empty list.</returns>
        public List<Update> GetAllUpdates()
        {
            return _db
                .Updates
                .AsNoTracking()
                .ToList();
        }

        /// <summary>
        /// Get download link by update id.
        /// </summary>
        /// <param name="id">Update id value.</param>
        /// <returns>Update download string.</returns>
        public string GetDownloadLink(int id)
        {
            Update update = _db.Updates
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            return update?.DownLoadLink;
        }

        /// <summary>
        /// Get update json if client have another data.
        /// </summary>
        /// <param name="checkUpdateJson">Json data from client.</param>
        /// <returns>Update json object or null.</returns>
        public UpdateJson GetUpdateJson(UpdateJson checkUpdateJson)
        {
            List<Update> allUpdates = _db.Updates
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .ToList();

            if (!allUpdates.Any())
                return null;

            Update lastUpdate = allUpdates.FirstOrDefault();

            if (lastUpdate == null)
                return null;

            if (lastUpdate.Version == checkUpdateJson.Version)
                return null;

            string descriptionText;

            switch (checkUpdateJson.Language)
            {
                case 0: descriptionText = lastUpdate.RussianDescription; break;
                case 1: descriptionText = lastUpdate.EnglishDescription; break;
                case 2: descriptionText = lastUpdate.DeutschDescription; break;
                case 3: descriptionText = lastUpdate.ChineseDescription; break;
                default: descriptionText = lastUpdate.RussianDescription; break;
            }

            return new UpdateJson
            {
                Version = lastUpdate.Version,
                Description = descriptionText,
                DownLoadLink = lastUpdate.DownLoadLink
            };
        }

        /// <summary>
        /// Add a new update row.
        /// </summary>
        /// <param name="update">Update object.</param>
        public void AddNew(Update update)
        {
            _db.Updates.Add(update);
            _db.SaveChanges();
        }

        /// <summary>
        /// Delete update row.
        /// </summary>
        /// <param name="id">Update id value.</param>
        public void Delete(int id)
        {
            Update deletingUpdate = new Update { Id = id };

            _db.Updates.Attach(deletingUpdate);
            _db.Updates.Remove(deletingUpdate);
            _db.SaveChanges();
        }
    }
}