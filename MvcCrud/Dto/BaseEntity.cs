using System;

namespace MvcCrud
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid CreatedById { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid UpdatedById { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }

    }
}