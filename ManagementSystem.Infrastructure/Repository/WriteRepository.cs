﻿using MagamentSystem.Application.Repository;
using ManagamentSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ManagementSystem.Infrastructure.Repository
{
	public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
	{
		private readonly ManagamentContext _context;

		public WriteRepository(ManagamentContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task<bool> AddAsync(T entity)
		{
			EntityEntry entityEntry = await Table.AddAsync(entity);
			entityEntry.State = EntityState.Added;
			entity.CreatedDate = DateTime.UtcNow;
			return true;
		}

		

		public async Task<bool> AddRangeAsync(List<T> entities)
		{
			await Table.AddRangeAsync(entities);
			foreach (var entity in entities)
			{
				entity.CreatedDate = DateTime.UtcNow;
			}
			return true;
		}


		public bool Remove(T entity)
		{
			EntityEntry entityEntry = Table.Update(entity);
			entityEntry.State = EntityState.Deleted;
			entity.RemovedDate = DateTime.UtcNow;
			return true;

		}

		public async Task<int> Save()
		{
			return await _context.SaveChangesAsync();
		}

		public bool Update(T entity)
		{
			EntityEntry entityEntry = Table.Update(entity);
			entityEntry.State = EntityState.Modified;
			entity.ModifiedDate = DateTime.UtcNow;
			return true;
		}
	}
}
