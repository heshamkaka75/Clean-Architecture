using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Common
{
    public class BaseDominEntityInt
    {
        public int Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
    }
}
