using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models
{
    public class UserProfile
    {
        public string Id { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        public int Age { get; set; }

    }
}
