using MedicalConsultation.Models;
using MedicalConsultation.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalConsultation.Repos.Implementations
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        private readonly MedConsAdminContext _context;
        public UserRepo(MedConsAdminContext context) : base(context)
        {
            _context = context;
        }
    }
}
