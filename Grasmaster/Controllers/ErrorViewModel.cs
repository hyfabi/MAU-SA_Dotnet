namespace At.Mausa.Grasmaster.Frontend.Controllers; 
public class ErrorViewModel {
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}