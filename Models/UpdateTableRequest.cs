using System;

namespace IT4.Models
{
    public class UpdateTableRequest
    {
        public string Name { get; set; }
        public Guid DbId { get; set; }
    }
}
