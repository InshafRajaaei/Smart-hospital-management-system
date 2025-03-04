using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    class PatientManager
    {
        public LinkedList<Patient> patientsList = new LinkedList<Patient>();

        public void AddPatient()
        {
            Console.WriteLine("\nAdd New Patient");
            int id = Utility.GetIntInput("Enter Patient ID: ");
            string name = Utility.GetNonEmptyString("Enter Patient Name: ");
            int age = Utility.GetIntInput("Enter Patient Age: ");
            string disease = Utility.GetNonEmptyString("Enter Disease: ");
            bool isEmergency = Utility.GetNonEmptyString("Is this an emergency? (Y/N): ").ToUpper() == "Y";

            var patient = new Patient { Id = id, Name = name, Age = age, Disease = disease, IsEmergency = isEmergency };
            patientsList.AddEnd(patient);
            Console.WriteLine("\nPatient added successfully!");
        }

        public void DeletePatient(int id)
        {
            Patient? patientToDelete = null;
            foreach (var patient in patientsList.ToList())
            {
                if (patient.Id == id)
                {
                    patientToDelete = patient;
                    break;
                }
            }
            if (patientToDelete != null)
            {
                patientsList.Remove(patientToDelete);
                Console.WriteLine("\nPatient deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nPatient not found!");
            }
        }

        public void ViewPatients()
        {
            Console.WriteLine("\nList of Patients:");

            List<Patient> patients = patientsList.ToList();

            MergeSort(patients, 0, patients.Count - 1);
            //BubbleSort(patients);
            //InsertionSort(patients);
            foreach (var patient in patients)
            {
                Console.WriteLine(patient);
            }
        }

        public Patient? SearchPatient(int id)
        {
            Patient? foundPatient = null;
            foreach (var patient in patientsList.ToList())
            {
                if (patient.Id == id)
                {
                    foundPatient = patient;
                    break;
                }
            }
            if (foundPatient != null)
            {
                Console.WriteLine("\nPatient Found:");
                Console.WriteLine($"ID: {foundPatient.Id} | Name: {foundPatient.Name} | Age: {foundPatient.Age} | Disease: {foundPatient.Disease} | Emergency: {foundPatient.IsEmergency}");
                return foundPatient;
            }
            else
            {
                Console.WriteLine("\nPatient not found!");
                return null;
            }
        }
        private void MergeSort(List<Patient> patients, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(patients, left, middle);
                MergeSort(patients, middle + 1, right);
                Merge(patients, left, middle, right);
            }
        }
        private void Merge(List<Patient> patients, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;
            Patient[] leftArray = new Patient[n1];
            Patient[] rightArray = new Patient[n2];
            for (int i = 0; i < n1; i++)
                leftArray[i] = patients[left + i];
            for (int j = 0; j < n2; j++)
                rightArray[j] = patients[middle + 1 + j];
            int x = 0, y = 0;
            int k = left;
            while (x < n1 && y < n2)
            {
                if (leftArray[x].Id <= rightArray[y].Id)
                {
                    patients[k] = leftArray[x];
                    x++;
                }
                else
                {
                    patients[k] = rightArray[y];
                    y++;
                }
                k++;
            }
            while (x < n1)
            {
                patients[k] = leftArray[x];
                x++;
                k++;
            }
            while (y < n2)
            {
                patients[k] = rightArray[y];
                y++;
                k++;
            }
        }
        /*private void BubbleSort(List<Patient> patients)
        {
            int n = patients.Count;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (patients[j].Id > patients[j + 1].Id)
                    {
                        // Swap patients[j] and patients[j + 1]
                        var temp = patients[j];
                        patients[j] = patients[j + 1];
                        patients[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }*/
        /*private void InsertionSort(List<Patient> patients)
        {
            int n = patients.Count;
            for (int i = 1; i < n; i++)
            {
                Patient key = patients[i];
                int j = i - 1;

                while (j >= 0 && patients[j].Id > key.Id)
                {
                    patients[j + 1] = patients[j];
                    j--;
                }
                patients[j + 1] = key;
            }
        }*/
    }
}