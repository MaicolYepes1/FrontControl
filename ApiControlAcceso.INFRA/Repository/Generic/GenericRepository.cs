using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.INFRA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.INFRA.Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Dependencias
        private readonly AppDataContext _context;
        private readonly DbSet<T> _dbset;
        #endregion

        #region Constructor
        public GenericRepository(AppDataContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        #endregion

        #region Metodos
        public async Task<IEnumerable<T>> GetAll()
        {
            return _dbset.ToList();
        }
        public async Task<T> GetById(object id)
        {
            return _dbset.Find(id);
        }
        public async Task<bool> Insert(T obj)
        {
            _dbset.Add(obj);
            Save();
            return true;
        }
        public async void Update(T obj)
        {
            _dbset.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(object id)
        {
            T existing = _dbset.Find(id);
            _dbset.Remove(existing);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
