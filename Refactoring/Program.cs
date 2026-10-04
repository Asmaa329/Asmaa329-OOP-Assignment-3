using Refactoring.part_01;
using Refactoring.part_01._2;
using Refactoring.part_02;
using Refactoring.part_03;
using RefactoringLab.Part02.Enrollment;
using System.Diagnostics;
using System.Text;

namespace Refactoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== part-01.1  (Notification)  ===");
            INotification scheduledUrgentEmail = new UrgentScheduledNotification(
                new UrgentNotification(new EmailNotification()), DateTime.Now.AddHours(18));
            scheduledUrgentEmail.Send("customer@example.com", "Your order ships tomorrow");

            INotification scheduleSms = new UrgentNotification(new SmsNotification());
            scheduleSms.Send("+201000000000", "OTP 4821");

            Console.WriteLine("=== part-01.2  (OrderRepository)  ===");
            IOrderRepository repo = new SqlOrderRepository();
            IMessageSender email = new SmtpEmailSender();
            var processor = new OrderProcessor(repo, email);
            processor.Process(1001, "customer@example.com");

            Console.WriteLine("=== part-01.3  (Carrier)  ===");

            ICarrier Carrier = new AramexCarrier();
            Console.WriteLine($"Aramex 2kg → {Carrier.Calculate(2)}");

            ICarrier Carrierr = new FedExCarrier();
            Console.WriteLine($"Aramex 2kg → {Carrierr.Calculate(2)}");


            Console.WriteLine("=== part-02  (Reports)  ===");

            var outDir = Path.Combine(Path.GetTempPath(), "refactoring-lab-part02");
            Directory.CreateDirectory(outDir);

            new CsvReportExporter().Export(Path.Combine(outDir, "report.csv"));
            new JsonReportExporter().Export(Path.Combine(outDir, "report.json"));
            new TextReportExporter().Export(Path.Combine(outDir, "report.txt"));
            Console.WriteLine($"Wrote reports to {outDir}");
            Console.WriteLine();

            Console.WriteLine("=== part-02  (Enrollment)  ===");
 
            var studentId = "S100";
            var courseId = "CS201";
            var amount = 1500m;

            var payment = new PaymentGateway();
            var seats = new SeatInventory();
            var invoices = new InvoiceGenerator();
            var emaill = new EmailService();

            payment.Charge(studentId, amount);
            seats.Reserve(courseId, studentId);
            var invoiceId = invoices.Create(studentId, amount);
            emaill.Send(studentId, "Enrollment confirmed", $"Invoice {invoiceId} for {courseId}");

            Console.WriteLine("=== part-03 ===");

            Console.WriteLine("=== Blocked users ===");
            const int blockedCount = 50_000;
            const int requestCount = 5_000;
            var blockedIds = BlockedUserChecker.BuildBlockedIds(blockedCount);
            var requestIds = BlockedUserChecker.BuildRequestIds(requestCount, blockedCount);
            var ms = BlockedUserChecker.MeasureMs(blockedIds, requestIds, out var found);
            Console.WriteLine($"blockedIds={blockedCount}, requests={requestCount}, found={found}, time={ms} ms");
            Console.WriteLine();

            Console.WriteLine("=== Students (1_000_000) ===");
            var printed = 0;
            foreach (var student in StudentCatalog.GetAllStudents())
            {
                Console.WriteLine($"{student.Id}: {student.Name}");
                printed++;
                if (printed == 3)
                    break;
            }
            Console.WriteLine($"printed={printed}");



        }




    }

}



