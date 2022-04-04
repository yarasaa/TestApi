using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class UserTest:IEntity
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [ForeignKey("User")]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public string? Department { get; set; }
        public string? Section { get; set; }
        public string? Unit { get; set; }
        [JsonIgnore]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        public int Vote { get; set; }
        public int VoteLimit { get; set; }

    }
}
