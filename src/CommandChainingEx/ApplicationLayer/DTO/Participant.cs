using System;

namespace ApplicationLayer.DTO
{
    public class Participant
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int CategoryId { get; set; } = -1;
    }
}
