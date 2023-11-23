using System;

// Абстрактний клас або інтерфейс для графіка
public abstract class Graph
{
    public abstract void Draw();
}

// Конкретні класи графіків
public class LineGraph : Graph
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Line Graph");
    }
}

public class BarGraph : Graph
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Bar Graph");
    }
}

public class PieChart : Graph
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
    }
}

// Абстрактна фабрика
public abstract class GraphFactory
{
    public abstract Graph CreateGraph();
}

// Конкретні фабрики графіків
public class LineGraphFactory : GraphFactory
{
    public override Graph CreateGraph()
    {
        return new LineGraph();
    }
}

public class BarGraphFactory : GraphFactory
{
    public override Graph CreateGraph()
    {
        return new BarGraph();
    }
}

public class PieChartFactory : GraphFactory
{
    public override Graph CreateGraph()
    {
        return new PieChart();
    }
}

// Клас програми для візуалізації даних
class Program
{
    static void Main()
    {
        Console.Write("Enter the type of graph (Line/Bar/Pie): ");
        string graphType = Console.ReadLine().ToLower();

        GraphFactory factory;
        switch (graphType)
        {
            case "line":
                factory = new LineGraphFactory();
                break;
            case "bar":
                factory = new BarGraphFactory();
                break;
            case "pie":
                factory = new PieChartFactory();
                break;
            default:
                throw new ArgumentException("Invalid graph type");
        }

        Graph graph = factory.CreateGraph();
        graph.Draw();
    }
}
