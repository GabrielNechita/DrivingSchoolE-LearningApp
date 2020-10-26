using DriversPlatform.DAL.Models;
using DriversPlatform.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.BLL.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public void AddResource(Resource newResource)
        {
            _resourceRepository.AddResource(newResource);
        }

        public List<Resource> GetResources()
        {
            return _resourceRepository.GetResources();
        }

        public void DeleteResource(int resourceId)
        {
            _resourceRepository.DeleteResource(resourceId);
        }

        public byte[] GetResourceById(int resourceId)
        {
            return _resourceRepository.GetResourceById(resourceId);
        }
    }
}
