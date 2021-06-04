using MedicalConsultation.Models;
using MedicalConsultation.Repos.Interfaces;

namespace MedicalConsultation.Repos.Implementations
{
    public class ContactRepo : BaseRepo<Contact>, IContactRepo
    {
        private readonly MedConsAdminContext _context;
        public ContactRepo(MedConsAdminContext context) : base(context)
        {
            _context = context;
        }
    }
}
