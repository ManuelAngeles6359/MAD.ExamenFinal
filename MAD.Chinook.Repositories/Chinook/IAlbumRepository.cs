using MAD.Chinook.Models;
using System.Collections.Generic;

namespace MAD.Chinook.Repositories.Chinook
{
    public interface IAlbumRepository: IRepository<Album>
    {


        IEnumerable<Album> PagedList(int startRow, int endRow);

        int Count();

    }
}
