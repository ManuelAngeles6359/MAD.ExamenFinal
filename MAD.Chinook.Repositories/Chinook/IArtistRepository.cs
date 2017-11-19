using MAD.Chinook.Models;
using System.Collections.Generic;

namespace MAD.Chinook.Repositories.Chinook
{
    public interface IArtistRepository: IRepository<Artist>
    {

        IEnumerable<Artist> PagedList(int startRow, int endRow);

        int Count();

    }
}
