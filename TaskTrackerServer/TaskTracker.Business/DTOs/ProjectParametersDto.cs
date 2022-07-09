using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data.Enums;

namespace TaskTracker.Business.DTOs
{
    public class ProjectParametersDto
    {
        public string ProjectName { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectCompletionDate { get; set; }
        public ProjectStatus? ProjectStatus { get; set; }
        public int? ProjectPriority { get; set; }



    }
}
