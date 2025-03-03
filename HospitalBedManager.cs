using System;

namespace HospitalManagementSystem
{
    class HospitalBedManager
    {
        public LinkedList<int> allocatedBeds = new LinkedList<int>();

        public HospitalBedManager(int totalBeds)
        {
            for (int i = 1; i <= totalBeds; i++)
            {
                allocatedBeds.AddEnd(i);
            }
        }
        public void AllocateBed()
        {
            Console.WriteLine("\nAllocate a Bed");
            int bedId = Utility.GetIntInput("Enter Bed ID: ");

            if (allocatedBeds.Contains(bedId))
            {
                Console.WriteLine("Bed is already allocated!");
                return;
            }

            allocatedBeds.AddEnd(bedId);
            Console.WriteLine($"Bed {bedId} allocated successfully!");
        }
        public void FreeBed(int bedId)
        {
            if (allocatedBeds.Contains(bedId))
            {
                allocatedBeds.Remove(bedId);
                Console.WriteLine($"Bed {bedId} freed successfully!");
            }
            else
            {
                Console.WriteLine("Bed is not allocated!");
            }
        }
    }
}