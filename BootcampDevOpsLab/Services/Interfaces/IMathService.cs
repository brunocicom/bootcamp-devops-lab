namespace BootcampDevOpsLab.Services.Interfaces
{
    public interface IMathService
    {
        public decimal Add(decimal a, decimal b);

        public decimal Subtract(decimal a, decimal b);

        public decimal Divide(decimal a, decimal b);

        public decimal Multiply(decimal a, decimal b);
    }
}