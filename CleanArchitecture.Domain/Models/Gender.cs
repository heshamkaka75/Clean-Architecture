using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Models
{
    public class Gender : BaseDominEntityInt
    {
        public string Name { get; set; } = null!;
    }
}
