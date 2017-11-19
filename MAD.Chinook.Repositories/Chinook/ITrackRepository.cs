using MAD.Chinook.Models;
using System.Collections.Generic;

namespace MAD.Chinook.Repositories.Chinook
{
    public interface ITrackRepository: IRepository<Track>
    {

        IEnumerable<Track> PagedList(int startRow, int endRow);

        int Count();

    }
}
