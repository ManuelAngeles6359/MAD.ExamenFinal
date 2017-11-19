using MAD.Chinook.Models;
using System.Collections.Generic;

namespace MAD.Chinook.Repositories.Chinook
{
    public interface ICustomerRepository:IRepository<Customer>
    {

        IEnumerable<Customer> PagedList(int startRow, int endRow);

        int Count();

    }
}
