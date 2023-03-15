// Mason Frodsham masfrod2
// Mission 9 

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// this class sets and controls the session logic
namespace BookStore_masfrod2.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static C GetJson<C>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(C) : JsonSerializer.Deserialize<C>(sessionData);
        }
    }
}
