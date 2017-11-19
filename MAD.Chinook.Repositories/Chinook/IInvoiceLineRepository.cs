using MAD.Chinook.Models;
using System.Collections.Generic;

namespace MAD.Chinook.Repositories.Chinook
{
    public interface IInvoiceLineRepository: IRepository<InvoiceLine>
    {

        IEnumerable<InvoiceLine> PagedList(int startRow, int endRow);

        int Count();

    }
}
