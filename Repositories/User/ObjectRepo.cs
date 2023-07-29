using Book_Keeper_DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.User
{
    public class ObjectRepo<T> : IObjectRepo<T> where T : class
    {
        private readonly Book_Keeper_DbContext_Layer.DbContextLayer _dbLayer;
        public ObjectRepo(Book_Keeper_DbContext_Layer.DbContextLayer dbContext)
        {
            _dbLayer = dbContext;
        }
      
        public async Task<T> DeleteObject(int id)
        {
          var obj =   await _dbLayer.Set<T>().FindAsync(id);
             _dbLayer.Set<T>().Remove(obj);
            await _dbLayer.SaveChangesAsync();
            return obj;

        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book_Keeper_DomainModels.User> FindObjectByUserName(string username) 
        {
            Book_Keeper_DomainModels.User obj = await _dbLayer.Users.FirstOrDefaultAsync(x => x.UserName.Equals(username));
            return obj;
        }

        public Task<T> FindObjectByUserName(T request)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllObject()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllObjectsByObject(int user_id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetObjectById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> RegisterObject(T request)
        {
            var entityEntry = await _dbLayer.Set<T>().AddAsync(request);
            await _dbLayer.SaveChangesAsync();
            return entityEntry.Entity;

        }

        public Task<T> UpdateObject(int id, T request)
        {
            throw new NotImplementedException();
        }

     
    }
}
