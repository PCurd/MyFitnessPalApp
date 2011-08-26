using System;
namespace MyFitnessLibrary.Graphing
{

    public interface IGraphWrapper
    {
        IGraphCreator GetCaloriesComparisonGraph(GraphType graphType, MyFitnessLibrary.Fitness.MyFitnessList MyFitnesses, DataSetBuilder dataSetBuilder, int Days);
        IGraphOptions DefaultGraphOptions { get; }
    
    }
}
