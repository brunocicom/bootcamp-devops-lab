using System;
using BootcampDevOpsLab.Services.Interfaces;

namespace BootcampDevOpsLab.Services
{
    public class MathService : IMathService
    {
        public decimal Add(decimal a, decimal b) => a + b;

        public decimal Subtract(decimal a, decimal b) => a - b;

        public decimal Divide(decimal a, decimal b) => (b == 0) ? throw new DivideByZeroException() : a / b;

        public decimal Multiply(decimal a, decimal b) => a * b;
    }
}