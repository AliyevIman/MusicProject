using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRefeshTokenDal : EfEntityRepositoryBase<MusicDbContext, RefreshToken>, IRefreshTokensDal
    {
		//private readonly ILogger _logger;

		//public EfRefeshTokenDal(ILogger logger)
		//{
		//	_logger = logger;
		//}
		
		public  async Task<IEnumerable<RefreshToken>> GetAll()
        {
            using MusicDbContext context = new();

            try
            {
				return await context.RefreshTokens.Where(x => x.Status == 1).AsNoTracking().ToListAsync();
			}
			catch (Exception ex)
			{
				//(ex, "{Repo} All method has generated an error ", typeof(EfRefeshTokenDal));
				return new List<RefreshToken>();
				
			}
        }
    }
}
