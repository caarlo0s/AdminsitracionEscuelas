using AdminSchool.Domain.Abstraction;
using AdminSchool.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Domain.Entities
{

    public class StudentNote : AuditableEntity<int>,IAggregateRoot
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public string Title { get; set; } // Ej: "Comportamiento en clase"
        public string Content { get; set; } // Texto libre de la nota


        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public NoteType Type { get; set; } = NoteType.General;
    }
    public enum NoteType
    {
        General,
        Comportamiento,
        Académico,
        Asistencia
    }
}
