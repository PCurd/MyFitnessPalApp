using System;
namespace MyFitnessLibrary.Fitness
{
    public interface IMyFitnessPalConfig
    {
        int Days { get; set; }
        IMyFitnessPalWrapper MyFitnessPal { get; }
    }
}
