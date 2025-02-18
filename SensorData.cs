using System;

public static class SensorData
{
    private static Random random = new Random();

    public static double GetTemperature()
    {
        return Math.Round(20 + random.NextDouble() * 10, 2);
    }

    public static int GetHumidity()
    {
        return random.Next(40, 70);
    }

    public static string GetStatus()
    {
        string[] statuses = { "Active", "Idle", "Maintenance", "Error" };
        return statuses[random.Next(statuses.Length)];
    }
}
