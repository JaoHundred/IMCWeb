using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCWeb.Database
{
    public interface ILiteDBContext<T> where T : class
    {
        public LiteDatabase LiteDatabase { get; }
        public IList<T> GetCollection();
        public bool Upsert(T model);
        public bool Delete(int index);
        public T Find(int index);
    }
}
