namespace SimpleTaskSystem.Tasks
{
  public class GetTasksInput
  {
    public TaskState? State { get; set; }

    public int? AssignedPersonId { get; set; }
  }
}