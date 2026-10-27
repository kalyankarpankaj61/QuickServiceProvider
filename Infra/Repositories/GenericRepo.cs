using Infra.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class GenericRepo<T> : IGeneric<T> where T : class
    {
        DbContext db;
        public GenericRepo(DbContext db)
        {
            this.db = db;
        }

        public async Task<RepoResultDto> Delete(Int64 id)
        {
            RepoResultDto res=new RepoResultDto();
            try
            {
                var rec = await this.db.Set<T>().FindAsync(id);
                this.db.Set<T>().Remove(rec);
                await this.db.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Deleted Successfully";
                
            }
            catch (Exception ex)
            {
                res.IsSuccess= false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<List<T>> GetAll()
        {
            return await this.db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Int64 id)
        {
            return await this.db.Set<T>().FindAsync(id);
        }

        public async Task<RepoResultDto> Insert(T entity)
        {
            RepoResultDto res = new RepoResultDto();
            try
            {
                await this.db.Set<T>().AddAsync(entity);
                await this.db.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Inserted Successfull....!";
            }
            catch (Exception ex)
            {
                res.IsSuccess=false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<RepoResultDto> Update(T entity)
        {
            RepoResultDto res=new RepoResultDto();
            try
            {
                this.db.Entry(entity).State = EntityState.Modified;
                await this.db.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Record Updated...!";
            }
            catch (Exception ex)
            {
                res.IsSuccess= false;
                res.Message = ex.Message;
            }
            return res;
        }
    }
}
