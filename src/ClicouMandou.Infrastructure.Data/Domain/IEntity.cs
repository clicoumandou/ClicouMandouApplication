using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClicouMandou.Infrastructure.Data.Domain
{
    public interface IEntity
    {
        Int64 Id { get; set; }
    }
}
