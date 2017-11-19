using MAD.Chinook.Models;
using System.Collections.Generic;

namespace MAD.Chinook.Repositories.Chinook
{
    public interface IPlaylistRepository:IRepository<Playlist>
    {

        IEnumerable<Playlist> PagedList(int startRow, int endRow);

        int Count();

    }
}
