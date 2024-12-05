namespace VehicleInfoApp.Abstraction
{
    public interface IHttpclientCallers<T> where T : class
    {
        Task<T> GetRequest(string? relativeURL = null, Dictionary<string, string> HeaderOptions = null);

    }
}
