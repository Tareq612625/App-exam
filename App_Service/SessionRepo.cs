using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App_Service
{
    public class SessionRepo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public SessionRepo(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void SetSessionModeltValue<T>(string key, T value)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            _session.Set(key, System.Text.Encoding.UTF8.GetBytes(serializedValue));
        }

        public T GetSessionModelValue<T>(string key)
        {
            byte[] valueBytes;
            if (_session.TryGetValue(key, out valueBytes))
            {
                var valueString = System.Text.Encoding.UTF8.GetString(valueBytes);
                return JsonSerializer.Deserialize<T>(valueString);
            }
            else return Activator.CreateInstance<T>();
        }

        public void SetSessionListValue<T>(string key, List<T> value)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            _session.Set(key, System.Text.Encoding.UTF8.GetBytes(serializedValue));
        }

        public List<T> GetSessionListValue<T>(string key)
        {
            byte[] valueBytes;
            if (_session.TryGetValue(key, out valueBytes))
            {
                var valueString = System.Text.Encoding.UTF8.GetString(valueBytes);
                return JsonSerializer.Deserialize<List<T>>(valueString);
            }
            else return Activator.CreateInstance<List<T>>();
        }

        public void SetSessionSingleValue<T>(string key, T value)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            _session.Set(key, System.Text.Encoding.UTF8.GetBytes(serializedValue));
        }
        public T GetSessionSingleValue<T>(string key)
        {
            byte[] valueBytes;
            if (_session.TryGetValue(key, out valueBytes))
            {
                var valueString = System.Text.Encoding.UTF8.GetString(valueBytes);
                return JsonSerializer.Deserialize<T>(valueString);
            }
            return default(T);
        }

        public void RemoveSessionValue(string key)
        {
            _session.Remove(key);
        }
        public void RemoveAllSessionVlaue() { 
            _session.Clear();
        }
    }
}
