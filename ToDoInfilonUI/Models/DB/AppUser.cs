using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ToDoInfilonUI.Models.DB
{
    public partial class AppUser
    {
        public AppUser()
        {
            ToDo = new HashSet<ToDo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }

        public virtual ICollection<ToDo> ToDo { get; set; }
    }
}
