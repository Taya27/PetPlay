using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetPlayBackend.Domain.Models
{
    public class Connection
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }


        public Guid ToyId { get; set; }
        public Toy Toy { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
