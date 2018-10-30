namespace FluentAPI.Models.Models
{
  public interface IRecord
  {
    int Id { get; }
    string ToString();
    string ToJson();
    string AtAllColumns();
    string AllColumns();
  }
}
