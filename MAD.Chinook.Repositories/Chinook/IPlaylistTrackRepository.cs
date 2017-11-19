using MAD.Chinook.Models;
using System.Collections.Generic;

namespace MAD.Chinook.Repositories.Chinook
{
    public interface IPlaylistTrackRepository: IRepository<PlaylistTrack>
    {

        IEnumerable<PlaylistTrack> PagedList(int startRow, int endRow);

        int Count();
    }
}
