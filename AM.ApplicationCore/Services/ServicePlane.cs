﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : IServicePlane
    {
     
        private readonly IGenericRepository<Plane> _repo;
        public ServicePlane(IGenericRepository<Plane> repo)
        {
            _repo = repo;
        }

        public void Add(Plane plane)
        {
           _repo.Add(plane);
        }

        public IList<Plane> GetAll()
        {
            return (IList<Plane>)_repo.GetAll();
        }

        public void Remove(Plane plane)
        {
           _repo.Remove(plane);
        }
    }
}
