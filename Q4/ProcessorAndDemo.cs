using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment3.Q4
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var result = new List<Student>();
            using var sr = new StreamReader(inputFilePath);
            string? line;
            int lineNo = 0;
            while ((line = sr.ReadLine()) != null)
            {
                lineNo++;
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(',');
                if (parts.Length != 3)
                    throw new MissingFieldException($"Line {lineNo}: Expected 3 fields but got {parts.Length}.");

                if (!int.TryParse(parts[0].Trim(), out int id))
                    throw new FormatException($"Line {lineNo}: ID is not a valid integer.");

                string fullName = parts[1].Trim();

                if (!int.TryParse(parts[2].Trim(), out int score))
                    throw new InvalidScoreFormatException($"Line {lineNo}: Score is not a valid integer.");

                result.Add(new Student { Id = id, FullName = fullName, Score = score });
            }
            return result;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using var sw = new StreamWriter(outputFilePath);
            foreach (var s in students)
            {
                sw.WriteLine($"{s.FullName} (ID: {s.Id}): Score = {s.Score}, Grade = {s.GetGrade()}");
            }
        }
    }

    public class GradingDemo
    {
        public void Run()
        {
            Console.WriteLine("===== QUESTION 4: Grading System (Files + Exceptions) =====\n");
            string input = Path.Combine(Environment.CurrentDirectory, "grades_input.txt");
            string output = Path.Combine(Environment.CurrentDirectory, "grades_report.txt");

            File.WriteAllLines(input, new[]
            {
                "101, Alice Smith, 84",
                "102, Bob Jones, 73",
                "103, Clara Doe, 58",
                "104, David Ray, 45"
            });

            try
            {
                var proc = new StudentResultProcessor();
                var students = proc.ReadStudentsFromFile(input);
                proc.WriteReportToFile(students, output);
                Console.WriteLine($"Report written to: {output}");
            }
            catch (FileNotFoundException ex) { Console.WriteLine($"File error: {ex.Message}"); }
            catch (InvalidScoreFormatException ex) { Console.WriteLine($"Score error: {ex.Message}"); }
            catch (MissingFieldException ex) { Console.WriteLine($"Field error: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"Unexpected error: {ex.Message}"); }

            Console.WriteLine();
        }
    }
}
