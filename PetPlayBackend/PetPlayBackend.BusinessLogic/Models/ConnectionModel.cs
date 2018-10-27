using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.Models
{
    public class ConnectionModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }


        public Guid ToyId { get; set; }
        public ToyModel Toy { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
    }
}
