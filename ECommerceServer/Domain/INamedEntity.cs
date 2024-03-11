using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface INamedEntity : IAuditableEntity
    {
        public string Name { get; set; }    

        public string Description { get; set; }
    }
}
