using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Keeper_DomainModels;


namespace Repositories.User
{
    
    public interface IObjectRepo<T>
    {
        Task<bool> Exist(int id);
        Task<T> RegisterObject(T request);
        Task<T> UpdateObject(int id, T request);

        Task<T> GetObjectById(int id);
        Task<List<T>> GetAllObject();

        Task<List<T>> GetAllObjectsByObject(int user_id);

        Task<T> DeleteObject(int id);
    }
}
