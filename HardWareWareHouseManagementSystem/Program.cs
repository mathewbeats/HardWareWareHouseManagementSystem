using System.Runtime.CompilerServices;
using WareHouseManagementSystemsApi;



const int BatchSize = 5;

CustomQueue<HardWareItem> hardwareItemQueue = new CustomQueue<HardWareItem>();

hardwareItemQueue.CustomQueueEvent += CustmQueue_CustomQueueEvent;

System.Threading.Thread.Sleep(2000);

//comes into stock - device scans a bar code or QR code
hardwareItemQueue.AddItem(new Drill { Id = 1, name = "Drill 1", Type = "Drill", UnitValue = 20.00m, Quantity = 10 });

System.Threading.Thread.Sleep(1000);

hardwareItemQueue.AddItem(new Drill { Id = 2, name = "Drill 2", Type = "Drill", UnitValue = 30.00m, Quantity = 20 });

System.Threading.Thread.Sleep(2000);

hardwareItemQueue.AddItem(new Ladder { Id = 3, name = "Ladder 1", Type = "Ladder", UnitValue = 100.00m, Quantity = 5 });

System.Threading.Thread.Sleep(1000);

hardwareItemQueue.AddItem(new Hammer { Id = 4, name = "Hammer 1", Type = "Hammer", UnitValue = 10.00m, Quantity = 80 });
System.Threading.Thread.Sleep(3000);

hardwareItemQueue.AddItem(new PaintBrush { Id = 5, name = "Paint Brush 1", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
System.Threading.Thread.Sleep(3000);

hardwareItemQueue.AddItem(new PaintBrush { Id = 6, name = "Paint Brush 2", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
System.Threading.Thread.Sleep(3000);

hardwareItemQueue.AddItem(new PaintBrush { Id = 7, name = "Paint Brush 3", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
System.Threading.Thread.Sleep(3000);

hardwareItemQueue.AddItem(new Hammer { Id = 8, name = "Hammer 2", Type = "Hammer", UnitValue = 11.00m, Quantity = 80 });
System.Threading.Thread.Sleep(3000);

hardwareItemQueue.AddItem(new Hammer { Id = 9, name = "Hammer 3", Type = "Hammer", UnitValue = 13.00m, Quantity = 80 });
System.Threading.Thread.Sleep(3000);

hardwareItemQueue.AddItem(new Hammer { Id = 10, name = "Hammer 4", Type = "Hammer", UnitValue = 14.00m, Quantity = 80 });
System.Threading.Thread.Sleep(3000);

Console.ReadKey();


 static void ProcessItems(CustomQueue<HardWareItem> customQueue)
{
    while(customQueue.QueueLenght > 0)
    {

        Thread.Sleep(3000);
        HardWareItem hardWareItem = customQueue.GetItem();
    }
}

void CustmQueue_CustomQueueEvent(CustomQueue<HardWareItem> sender, QueueEventArgs eventArgs)
{
    Console.Clear();

    Console.WriteLine(MainHeading());
    Console.WriteLine();
    Console.WriteLine(RealTimeUpdateHeading());

    if(sender.QueueLenght > 0)
    {
        Console.WriteLine(eventArgs.Message);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(ItemsInQueueHeading());
        Console.WriteLine(FieldHeadings());


        WriteValuesInQueueToScreen(sender);

        if(sender.QueueLenght == BatchSize)
        {
            ProcessItems(sender);
        }
    }
    else
    {
        Console.WriteLine("all items has been processed");
    }
}

 static void WriteValuesInQueueToScreen(CustomQueue<HardWareItem> hardWareItems)
 {
    foreach(var hardWareItem in hardWareItems)
    {
        Console.WriteLine($"{hardWareItem.Id, -6}{hardWareItem.name, -15}{hardWareItem.Type, -20}{hardWareItem.Quantity,10 }{hardWareItem.UnitValue,10}");    
    }
 }

//Headings
 static string FieldHeadings()
 {
    return UnderLine($"{"Id",-6}{"Name",-15}{"Type",-20}{"Quantity",10}{"Value",10}");
 }

 static string RealTimeUpdateHeading()
 {
    return UnderLine("Real-time Update");
 }

 static string ItemsInQueueHeading()
 {
    return UnderLine("Items Queued for Processing");
 }

 static string MainHeading()
 {
    return UnderLine("Warehouse Management System");
 }

 static string UnderLine(string heading)
 {
    return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
 }
//Headings


public abstract class HardWareItem : IEntityPrimaryPorperties, IEntityAdiccionalPropperties
{
    public int Id { get; set ; }
    public string name { get ; set ; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public decimal UnitValue { get; set; }
}


public interface IDrill
{
    string DrillBrandName { get; set; }
}
public class Drill : HardWareItem, IDrill
{
    public string DrillBrandName { get; set; }  
}

public interface ILadder
{
    string LadderBrandName { get; set; }
}

public class Ladder : HardWareItem, ILadder
{
    public string LadderBrandName {get; set; }
}


public interface IPaintBrush
{
    string PainBrushBrandName { get; set; }  
}

public class PaintBrush : HardWareItem, IPaintBrush
{
    public string PainBrushBrandName { get;set; }
}

public interface IHammer
{
    string HammerBrandName { get; set; }    
}


public class Hammer : HardWareItem, IHammer
{
    public string HammerBrandName { get; set; }
}