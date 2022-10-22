using Core.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.DataAccess.UnitOfWork
{
    //public class UnitOfWork :IunitOfWork,IDisposable
    //{
    //    private readonly  MusicDbContext _musicDbContext;
    //    private readonly ILogger logger;

    //    public UnitOfWork(MusicDbContext musicDbContext, ILoggerFactory loggerFactory)
    //    {
    //        _musicDbContext = musicDbContext;
    //        this.logger = loggerFactory.CreateLogger("logs");
    //    }

    //    public Task ComplateAsync()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
