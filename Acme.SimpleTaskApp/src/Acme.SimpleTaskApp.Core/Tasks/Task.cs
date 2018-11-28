using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Acme.SimpleTaskApp.People;
using Acme.SimpleTaskApp.Tasks;

namespace Acme.SimpleTaskApp.Tasks
{
  [Table("AppTasks")]
  public class Task : Entity, IHasCreationTime
  {
    public const int MaxTitleLength = 256;
    public const int MaxDescriptionLength = 64 * 1024; //64KB

    [ForeignKey(nameof(AssignedPersonId))]
    public Person AssignedPerson { get; set; }
    public Guid? AssignedPersonId { get; set; }

    [Required]
    [StringLength(MaxTitleLength)]
    public string Title { get; set; }

    [StringLength(MaxDescriptionLength)]
    public string Description { get; set; }

    public DateTime CreationTime { get; set; }

    public TaskState State { get; set; }

    public Task()
    {
      CreationTime = Clock.Now;
      State = TaskState.Open;
    }

    public Task(string title, string description = null, Guid? assignedPersonId = null)
      : this()
    {
      Title = title;
      Description = description;
      AssignedPersonId = assignedPersonId;
    }
  }
}