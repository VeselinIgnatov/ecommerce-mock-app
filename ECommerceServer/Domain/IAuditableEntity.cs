using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IAuditableEntity
    {
        public Guid Id { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public Guid AddeddBy { get; set; }

        public Guid ModifiedBy { get; set; }
    }
}
