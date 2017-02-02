
using System;
using System.ComponentModel.DataAnnotations;

namespace SuiteSolution.Core.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
