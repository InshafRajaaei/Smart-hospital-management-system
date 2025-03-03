using System;

namespace HospitalManagementSystem
{
    class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Disease { get; set; }
        public bool IsEmergency { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Age: {Age} | Disease: {Disease} | Emergency: {IsEmergency}";
        }
    }
}