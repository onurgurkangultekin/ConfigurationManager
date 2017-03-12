using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Core
{
    public interface IConfigurationReader
    {
        /// <summary>
        /// Gets the value based on given unique key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns>value</returns>
        T GetValue<T>(string key);

    }
}
