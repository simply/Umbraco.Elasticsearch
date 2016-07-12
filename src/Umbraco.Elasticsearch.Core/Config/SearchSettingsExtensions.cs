using System.Linq;
using Umbraco.Core;

namespace Umbraco.Elasticsearch.Core.Config
{
    public static class SearchSettingsExtensions
    {
        public static T GetAdditionalData<T>(this ISearchSettings settings, string key)
        {
            var keyPair = settings.AdditionalData.FirstOrDefault(x => StringExtensions.InvariantEquals(x.Key, key));
            if (!string.IsNullOrWhiteSpace(keyPair.Key))
            {
                var attempt = keyPair.Value.TryConvertTo<T>();
                if(attempt.Success) return attempt.Result;
            }
            return default(T);
        }
    }
}