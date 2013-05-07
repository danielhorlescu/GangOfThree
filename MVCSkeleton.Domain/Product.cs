using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCSkeleton.Domain
{
    public class Product : IAggregateRoot
    {
        public virtual long Id { get; set; }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual double UnitPrice { get; set; }

        public virtual int UnitsInStock { get; set; }

        public virtual DateTime CreationDate { get; set; }
    }
}
