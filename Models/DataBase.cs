using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace IT4.Models
{
    public class DataBase
    {
        public DataBase()
        {
            Table = new HashSet<Table>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Table> Table { get; set; }
    }
}
