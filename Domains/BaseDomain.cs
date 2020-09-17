using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Domains
{
    public class BaseDomain
    {
        [Key]
        public Guid Id { get;  set; }

        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        public void SetId(Guid id)
        {
            this.Id = id;
        }
    }
}
