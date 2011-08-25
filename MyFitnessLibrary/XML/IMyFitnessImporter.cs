using System;
namespace MyFitnessLibrary.XML
{
    interface IMyFitnessImporter
    {
        MyFitnessLibrary.Fitness.MyFitnessList DeSerialize();
    }
}
