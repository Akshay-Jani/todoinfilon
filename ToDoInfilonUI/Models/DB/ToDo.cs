using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ToDoInfilonUI.Models.DB
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public bool? Completed { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual AppUser User { get; set; }
    }
}
