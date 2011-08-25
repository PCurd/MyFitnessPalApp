using System;
using MyFitnessLibrary.Graphing;
namespace MyFitnessLibrary.Fitness
{
    public interface IMyFitnessPalWrapper
    {
        void Export(string FileName);
        void Import(string FileName);
        void LoadValues();
        MyFitnessList MyFitnesses { get; }
        IGraphWrapper Graph { get; }
        int Days { get; }
    }
}
