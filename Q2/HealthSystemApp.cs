using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment3.Q2
{
    public class HealthSystemApp
    {
        private readonly Repository<Patient> _patientRepo = new();
        private readonly Repository<Prescription> _prescriptionRepo = new();
        private Dictionary<int, List<Prescription>> _prescriptionMap = new();

        public void SeedData()
        {
            _patientRepo.Add(new Patient(1, "Alice Mensah", 28, "F"));
            _patientRepo.Add(new Patient(2, "Kwame Boateng", 35, "M"));
            _patientRepo.Add(new Patient(3, "Doreen Agyeman", 42, "F"));

            _prescriptionRepo.Add(new Prescription(101, 1, "Amoxicillin", DateTime.Today.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(102, 1, "Ibuprofen", DateTime.Today.AddDays(-2)));
            _prescriptionRepo.Add(new Prescription(103, 2, "Paracetamol", DateTime.Today.AddDays(-7)));
            _prescriptionRepo.Add(new Prescription(104, 3, "Metformin", DateTime.Today.AddDays(-1)));
            _prescriptionRepo.Add(new Prescription(105, 2, "Cetirizine", DateTime.Today));
        }

        public void BuildPrescriptionMap()
        {
            _prescriptionMap = _prescriptionRepo
                .GetAll()
                .GroupBy(p => p.PatientId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public void PrintAllPatients()
        {
            foreach (var p in _patientRepo.GetAll())
                Console.WriteLine(p);
        }

        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            return _prescriptionMap.TryGetValue(patientId, out var list) ? list : new List<Prescription>();
        }

        public void PrintPrescriptionsForPatient(int id)
        {
            var list = GetPrescriptionsByPatientId(id);
            if (list.Count == 0)
                Console.WriteLine($"No prescriptions found for PatientId={id}.");
            else
                foreach (var pr in list) Console.WriteLine(pr);
        }

        public void Run()
        {
            Console.WriteLine("===== QUESTION 2: Healthcare System (Generics + Collections) =====\n");
            SeedData();
            BuildPrescriptionMap();
            Console.WriteLine("All Patients:");
            PrintAllPatients();
            Console.WriteLine();

            int samplePatientId = 2;
            Console.WriteLine($"Prescriptions for PatientId={samplePatientId}:");
            PrintPrescriptionsForPatient(samplePatientId);
            Console.WriteLine();
        }
    }
}
