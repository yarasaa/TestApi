using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VoteTest:IEntity
    {
        public int Id { get; set; }
        public int Vote { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Unit { get; set; }
        public DateTime Date { get; set; }
        public DateTime Datetime { get; set; }
    }
}
