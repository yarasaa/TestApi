using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserInfo:IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? Department { get; set; }
        public string? Section { get; set; }
        public string? Unit { get; set; }
    }
}
