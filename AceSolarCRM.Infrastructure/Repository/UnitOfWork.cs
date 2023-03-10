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
        public UnitOfWork(ILeadRepository leadRepository, IContactRepository contacts)
        {
            Leads = leadRepository;
            Contacts = contacts;

        }
        public ILeadRepository Leads { get; }
        public IContactRepository Contacts { get; }
    }
}
