using DriversPlatform.DAL.Models;
using System.Collections.Generic;

namespace DriversPlatform.BLL.Services
{
    public interface IResourceService
    {
        void AddResource(Resource newResource);
        void DeleteResource(int resourceId);
        List<Resource> GetResources();
        byte[] GetResourceById(int resourceId);
    }
}