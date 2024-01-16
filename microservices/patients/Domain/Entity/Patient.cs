using Common.Core.Entity;

namespace Domain.Entity
{
    public class Patient : BaseEntity
    {
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
