using System;
using System.Collections.Generic;
using System.Linq;
using AssistantWebMySql.Interfaces;
using AssistantWebMySql.Models;
using AssistantWebMySql.Models.DbSets;

namespace AssistantWebMySql.DAL
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly AssistantContext _db;

        public StatisticsRepository(AssistantContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get all statistic data.
        /// </summary>
        /// <returns>List of statistic rows.</returns>
        public List<MonitoringValue> GetAll()
        {
            List<MonitoringValue> monitoringValues = _db.MonitoringValues.ToList();

            return monitoringValues;
        }

        /// <summary>
        /// Add new statistic row from client.
        /// </summary>
        /// <param name="monitoringValue">Monitoring value object.</param>
        public void Add(MonitoringValue monitoringValue)
        {
            monitoringValue.EventDateTime = DateTime.Now;
            _db.MonitoringValues.Add(monitoringValue);
            _db.SaveChanges();
        }
    }
}