using System;
using System.Collections.Generic;

public sealed class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private Dictionary<string, string> configurations;

    private ConfigurationManager()
    {
        configurations = new Dictionary<string, string>();
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConfigurationManager();
            }
            return _instance;
        }
    }

    public void SetConfiguration(string key, string value)
    {
        configurations[key] = value;
    }

    public string GetConfiguration(string key)
    {
        return configurations.TryGetValue(key, out var value) ? value : null;
    }

    public void DisplayConfigurations()
    {
        foreach (var kvp in configurations)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager1 = ConfigurationManager.Instance;
        configManager1.SetConfiguration("LogLevel", "DEBUG");

        ConfigurationManager configManager2 = ConfigurationManager.Instance;
        configManager2.SetConfiguration("DBConnection", "localhost:3306");

        configManager1.DisplayConfigurations();
        configManager2.DisplayConfigurations();
    }
}
