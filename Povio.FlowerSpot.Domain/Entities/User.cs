using Povio.FlowerSpot.Domain.Common;

namespace Povio.FlowerSpot.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
