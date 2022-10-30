// See https://aka.ms/new-console-template for more information
using Protocol;
using Protocol.trash;

List<byte> results = new (5);
KeyValuePair<byte, Object?> Data;
int i = 10;


Console.WriteLine("target\t" + i);
Generater.Generate(i, ref results);

Console.WriteLine("Data Type : " + results[0]);
foreach (byte b in results.GetRange(1,4))
{
	Console.Write(b + " ");
}
Console.WriteLine();

Data = Converter.Convert(results);
if(Data.Value != null)
{
	Console.WriteLine(Data.Key);
	Console.WriteLine(Data.Value);
	Console.WriteLine(Data.Value.GetType());
}

String target = "hello mymate";

List<byte> des = new List<byte>();
Generater.Generate(target,ref des);

Console.WriteLine("byte 상수 출력 : " + DataType.STRING);

Console.Write("byte로 변환한 데이터 : ");
foreach(var t in des)
{
	Console.Write(t + " ");
}
Console.WriteLine();

foreach (var t in des)
{
	Console.Write((char)t + " ");
}
Console.WriteLine();

KeyValuePair<byte, Object?> result = Converter.Convert(des);
Console.WriteLine("string 으로 변환한 데이터 : " + result.Value);


