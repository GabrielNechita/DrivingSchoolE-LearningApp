using DriversPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriversPlatform.DAL.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly DatabaseContext _context;

        public ResourceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddResource(Resource newResource)
        {
            _context.Resources.Add(newResource);
            _context.SaveChanges();
        }

        public List<Resource> GetResources()
        {
            return _context.Resources.ToList();
        }

        public void DeleteResource(int resourceId)
        {
            var resource = _context.Resources.FirstOrDefault(r => r.Id == resourceId);
            _context.Resources.Remove(resource);
            _context.SaveChanges();
        }

        public byte[] GetResourceById(int resourceId)
        {
            return _context.Resources.FirstOrDefault(r => r.Id == resourceId).File;
        }
    }
}
