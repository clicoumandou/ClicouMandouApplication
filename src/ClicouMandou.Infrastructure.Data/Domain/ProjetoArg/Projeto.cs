using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClicouMandou.Infrastructure.Data.Domain.ProjetoArg
{
    public class Projeto : IEntity
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string ProjetoCode { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
