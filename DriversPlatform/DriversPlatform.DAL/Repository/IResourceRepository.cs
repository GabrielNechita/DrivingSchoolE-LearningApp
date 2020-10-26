using DriversPlatform.DAL.Models;
using System.Collections.Generic;

namespace DriversPlatform.DAL.Repository
{
    public interface IResourceRepository
    {
        void AddResource(Resource newResource);
        void DeleteResource(int resourceId);
        List<Resource> GetResources();
        byte[] GetResourceById(int resourceId);
    }
}