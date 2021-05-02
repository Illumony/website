using System;
using System.Collections.Generic;

namespace OnlineTutor.Models
{
    public partial class PersonPhoto
    {
        public long Id { get; set; }
        public byte[] Photo { get; set; }
        public byte Purpose { get; set; }
    }
}
