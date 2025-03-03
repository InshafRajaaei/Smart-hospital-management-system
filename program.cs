using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main()
        {
            DisplayBanner();
            // Initialize managers
            PatientManager patientManager = new PatientManager();
            DoctorManager doctorManager = new DoctorManager();
            AppointmentManager appointmentManager = new AppointmentManager(patientManager, doctorManager);
            HospitalBedManager bedManager = new HospitalBedManager(50);
            BillingManager billingManager = new BillingManager();
            LoginManager loginManager = new LoginManager();
            AddPredefinedDataDirectly(patientManager, doctorManager, appointmentManager, bedManager);
            if (!loginManager.ShowLoginMenu())
            {
                Console.WriteLine("Exiting system...");
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n Smart Hospital Management System");
                Console.WriteLine("1 Manage Patients");
                Console.WriteLine("2 Manage Doctors");
                Console.WriteLine("3 Manage Appointments");
                Console.WriteLine("4 Manage Beds");
                Console.WriteLine("5 Manage Billing");
                Console.WriteLine("6 Exit");
                Console.Write("Choose an option: ");

                int choice = Utility.GetIntInput("");

                switch (choice)
                {
                    case 1:
                        ManagePatients(patientManager);
                        break;
                    case 2:
                        ManageDoctors(doctorManager);
                        break;
                    case 3:
                        ManageAppointments(appointmentManager);
                        break;
                    case 4:
                        ManageBeds(bedManager);
                        break;
                    case 5:
                        ManageBilling(billingManager);
                        break;
                    case 6:
                        Console.WriteLine("\nExiting the system...");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice! Please try again.");
                        break;
                }
            }
        }
        static void AddPredefinedDataDirectly(PatientManager patientManager, DoctorManager doctorManager, AppointmentManager appointmentManager, HospitalBedManager bedManager)
        {

            patientManager.patientsList.AddEnd(new Patient { Id = 17, Name = "John Doe", Age = 30, Disease = "Fever", IsEmergency = false });
            patientManager.patientsList.AddEnd(new Patient { Id = 22, Name = "Jane Smith", Age = 25, Disease = "Broken Arm", IsEmergency = true });
            patientManager.patientsList.AddEnd(new Patient { Id = 19, Name = "Alice Johnson", Age = 40, Disease = "Headache", IsEmergency = false });
            patientManager.patientsList.AddEnd(new Patient { Id = 5, Name = "Bob Brown", Age = 50, Disease = "Diabetes", IsEmergency = false });
            patientManager.patientsList.AddEnd(new Patient { Id = 8, Name = "Charlie Davis", Age = 35, Disease = "Chest Pain", IsEmergency = true });

            doctorManager.doctors.AddEnd(new Doctor { Id = 101, Name = "Dr. Alice Brown", Specialization = "Cardiology" });
            doctorManager.doctors.AddEnd(new Doctor { Id = 102, Name = "Dr. Bob Green", Specialization = "Orthopedics" });
            doctorManager.doctors.AddEnd(new Doctor { Id = 103, Name = "Dr. Charlie White", Specialization = "Neurology" });
            doctorManager.doctors.AddEnd(new Doctor { Id = 104, Name = "Dr. David Black", Specialization = "Pediatrics" });
            doctorManager.doctors.AddEnd(new Doctor { Id = 105, Name = "Dr. Eve Blue", Specialization = "Dermatology" });

            appointmentManager.appointments.AddEnd(new Appointment { AppointmentId = 1, PatientId = 1, DoctorId = 101, AppointmentDate = DateTime.Now.AddHours(1), IsEmergency = false });
            appointmentManager.appointments.AddEnd(new Appointment { AppointmentId = 2, PatientId = 2, DoctorId = 102, AppointmentDate = DateTime.Now.AddHours(2), IsEmergency = true });
            appointmentManager.appointments.AddEnd(new Appointment { AppointmentId = 3, PatientId = 3, DoctorId = 103, AppointmentDate = DateTime.Now.AddHours(3), IsEmergency = false });
            appointmentManager.appointments.AddEnd(new Appointment { AppointmentId = 4, PatientId = 4, DoctorId = 104, AppointmentDate = DateTime.Now.AddHours(4), IsEmergency = false });
            appointmentManager.appointments.AddEnd(new Appointment { AppointmentId = 5, PatientId = 5, DoctorId = 105, AppointmentDate = DateTime.Now.AddHours(5), IsEmergency = true });

            bedManager.allocatedBeds.AddEnd(1);
            bedManager.allocatedBeds.AddEnd(2);
            bedManager.allocatedBeds.AddEnd(3);
            bedManager.allocatedBeds.AddEnd(4);
            bedManager.allocatedBeds.AddEnd(5);
        }
       


        static void ManageAppointments(AppointmentManager appointmentManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n Appointment Management");
                Console.WriteLine("1 Schedule Appointment");
                Console.WriteLine("2 View Appointments");
                Console.WriteLine("3 Delete Appointment");
                Console.WriteLine("4 Back to Main Menu");
                Console.Write("Choose an option: ");

                int choice = Utility.GetIntInput("");

                switch (choice)
                {
                    case 1:
                        appointmentManager.ScheduleAppointment();
                        break;
                    case 2:
                        appointmentManager.ViewAppointments();
                        break;
                    case 3:
                        int deleteId = Utility.GetIntInput("Enter Appointment ID to delete: ");
                        appointmentManager.DeleteAppointment(deleteId);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("\n Invalid choice! Please try again.");
                        break;
                }
                Console.Write("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void ManageBeds(HospitalBedManager bedManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n Bed Management");
                Console.WriteLine("1 Allocate Bed");
                Console.WriteLine("2 Free Bed");
                Console.WriteLine("3 Back to Main Menu");
                Console.Write("Choose an option: ");

                int choice = Utility.GetIntInput("");

                switch (choice)
                {
                    case 1:
                        bedManager.AllocateBed();
                        break;
                    case 2:
                        int bedId = Utility.GetIntInput("Enter Bed ID to free: ");
                        bedManager.FreeBed(bedId);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice! Please try again.");
                        break;
                }
                Console.Write("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void ManageBilling(BillingManager billingManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nBilling Management");
                Console.WriteLine("1 Add Bill");
                Console.WriteLine("2 View Bill");
                Console.WriteLine("3 Back to Main Menu");
                Console.Write("Choose an option: ");

                int choice = Utility.GetIntInput("");

                switch (choice)
                {
                    case 1:
                        billingManager.AddBill();
                        break;
                    case 2:
                        int id = Utility.GetIntInput("Enter Patient ID to view bill: ");
                        billingManager.ViewBill(id);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("\n Invalid choice! Please try again.");
                        break;
                }
                Console.Write("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void ManagePatients(PatientManager patientManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n Patient Management");
                Console.WriteLine("1 Add Patient");
                Console.WriteLine("2 View Patients");
                Console.WriteLine("3 Search Patient");
                Console.WriteLine("4 Delete Patient");
                Console.WriteLine("5 Back to Main Menu");
                Console.Write("Choose an option: ");

                int choice = Utility.GetIntInput("");

                switch (choice)
                {
                    case 1:
                        patientManager.AddPatient();
                        break;
                    case 2:
                        patientManager.ViewPatients();
                        break;
                    case 3:
                        int id = Utility.GetIntInput("Enter Patient ID to search: ");
                        patientManager.SearchPatient(id);
                        break;
                    case 4:
                        int deleteId = Utility.GetIntInput("Enter Patient ID to delete: ");
                        patientManager.DeletePatient(deleteId);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice! Please try again.");
                        break;
                }
                Console.Write("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void ManageDoctors(DoctorManager doctorManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nDoctor Management");
                Console.WriteLine("1 Add Doctor");
                Console.WriteLine("2 View Doctors");
                Console.WriteLine("3 Delete Doctor");
                Console.WriteLine("4 Back to Main Menu");
                Console.Write("Choose an option: ");

                int choice = Utility.GetIntInput("");

                switch (choice)
                {
                    case 1:
                        doctorManager.AddDoctor();
                        break;
                    case 2:
                        doctorManager.ViewDoctors();
                        break;
                    case 3:
                        int deleteId = Utility.GetIntInput("Enter Doctor ID to delete: ");
                        doctorManager.DeleteDoctor(deleteId);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice! Please try again.");
                        break;
                }
                Console.Write("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void DisplayBanner()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ResetColor();
            Console.WriteLine("===================================================================");
            Console.WriteLine("           Welcome to the Hospital Management System               ");
            Console.WriteLine("===================================================================");
            Console.WriteLine();
        }
    }
}