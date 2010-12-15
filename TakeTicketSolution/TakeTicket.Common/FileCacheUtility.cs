using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace TakeTicket.Common
{
    public class FileCacheUtility
    {
        private static event CacheItemRemovedCallback OnCacheItemRemovedCallack = new CacheItemRemovedCallback(RemoveCacheItemCallback);

        private static void RemoveCacheItemCallback(string key, object value, CacheItemRemovedReason reason)
        {
            if (reason == CacheItemRemovedReason.DependencyChanged)
            {
                return;
            }
        }

        private static string GenerateCacheKey(string xmlFile, Type objectT)
        {
            return string.Format("{0}|{1}", objectT.AssemblyQualifiedName, xmlFile);
        }

        public static object GetObjectFromXmlFile(string xmlFile, Type objectT)
        {
            xmlFile = IOUtility.GetRootedFilePath(xmlFile);
            var cacheKey = GenerateCacheKey(xmlFile, objectT);
            if (HttpContext.Current != null)
            {
                Cache cacheItem = HttpContext.Current.Cache;
                if (cacheItem[cacheKey] != null)
                {
                    return cacheItem[cacheKey];
                }
                var cacheValue = SerializerUtility.DeserializeFromXmlFile(xmlFile, objectT);
                CacheDependency cd = new CacheDependency(xmlFile);
                cacheItem.Add(cacheKey, cacheValue, cd
                    , Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration
                    , CacheItemPriority.Default, OnCacheItemRemovedCallack);
                return cacheValue;
            }
            else
            {
                return SerializerUtility.DeserializeFromXmlFile(xmlFile, objectT);
            }
        }
    }
}
