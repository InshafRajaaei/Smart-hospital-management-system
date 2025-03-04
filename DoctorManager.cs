using System;

namespace HospitalManagementSystem
{
    class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specialization { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Specialization: {Specialization}";
        }
    }

    class DoctorManager
    {
        public LinkedList<Doctor> doctors = new LinkedList<Doctor>();

        public void AddDoctor()
        {
            Console.WriteLine("\nAdd New Doctor");
            int id = Utility.GetIntInput("Enter Doctor ID: ");
            string name = Utility.GetNonEmptyString("Enter Doctor Name: ");
            string specialization = Utility.GetNonEmptyString("Enter Specialization: ");

            doctors.AddEnd(new Doctor { Id = id, Name = name, Specialization = specialization });
            Console.WriteLine("\nDoctor added successfully!");
        }
        public void DeleteDoctor(int id)
        {
            Doctor? doctorToDelete = null;
            foreach (var doctor in doctors.ToList())
            {
                if (doctor.Id == id)
                {
                    doctorToDelete = doctor;
                    break;
                }
            }

            if (doctorToDelete != null)
            {
                doctors.Remove(doctorToDelete);
                Console.WriteLine("\nDoctor deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nDoctor not found!");
            }
        }

        public void ViewDoctors()
        {
            Console.WriteLine("\nList of Doctors:");
            if (doctors.Count == 0)
            {
                Console.WriteLine("No doctors found.");
                return;
            }

            Doctor[] doctorArray = doctors.ToArray();

            BubbleSort(doctorArray);

            foreach (var doctor in doctorArray)
            {
                Console.WriteLine(doctor);
            }
        }
        public Doctor? SearchDoctor(int id)
        {
            Doctor? foundDoctor = null;
            doctors.Traverse(doctor =>
            {
                if (doctor.Id == id)
                {
                    foundDoctor = doctor;
                }
            });
            return foundDoctor;
        }
        private void BubbleSort(Doctor[] doctors)
        {
            int n = doctors.Length;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (doctors[j].Id > doctors[j + 1].Id)
                    {
                        var temp = doctors[j];
                        doctors[j] = doctors[j + 1];
                        doctors[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }
    }
}