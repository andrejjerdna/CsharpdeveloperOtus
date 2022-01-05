using Prototype.Models;

var originTriangle = new Triangle(new Point(0, 0),
                                  new Point(1, 0),
                                  new Point(0, 1))
{
    Name = "OriginTriangle"
};

var copyTriangle = originTriangle.GetCopy();
var deepCopyTriangle = originTriangle.DeepCopy();
var cloneTriangle = (Triangle)originTriangle.Clone();

WriteResults(originTriangle, copyTriangle, "IMyCloneable copy");
WriteResults(originTriangle, deepCopyTriangle, "IMyCloneable deep copy (JsonSerialize)");
WriteResults(originTriangle, copyTriangle, "ICloneable");


void WriteResults(Triangle originTriangle, Triangle cloneTriangle, string message)
{
    Console.WriteLine(message.ToUpper());
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(originTriangle.ToString());
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(cloneTriangle.ToString());
    Console.ForegroundColor = ConsoleColor.White;

    cloneTriangle.Name = "CloneTriangle";
    var clonePoints = cloneTriangle.GetPoints();

    foreach (var point in clonePoints)
        point.Y = 100;

    Console.WriteLine(string.Empty);
    Console.WriteLine("Modify properties in clone object.".ToUpper());
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(originTriangle.ToString());
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(cloneTriangle.ToString());
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(string.Empty);
    Console.WriteLine(new string('-', 80));
    Console.WriteLine(string.Empty);
}
