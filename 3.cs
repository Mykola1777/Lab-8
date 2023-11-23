using System;

// Абстрактні класи або інтерфейси компонентів продукту
public abstract class Screen
{
    public abstract void Display();
}

public abstract class Processor
{
    public abstract void Process();
}

public abstract class Camera
{
    public abstract void Capture();
}

// Абстрактна фабрика для технологічного продукту
public abstract class TechProductFactory
{
    public abstract Screen CreateScreen();
    public abstract Processor CreateProcessor();
    public abstract Camera CreateCamera();
}

// Конкретні компоненти продукту
public class OLEDScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("OLED Screen displays vibrant colors");
    }
}

public class SnapdragonProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Snapdragon Processor handles tasks efficiently");
    }
}

public class DualCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Dual Camera captures high-quality photos");
    }
}

// Конкретна фабрика для смартфона
public class SmartphoneFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new OLEDScreen();
    }

    public override Processor CreateProcessor()
    {
        return new SnapdragonProcessor();
    }

    public override Camera CreateCamera()
    {
        return new DualCamera();
    }
}

// Клас програми для створення технологічного продукту
class Program
{
    static void Main()
    {
        Console.Write("Enter the type of tech product (Smartphone): ");
        string productType = Console.ReadLine().ToLower();

        TechProductFactory techFactory;
        switch (productType)
        {
            case "smartphone":
                techFactory = new SmartphoneFactory();
                break;
            default:
                throw new ArgumentException("Invalid tech product type");
        }

        Screen screen = techFactory.CreateScreen();
        Processor processor = techFactory.CreateProcessor();
        Camera camera = techFactory.CreateCamera();

        Console.WriteLine("Tech Product Assembly:");
        screen.Display();
        processor.Process();
        camera.Capture();
    }
}
