using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AppInterface.Interfaces
{
    public interface IUnitOfWork
    {
        ILeadRepository Leads { get; }
        IContactRepository Contacts { get; }
        IEmployeeRepository Employees { get; }

    }
}
