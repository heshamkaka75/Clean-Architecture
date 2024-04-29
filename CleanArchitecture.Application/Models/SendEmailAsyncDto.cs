using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Models
{
    public class SendEmailAsyncDto
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
