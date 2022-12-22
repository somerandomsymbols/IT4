using System;

namespace IT4.Models
{
    public class UpdateColumnRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid TableId { get; set; }
    }
}
