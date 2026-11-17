
namespace Encapsulation.Models;
public class WaterTank
{
    public int Capacity { get; private set; }
    public int Water { get; private set; }
    public WaterTank(int capacity, int water)
    {
        Capacity = capacity;
        Water = water;
    }
    public bool Fill(int amount)
    {
        if (amount > 0 && (Water + amount) <= Capacity)
        {
            Water += amount;
            return true;
        }
        return false;
    }
    public bool Use(int amount)
    {
        if (amount > 0 && amount <= Water)
        {
            Water -= amount;
            return true;
        }
        return false;
    }
    public int GetFreeCapacity() => Capacity - Water;
    public static void RunTest()
    {
        Console.WriteLine("1----");
        WaterTank tank1 = new WaterTank(100, 40);
        Console.WriteLine($"Kutilgan natija: {tank1.Fill(30)}; Suv: {tank1.Water}");
        Console.WriteLine($"Kutilgan natija: {tank1.Use(20)}; Suv: {tank1.Water}");
        Console.WriteLine($"Kutilgan natija: {tank1.Fill(60)}; Suv: {tank1.Water}");
        Console.WriteLine($"Kutilgan natija: {tank1.Use(0)}; Suv: {tank1.Water}");
        Console.WriteLine($"Birinchi idishning bo‘sh sig‘imi: {tank1.GetFreeCapacity()}");

        Console.WriteLine("2----");
        WaterTank tank2 = new WaterTank(50, 10);
        Console.WriteLine($"Ikkinchi idishning bo‘sh sig‘imi: {tank2.GetFreeCapacity()}");

    }

}