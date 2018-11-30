using System.Collections.Generic;
using SimpleTaskSystem.Tasks.Dtos;

namespace SimpleTaskSystem.Tasks
{
  public class GetTasksOutput
  {
    public List<TaskDto> Tasks { get; set; }
  }
}