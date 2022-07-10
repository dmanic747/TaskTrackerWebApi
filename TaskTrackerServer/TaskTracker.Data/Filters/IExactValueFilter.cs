using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Data.Filters
{
    public interface IExactValueFilter
    {
        public string Name { get; set; }
        public byte? Status { get; set; }
        public int? Priority { get; set; }
    }
}
