using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Model
{


    public class VuelingObject
    {
        [Column(IsPrimaryKey = true)]
        public Guid Guid { get; set; }
    }
}
