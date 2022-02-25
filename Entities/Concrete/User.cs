using Core.Entities;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string UserName { get; set; }
        public string? Department { get; set; }
        public DateTime Date { get; set; }
        public int Vote { get; set; }



    }
}
