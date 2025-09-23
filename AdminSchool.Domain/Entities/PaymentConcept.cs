using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{
    public class PaymentConcept : AuditableEntity<int>,IAggregateRoot
    {
        public string? Name { get; set; } // Ej: "Colegiatura", "Libros", "Uniformes"

        public decimal DefaultAmount { get; set; }

        public bool IsRecurring { get; set; } // true si es mensual
    }
}
