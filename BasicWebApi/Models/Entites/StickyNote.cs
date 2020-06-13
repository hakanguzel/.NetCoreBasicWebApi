using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebApi.Models.Entites
{
    public class StickyNote
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public virtual User User { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
