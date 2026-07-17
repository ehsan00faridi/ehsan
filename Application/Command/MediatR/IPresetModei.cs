namespace Application.Command.MediatR
{
    public interface IPresetModel
    {
        int? UserId { get; set; }
        bool IsAdmin {  get; set; }
        string Email { get; set; }
        string UserName {  get; set; }
    }
}
