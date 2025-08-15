using System;

namespace Assignment3.Q4
{
    public class Student
    {
        public int Id;
        public string FullName = string.Empty;
        public int Score;

        public string GetGrade()
        {
            if (Score >= 80 && Score <= 100) return "A";
            if (Score >= 70) return "B";
            if (Score >= 60) return "C";
            if (Score >= 50) return "D";
            return "F";
        }
    }

    public class InvalidScoreFormatException : Exception { public InvalidScoreFormatException(string msg) : base(msg) { } }
    public class MissingFieldException : Exception { public MissingFieldException(string msg) : base(msg) { } }
}
