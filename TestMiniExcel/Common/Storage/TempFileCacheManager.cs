using Microsoft.Extensions.Caching.Distributed;

namespace TestMiniExcel.Common.Storage
{
    public class TempFileCacheManager : ITempFileCacheManager
    {
        private readonly IDistributedCache _cache;

        public TempFileCacheManager(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetFile(string token, byte[] content)
        {
            var cacheEntryOptions = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
            
            await _cache.SetAsync(token, content, cacheEntryOptions); 
        }

        public async Task<byte[]> GetFile(string token)
        {
            return await _cache.GetAsync(token);
        }

        // public void SetFile(string token, TempFileInfo info)
        // {
        //     _cache.Set(token, info, TimeSpan.FromMinutes(1));
        // }
        //
        // public TempFileInfo GetFileInfo(string token)
        // {
        //     return _cache.GetOrDefault(token);
        // }
    }
}