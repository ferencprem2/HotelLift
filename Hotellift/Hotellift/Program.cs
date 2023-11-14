using System;

namespace Hotellift;

class Program
{
    static List<Lift> liftInfos = new();
    static void Main(string[] args)
    {
        LoadFile();
        Console.WriteLine($"3.feladat: Összes lifthasználat: {liftInfos.Count()}");
        Console.WriteLine($"4.feladat: Időszak: {liftInfos.Select(x => x.UseTime).FirstOrDefault()} - {liftInfos.Select(x => x.UseTime).LastOrDefault()} ");
        Console.WriteLine($"5.feladat: Célszint max: {liftInfos.Max(x => x.DestinationFloor)}");
        Console.WriteLine($"6.feladat:");
        Console.WriteLine("\t Kártya száma:");
        string cardNumberInput = Console.ReadLine();
        Console.WriteLine("\t Célszint száma:");
        string destinationFloorInput = Console.ReadLine();
        int cardNumber, destinationFloor;
        try
        {
            cardNumber = int.Parse(cardNumberInput);
            destinationFloor = int.Parse(destinationFloorInput);
        }
        catch (Exception ex)
        {
            cardNumber = 5;
            destinationFloor = 5;

        }
        wasTravelled(cardNumber, destinationFloor);
        

      
        Console.WriteLine($"8.feladat:");
        foreach (var item in liftInfos.GroupBy(x => x.UseTime).Select(y => new { Day = y.Key, uses = y.Count() }))
        {
            Console.WriteLine($"{item.Day}- {item.uses}x");
        }
        

    }

    public static void wasTravelled(int cardNumber, int destinationFloor)
    {
        bool travelled = liftInfos.Any(x => x.CardNumber == cardNumber && x.DestinationFloor == destinationFloor);
        if (travelled)
        {
            Console.WriteLine($"7.feladat: A(z) {cardNumber}. kártyával utaztak a(z) {destinationFloor}. emeletre");
        } else
        {
            Console.WriteLine($"7.feladat: A(z) {cardNumber}. kártyával nem utaztak a(z) {destinationFloor}. emeletre");
        }

    }



    static void LoadFile()
    {
        StreamReader sr = new("lift.txt");
     
        while (!sr.EndOfStream)
        {
            string[] line = sr.ReadLine().Split(' ');
            Lift newData = new Lift(DateOnly.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]));
            liftInfos.Add(newData);
        }
        sr.Close();
    }
}

