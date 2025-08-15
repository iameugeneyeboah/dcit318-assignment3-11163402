using System;

namespace Assignment3.Q2
{
    public class Patient
    {
        public int Id;
        public string Name = string.Empty;
        public int Age;
        public string Gender = string.Empty;

        public Patient(int id, string name, int age, string gender)
        {
            Id = id; Name = name; Age = age; Gender = gender;
        }
        public override string ToString() => $"Patient {{ Id={Id}, Name={Name}, Age={Age}, Gender={Gender} }}";
    }

    public class Prescription
    {
        public int Id;
        public int PatientId;
        public string MedicationName = string.Empty;
        public DateTime DateIssued;

        public Prescription(int id, int patientId, string medicationName, DateTime dateIssued)
        {
            Id = id; PatientId = patientId; MedicationName = medicationName; DateIssued = dateIssued;
        }
        public override string ToString() => $"Prescription {{ Id={Id}, PatientId={PatientId}, Medication={MedicationName}, DateIssued={DateIssued:yyyy-MM-dd} }}";
    }
}
