using System;

namespace HospitalManagementSystem
{
    class Bill
    {
        public int PatientId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }

    class BillingManager
    {
        private LinkedList<Bill> bills = new LinkedList<Bill>();

        public void AddBill()
        {
            Console.WriteLine("\nAdd a Bill");
            int patientId = Utility.GetIntInput("Enter Patient ID: ");
            decimal amount = Utility.GetDecimalInput("Enter Amount: ");
            string description = Utility.GetNonEmptyString("Enter Description: ");

            bills.AddEnd(new Bill { PatientId = patientId, Amount = amount, Description = description });
            Console.WriteLine("Bill added successfully!");
        }
        public void ViewBill(int patientId)
        {
            Console.WriteLine("\nBills for Patient ID: " + patientId);
            bool found = false;
            foreach (var bill in bills.ToList())
            {
                if (bill.PatientId == patientId)
                {
                    Console.WriteLine($"Amount: {bill.Amount} | Description: {bill.Description}");
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("No bills found for this patient.");
        }
    }
}