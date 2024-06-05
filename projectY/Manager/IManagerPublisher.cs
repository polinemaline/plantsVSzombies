using projectY.Models;

namespace projectY.Manager
{
    public interface IManagerPublisher
    {
        Task<List<Publisher>> GetPublishersAsync();
        Task<Publisher> GetPublisherByIdAsync(int id);
        Task<bool> UpdatePublisherAsync(int id, Publisher publisher);
        Task<Publisher> CreatePublisherAsync(Publisher publisher);
        Task<bool> DeletePublisherAsync(int id);
    }
}
