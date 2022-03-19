using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserTest:IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Unit { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh-mm-ss}")]
        public DateTime DateTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int Vote { get; set; }
        public int MaxVote { get; set; }
    }
}
