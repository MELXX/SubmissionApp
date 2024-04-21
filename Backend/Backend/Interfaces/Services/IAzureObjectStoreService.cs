namespace Backend.Interfaces.Services
{
    public interface IAzureObjectStoreService:IObjectStoreService
    {
        Task<Guid> Create(object item, string fileName, string? folderName = default);
        Task<object> Read(string folderName, string fileName);
        Task<bool> Update(object item, string folderName, string fileName);
        Task<bool> Delete(string folderName, string fileName);
    }
}