namespace Application.Cache;

public static class CacheConstants
{
    public static class Products
    {
        private const string Prefix = "products";
        
        public static string All => $"{Prefix}:all";
        public static string ById(Guid id) => $"{Prefix}:{id}";
        
        public static TimeSpan AllExpiration => TimeSpan.FromMinutes(5);
        public static TimeSpan ByIdExpiration => TimeSpan.FromMinutes(10);
    }
}