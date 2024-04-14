using DataBase;
using DataBase.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.DbProv
{
    public class ReportContext : IDb<ReportDbModel, int>
    {
        private readonly AppDbContext _appDbContext;

        public ReportContext(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(ReportDbModel entity)
        {
            if(entity == null)
            {
                throw new Exception("Entity is null");
            }
            await _appDbContext.ReportDbModels.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ReportDbModel> Read(int key, bool useNavigationalProperties = false, bool isReadOnlyTrue = true)
        {
            IQueryable<ReportDbModel> reports = _appDbContext.ReportDbModels;

            if (useNavigationalProperties)
            {
                reports = reports.Include(c => c.User);
            }
            if(isReadOnlyTrue)
            {
                reports.AsNoTrackingWithIdentityResolution();
            }

            return await reports.SingleOrDefaultAsync(u => u.IdReport == key);
        }

        public async Task<List<ReportDbModel>> ReadAll(bool useNavigationalProperties = false, bool isReadOnlyTrue = true)
        {
            IQueryable<ReportDbModel> reports = _appDbContext.ReportDbModels;

            if (useNavigationalProperties)
            {
                reports = reports.Include(c => c.User);
            }
            if (isReadOnlyTrue)
            {
                reports.AsNoTrackingWithIdentityResolution();
            }

            return await reports.ToListAsync();
        }

        public async Task Update(ReportDbModel entity, bool useNavigationalProperties)
        {
            ReportDbModel reportFromDb = await Read(entity.IdReport, useNavigationalProperties, false);

            if (reportFromDb == null) throw new ArgumentException("This report is null.");

            _appDbContext.ReportDbModels.Entry(reportFromDb).CurrentValues.SetValues(entity);

            if (useNavigationalProperties)
            {
                UserDbModel userToReport = _appDbContext.UserDbModels.Find(entity.UserId);

                if(userToReport == null)
                {
                    
                }
            }
        }

        public Task Delete(int key)
        {

        }
    }
}
