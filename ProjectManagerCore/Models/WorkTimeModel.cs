namespace ProjectManagerCore.Models
{
    public class WorkTimeModel
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public UserModel User { get; set; }
        public TaskModel Task { get; set; }
    }
}
