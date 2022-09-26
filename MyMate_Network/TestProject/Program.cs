// See https://aka.ms/new-console-template for more information
using Protocal;

List<byte> results = new (5);
KeyValuePair<byte, Object?> Data;
int i = 10;


Console.WriteLine("target\t" + i);
DataGenerater.Generate(ref i, ref results);

Console.WriteLine("Data Type : " + results[0]);
foreach (byte b in results.GetRange(1,4))
{
	Console.Write(b + " ");
}
Console.WriteLine();

Data = DataConvertor.Convert(ref results);
if(Data.Value != null)
{
	Console.WriteLine(Data.Key);
	Console.WriteLine(Data.Value);
	Console.WriteLine(Data.Value.GetType());

}
