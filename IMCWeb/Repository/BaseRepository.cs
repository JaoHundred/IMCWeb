using IMCWeb.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCWeb.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        public BaseRepository(ILiteDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        private ILiteDBContext _dBContext;

        public int Add(T data)
        {
            return _dBContext.LiteDatabase.GetCollection<T>().Insert(data);
        }

        public bool Delete(int id)
        {
            return _dBContext.LiteDatabase.GetCollection<T>().Delete(id);
        }

        public bool Update(T data, int id)
        {
            return _dBContext.LiteDatabase.GetCollection<T>().Update(id, data);
        }

        public IEnumerable<T> GetAllData()
        {
            return _dBContext.LiteDatabase.GetCollection<T>().FindAll();
        }

        public T FindData(int id)
        {
            return _dBContext.LiteDatabase.GetCollection<T>().FindById(id);
        }
    }
}
