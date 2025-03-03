using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    class Appointment : IComparable<Appointment>
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsEmergency { get; set; }

        public int CompareTo(Appointment? other)
        {
            if (other == null) return 1; // Handle null case
            if (IsEmergency && !other.IsEmergency) return -1; // Emergency first
            if (!IsEmergency && other.IsEmergency) return 1;
            return AppointmentDate.CompareTo(other.AppointmentDate); // Earlier date first
        }
    }

    class AppointmentManager
    {
        public LinkedList<Appointment> appointments = new LinkedList<Appointment>();
        private PatientManager patientManager;
        private DoctorManager doctorManager;

        public AppointmentManager(PatientManager patientManager, DoctorManager doctorManager)
        {
            this.patientManager = patientManager;
            this.doctorManager = doctorManager;
        }

        public void ScheduleAppointment()
        {
            Console.WriteLine("\nSchedule an Appointment");

            int appointmentId = Utility.GetIntInput("Enter Appointment ID: ");
            int patientId = Utility.GetIntInput("Enter Patient ID: ");
            int doctorId = Utility.GetIntInput("Enter Doctor ID: ");

            var patient = patientManager.SearchPatient(patientId);
            if (patient == null)
            {
                Console.WriteLine("\nPatient not found!");
                return;
            }

            if (doctorManager.SearchDoctor(doctorId) == null)
            {
                Console.WriteLine("\nDoctor not found!");
                return;
            }

            Console.Write("Enter Appointment Date (YYYY-MM-DD HH:MM): ");
            DateTime appointmentDate;
            while (!DateTime.TryParse(Console.ReadLine(), out appointmentDate))
            {
                Console.Write("Invalid format! Enter Date (YYYY-MM-DD HH:MM): ");
            }

            appointments.AddEnd(new Appointment
            {
                AppointmentId = appointmentId,
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentDate = appointmentDate,
                IsEmergency = patient.IsEmergency
            });

            Console.WriteLine("\nAppointment scheduled successfully!");
        }
        public void DeleteAppointment(int appointmentId)
        {
            Appointment? appointmentToDelete = null;
            appointments.Traverse(appointment =>
            {
                if (appointment.AppointmentId == appointmentId)
                {
                    appointmentToDelete = appointment;
                }
            });

            if (appointmentToDelete != null)
            {
                appointments.Remove(appointmentToDelete);
                Console.WriteLine("\nAppointment deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nAppointment not found!");
            }
        }
        public void ViewAppointments()
        {
            Console.WriteLine("\nAppointments List:");
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }
            
            Appointment[] appointmentArray = appointments.ToArray();
            
            InsertionSort(appointmentArray);

            
            foreach (var appointment in appointmentArray)
            {
                Console.WriteLine($"ID: {appointment.AppointmentId} | Patient: {appointment.PatientId} | Doctor: {appointment.DoctorId} | Date: {appointment.AppointmentDate} | Emergency: {appointment.IsEmergency}");
            }
        }

        private void InsertionSort(Appointment[] appointments)
        {
            int n = appointments.Length;
            for (int i = 1; i < n; i++)
            {
                Appointment key = appointments[i];
                int j = i - 1;

                while (j >= 0 && appointments[j].AppointmentDate > key.AppointmentDate)
                {
                    appointments[j + 1] = appointments[j];
                    j--;
                }
                appointments[j + 1] = key;
            }
        }
    }
}