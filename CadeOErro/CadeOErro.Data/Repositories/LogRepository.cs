using CadeOErro.Domain.Interfaces.Repositories;

namespace CadeOErro.Data.Repositories
{
    public class LogRepository: ILogRepository
    {
        private readonly CadeOErroContext _context;
        public LogRepository(CadeOErroContext context)
        {
            this._context = context;
        }
    }
}
