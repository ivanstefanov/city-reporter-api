using DataBase;
using DataBase.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReportContext : IDb<ReportDbModel, int>
    {
        private readonly AppDbContext _appDbContext;

        public ReportContext()
        {
            _appDbContext = new AppDbContext();
        }

        public async Task Create(ReportDbModel entity)
        {
            try
            {
                await _appDbContext.ReportDbModels.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception) 
            {
                
            }
        }

        public async Task<ReportDbModel> Read(int entity, bool useNavigationalProperties = false, bool isReadOnlyTrue = true)
        {
            await _appDbContext.ReportDbModels.FindAsync(entity, useNavigationalProperties, isReadOnlyTrue);
        }

        public Task<List<ReportDbModel>> ReadAll(bool useNavigationalProperties = false, bool isReadOnlyTrue = true)
        {
            
        }

        public Task Update(ReportDbModel entity, bool useNavigationalProperties)
        {
            
        }

        public Task Delete(int key)
        {

        }
    }
}
