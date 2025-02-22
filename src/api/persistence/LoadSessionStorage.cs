using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using persistence.EF;
using persistence.Entities;

namespace persistence;

public class LoadSessionStorage(MyDataContext dbContext)
{
    public async Task<LoadSession?> ActiveSession(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<LoadSession>()
            .Where(ls => ls.EndTimestamp == null)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<ILoadSession> AddAsync(ILoadSession loadSession, CancellationToken cancellationToken = default)
    {
        dbContext.Attach(loadSession);
        await dbContext.SaveChangesAsync(cancellationToken);

        return loadSession;
    }
}