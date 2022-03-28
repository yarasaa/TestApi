using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserTest:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Department { get; set; }
        public string? Section { get; set; }
        public string? Unit { get; set; }
        public DateTime Date { get; set; }
        public int Vote { get; set; }
        public int VoteLimit { get; set; }

    }
}
