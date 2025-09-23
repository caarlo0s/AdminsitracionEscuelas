using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{
    public class StudentPayment :AuditableEntity<Guid>, IAggregateRoot
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int PaymentConceptId { get; set; }
        public PaymentConcept PaymentConcept { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public decimal AmountPaid { get; set; }

        public int? SchoolYearId { get; set; }
        public SchoolYear SchoolYear { get; set; }

        public string Month { get; set; } // "Septiembre", "Octubre" (si aplica)

        public string Notes { get; set; }

        public PaymentStatus Status { get; set; } = PaymentStatus.Paid;
    }

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Partial
    }
}
