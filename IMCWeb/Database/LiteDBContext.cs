using IMCWeb.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IMCWeb.Database
{
    public class LiteDBContext<T> : ILiteDBContext<T> where T : class
    {
        public LiteDatabase LiteDatabase { get; }

        public LiteDBContext()
        {
            var bsonMapper = BsonMapper.Global;

            bsonMapper.Entity<PersonLogin>().Id(p => p.Id).DbRef(p => p.IMC);
            bsonMapper.Entity<IMC>().Id(p => p.Id);

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "database.db");

            LiteDatabase = new LiteDatabase($"Filename={fullPath}", bsonMapper);
        }

        public IList<T> GetCollection()
        {
            return LiteDatabase.GetCollection<T>().FindAll().ToList();
        }

        public bool Upsert(T model)
        {
            return LiteDatabase.GetCollection<T>().Upsert(model);
        }

        public bool Delete(int index)
        {
            return LiteDatabase.GetCollection<T>().Delete(index);
        }

        public T Find(int index)
        {
            return LiteDatabase.GetCollection<T>().FindById(index);
        }
    }
}
