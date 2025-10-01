using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoopDreams.Models
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string RecipientEmail { get; set; }
    }
}
