﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDAL.Repositories
{
    public interface IRepository<DTO, Entity> : IDisposable
    {
        void Add(DTO obj);
        void Remove(DTO obj);
        IEnumerable<DTO> GetAll();
        IEnumerable<DTO> FirstOrDefault(Expression<Func<DTO, bool>> condition);
        IEnumerable<DTO> GetMany(Expression<Func<DTO, bool>> condition);
        void SaveChanges();
        Entity ToEntity(DTO source);
        void Update(DTO obj);
        Entity GetEntity(DTO source);
        Entity GetEntityNameById(int id);
        IEnumerable<DTO> Items { get; }

    }
}
