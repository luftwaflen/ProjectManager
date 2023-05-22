namespace ProjectManagerCore.Models
{
    public class WorkTimeModel
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public virtual UserModel User { get; set; }
        public virtual TaskModel Task { get; set; }
    }
}
