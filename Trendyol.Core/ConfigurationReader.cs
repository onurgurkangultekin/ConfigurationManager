using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trendyol.Core
{
    public class ConfigurationReader : IConfigurationReader
    {
        private string _applicationName;
        private string _connectionString;
        private int _refreshTimerIntervalInMs;
        private List<Configuration> _configurationCache;
        private Timer _timer;

        public ConfigurationReader(string applicationName, string connectionString, int refreshTimerIntervalInMs)
        {
            _applicationName = applicationName;
            _connectionString = connectionString;
            _refreshTimerIntervalInMs = refreshTimerIntervalInMs;
            _timer = new Timer(refreshConfigurationData, null, refreshTimerIntervalInMs, refreshTimerIntervalInMs);
            refreshConfigurationData(null);
        }

        private void refreshConfigurationData(object state)
        {
            using (var context = new TrendyolEntities())
            {
                _configurationCache = context.Configuration.Where(p => p.ApplicationName == _applicationName && p.IsActive).ToList();
            }
        }

        public T GetValue<T>(string key)
        {
            Configuration config = _configurationCache.Find(p => p.Name == key);

            if (config.Type == "Boolean")
                config.Value = config.Value == "1" ? "True" : "False";

            return (T)Convert.ChangeType(config.Value, typeof(T));

        }
    }
}
