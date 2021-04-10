using MedicalConsultation.Models;
using MedicalConsultation.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalConsultation.Repos.Implementations
{
    public class MessageRepo : BaseRepo<Message>, IMessageRepo
    {
        private readonly MedConsAdminContext _context;
        public MessageRepo(MedConsAdminContext context) : base(context)
        {
            _context = context;
        }
    }
}
