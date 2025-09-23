using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{
    public class SchoolYear : AuditableEntity<int>, IAggregateRoot
    {
        public string Name { get; set; } // Ej: "2024-2025"

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<StudentPayment> StudentPayments { get; set; } = new();

    }
}
