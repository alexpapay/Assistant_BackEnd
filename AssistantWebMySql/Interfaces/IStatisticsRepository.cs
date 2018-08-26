using System.Collections.Generic;
using AssistantWebMySql.Models.DbSets;

namespace AssistantWebMySql.Interfaces
{
    public interface IStatisticsRepository
    {
        /// <summary>
        /// Get all statistic data.
        /// </summary>
        /// <returns>List of statistic rows.</returns>
        List<MonitoringValue> GetAll();

        /// <summary>
        /// Add new statistic row from client.
        /// </summary>
        /// <param name="monitoringValue">Monitoring value object.</param>
        void Add(MonitoringValue monitoringValue);
    }
}
