using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerCore.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public virtual UserModel Appender { get; set; }
        public virtual UserModel? Executor { get; set; }
        public virtual ProjectModel Project { get; set; }
        public virtual List<WorkTimeModel>? WorkTimes { get; set; }
    }
}
