using System;
using System.Collections.Generic;

namespace OnlineTutor.Models
{
    public partial class Person
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string BirthYear { get; set; }
        public bool? NativeEnglishSpeaker { get; set; }
        public string Phone { get; set; }
        public string WeChatId { get; set; }
        public string ParentEmail { get; set; }
        public string ParentPhone { get; set; }
        public string ParentWechatId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ReferalCode { get; set; }
        public bool IsStudent { get; set; }
        public bool IsInstructor { get; set; }
        public bool IsAdmin { get; set; }
        public string College { get; set; }
        public string Major { get; set; }
        public string GraduationYear { get; set; }
        public string Title { get; set; }
        public string SelfIntroduction { get; set; }
        public string HonorActivities { get; set; }
    }
}
