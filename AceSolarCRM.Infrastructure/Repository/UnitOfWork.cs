using Repository.AppInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceSolarCRM.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ILeadRepository leadRepository, IContactRepository contacts, ICustomerRepository customers, IEmployeeRepository employees, IDealRepository deals)
        {
            Leads = leadRepository;
            Contacts = contacts;
            Customers = customers;
            Employees = employees;
            Deals = deals;
        }
        public ILeadRepository Leads { get; }
        public IContactRepository Contacts { get; }

        public ICustomerRepository Customers { get; }

        public IEmployeeRepository Employees { get; }

        public IDealRepository Deals { get; }
    }
}
