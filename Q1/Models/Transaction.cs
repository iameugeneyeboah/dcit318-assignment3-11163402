using System;

namespace Assignment3.Q1
{
    // Core model using record
    public readonly record struct Transaction(int Id, DateTime Date, decimal Amount, string Category);
}
