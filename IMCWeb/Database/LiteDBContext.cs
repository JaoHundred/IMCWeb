using IMCWeb.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IMCWeb.Database
{
    public class LiteDBContext : ILiteDBContext
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

    }
}
