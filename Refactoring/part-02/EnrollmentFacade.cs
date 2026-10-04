using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_02
{
    using RefactoringLab.Part02.Enrollment;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace Refactoring.part_02
    {
        public class Enrollment
        {
            private readonly PaymentGateway _pay;
            private readonly SeatInventory _seat;
            private readonly InvoiceGenerator _invoice;
            private readonly EmailService _email;


            public Enrollment(PaymentGateway pay, SeatInventory seat, InvoiceGenerator invoice, EmailService email)
            {
                _pay = pay;
                _seat = seat;
                _invoice = invoice;
                _email = email;
            }

            public void Enroll(string studentId, string courseId, decimal amount)
            {
                _pay.Charge(studentId, amount);
                _seat.Reserve(courseId, studentId);
                var invoiceId = _invoice.Create(studentId, amount);
                _email.Send(studentId, "Enrollment Confirmation", $"Invoice: {invoiceId}");
            }
        }

    }

}
