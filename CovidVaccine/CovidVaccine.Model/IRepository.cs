using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Model
{
    public interface IRepository
    {
        Task<List<T>> SelectAll<T>() where T : class;
        Task<T> SelectById<T>(int id) where T : class;
        void CreateAsync<T>(T entity) where T : class;
        void UpdateAsync<T>(T entity) where T : class;
        void DeleteAsync<T>(T entity) where T : class;
    }
}
