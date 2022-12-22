using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace IT4.Models
{
    public class Column
    {


        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid TableId { get; set; }

        public virtual Table Table { get; set; }

    }
}
