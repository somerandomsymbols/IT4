using System.Data.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace IT4.Models
{
    public class Table
    {
        public Table()
        {
            Column = new HashSet<Column>();
            Row = new HashSet<Row>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DbId { get; set; }

        public virtual DataBase Db { get; set; }
        public virtual ICollection<Column> Column { get; set; }
        public virtual ICollection<Row> Row { get; set; }
    }
}
