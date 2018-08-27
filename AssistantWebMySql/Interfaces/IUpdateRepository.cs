using System.Collections.Generic;
using AssistantWebMySql.Models.DbSets;

namespace AssistantWebMySql.Interfaces
{
    public interface IUpdateRepository
    {
        /// <summary>
        /// Get all assistant updates rows from database.
        /// </summary>
        /// <returns>List of updates or empty list.</returns>
        List<Update> GetAllUpdates();

        /// <summary>
        /// Get download link by update id.
        /// </summary>
        /// <param name="id">Update id value.</param>
        /// <returns>Update download string.</returns>
        string GetDownloadLink(int id);

        /// <summary>
        /// Get update json if client have another data.
        /// </summary>
        /// <param name="checkUpdateJson">Json data from client.</param>
        /// <returns>Update json object or null.</returns>
        UpdateJson GetUpdateJson(UpdateJson checkUpdateJson);

        /// <summary>
        /// Add a new update row.
        /// </summary>
        /// <param name="update">Update object.</param>
        void AddNew(Update update);

        /// <summary>
        /// Delete update row.
        /// </summary>
        /// <param name="id">Update id value.</param>
        void Delete(int id);
    }
}
