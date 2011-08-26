using System;
namespace MyFitnessLibrary.Graphing
{
    public interface IGraphWrapper
    {
        IGraphCreator GetCaloriesComparisonGraph(GraphType graphType, MyFitnessLibrary.Fitness.MyFitnessList MyFitnesses, int Days);
        IGraphOptions DefaultGraphOptions { get; }
    
    }
}
