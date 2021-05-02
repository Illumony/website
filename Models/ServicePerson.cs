using System;
using System.Collections.Generic;

namespace OnlineTutor.Models
{
    public partial class ServicePerson
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public long ServiceId { get; set; }
    }
}
