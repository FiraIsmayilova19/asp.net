namespace M1.Services.Services
{
    public interface IQueueService
{
    Task SendMessageAsync(string message);
    Task<string> ReceiveMessageAsync();
}
}