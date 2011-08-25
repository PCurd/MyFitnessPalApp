using System;
namespace MyFitnessLibrary.XML
{
    public interface IMyFitnessLoader
    {
        void LoadValues(int Days, ref MyFitnessLibrary.Fitness.MyFitnessList myFitnesses);
    }
}
