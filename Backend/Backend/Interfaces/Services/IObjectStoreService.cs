using Microsoft.AspNetCore.Mvc;

namespace Backend.Interfaces.Services
{
    public interface IObjectStoreService
    {
        Task<Guid> Create(object item,string folderName,string fileName);
        Task<object> Read( string folderName, string fileName);
        Task<bool> Update (object item, string folderName, string fileName);
        Task<bool> Delete( string folderName, string fileName);
    }
}
