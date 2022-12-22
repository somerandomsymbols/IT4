using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace IT4.Models
{
    public class Row
    {

        public Guid Id { get; set; }
        public Guid TableId { get; set; }

        public virtual Table Table { get; set; }
    }
}
