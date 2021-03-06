﻿using MAD.Chinook.Models;
using System.Collections.Generic;

namespace MAD.Chinook.Repositories.Chinook
{
    public interface IEmployeeReository:IRepository<Employee>
    {

        IEnumerable<Employee> PagedList(int startRow, int endRow);

        int Count();

    }
}
