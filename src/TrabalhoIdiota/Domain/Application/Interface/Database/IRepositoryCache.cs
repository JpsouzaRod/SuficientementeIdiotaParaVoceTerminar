namespace TrabalhoIdiota.Domain.Application.Interface.Database
{
    public interface IRepositoryCache
    {
        Task SetAsync(string key, string value);    
        Task<string> GetAsync(string key);  
        Task DeleteAsync(string key);   
    }
}
