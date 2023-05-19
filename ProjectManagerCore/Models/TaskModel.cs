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
        public UserModel Appender { get; set; }
        public UserModel? Executor { get; set; }
        public WorkTimeModel? WorkTime { get; set; }
    }
}
