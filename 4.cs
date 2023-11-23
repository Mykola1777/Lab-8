using System;

// Абстрактний клас або інтерфейс для шаблонів даних
public abstract class DataTemplate : ICloneable
{
    public abstract DataTemplate Clone();
}

// Конкретні класи шаблонів даних
public class CSVTemplate : DataTemplate
{
    public override DataTemplate Clone()
    {
        return (CSVTemplate)MemberwiseClone();
    }
}

public class XMLTemplate : DataTemplate
{
    public override DataTemplate Clone()
    {
        return (XMLTemplate)MemberwiseClone();
    }
}

public class JSONTemplate : DataTemplate
{
    public override DataTemplate Clone()
    {
        return (JSONTemplate)MemberwiseClone();
    }
}

// Абстрактний клас або інтерфейс для адаптера даних
public abstract class DataAdapter
{
    public abstract string Convert(object data);
}

// Конкретні класи адаптерів даних
public class CSVAdapter : DataAdapter
{
    public override string Convert(object data)
    {
        // Логіка перетворення в CSV формат
        return $"CSV: {data}";
    }
}

public class XMLAdapter : DataAdapter
{
    public override string Convert(object data)
    {
        // Логіка перетворення в XML формат
        return $"XML: {data}";
    }
}

public class JSONAdapter : DataAdapter
{
    public override string Convert(object data)
    {
        // Логіка перетворення в JSON формат
        return $"JSON: {data}";
    }
}

// Клас програми для імпорту та експорту даних
class Program
{
    static void Main()
    {
        Console.Write("Enter the template type (CSV/XML/JSON): ");
        string templateType = Console.ReadLine().ToUpper();

        DataTemplate template;
        DataAdapter adapter;

        switch (templateType)
        {
            case "CSV":
                template = new CSVTemplate();
                adapter = new CSVAdapter();
                break;
            case "XML":
                template = new XMLTemplate();
                adapter = new XMLAdapter();
                break;
            case "JSON":
                template = new JSONTemplate();
                adapter = new JSONAdapter();
                break;
            default:
                throw new ArgumentException("Invalid template type");
        }

        DataTemplate cloneTemplate = template.Clone();
        Console.Write("Enter the source data: ");
        object sourceData = Console.ReadLine();

        string convertedData = adapter.Convert(sourceData);

        Console.WriteLine($"Original Data: {sourceData}");
        Console.WriteLine($"Converted Data ({templateType}): {convertedData}");
    }
}
