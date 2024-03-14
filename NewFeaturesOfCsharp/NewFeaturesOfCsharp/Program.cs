
#region Top-Level statement ve global usings


using NewFeaturesOfCsharp;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

void doIt()
{
    Console.WriteLine("Metot çalıştı");
}




Console.WriteLine("Hello, World!");
doIt();
ProductService service = new ProductService();
DataTable table = new DataTable();

#endregion

#region Anonim tip ve lambda iyileştirmeleri

//C# 10 öncesi:
Func<int, bool> isEven = (int number) => number % 2 == 0;
var anonym = new { Name = "Türkay", Age = 44 };

//C# 10
var isOdd = (int number) => number % 2 == 1;
LambdaExpression isMultiplyForThree = (int number) => number % 3 == 0;

var x = 0.0;
int x1 = 5;
var service2 = new ProductService();

Func<int> read = Console.Read;
var read2 = Console.Read; //Bu çalışır

Action<string> write = Console.Write;
//var write2 = Console.Write; Çalışmaz çünkü hangi Console.Write overload'ı olduğunu anlamaz

var output = object (bool isSuccess) => isSuccess ? 0 : "İşlem başarısız";
#endregion

#region Struct üzerindeki değişiklikler
ProductRecord record1 = new ProductRecord(1, "X", 10);
ProductRecord record2 = new ProductRecord(1, "X", 10);


Console.WriteLine($"record1 == record2 karşılaştırma sonucu: {record1 == record2}");
Console.WriteLine($"record1.Equals(record2) karşılaştırma sonucu: {record1.Equals(record2)}");
Console.WriteLine($"record1.GetHashCode() == record2.GetHashCode() karşılaştırma sonucu: {record1.GetHashCode() == record2.GetHashCode()}");

Console.WriteLine("------------ sınıf karşılaştırması ------------------");
var obj1 = new ProductClass() { Id = 1, Name = "X", Price = 1 };
var obj2 = new ProductClass() { Id = 1, Name = "X", Price = 1 };

Console.WriteLine($"obj1 == obj2 karşılaştırma sonucu: {obj1 == obj2}");
Console.WriteLine($"obj1.Equals(obj2) karşılaştırma sonucu: {obj1.Equals(obj2)}");
Console.WriteLine($"obj1.GetHashCode() == obj2.GetHashCode() karşılaştırma sonucu: {obj1.GetHashCode() == obj2.GetHashCode()}");

Point point = new Point();

List<Customer> customers = new()
{
    new(){ Name = "Türkay", Address = new Address("Sümer mah","Eskişehir","26140","Türkiye")},
    new(){ Name = "Derya", Address = new Address("Osmanağa mah","İstanbul","34802","Türkiye")},

};

var searchingAddress = new Address("Sümer mah", "Eskişehir", "26140", "Türkiye");
var customer = customers.FirstOrDefault(c => c.Address == searchingAddress);
Console.WriteLine($"Adresin sahibi {customer?.Name}");

#endregion

#region Tuples, mix decleration, deconstructions
Tuple<int, int> divide(int number1, int number2)
{
    Tuple<int, int> result = Tuple.Create(number1 / number2, number1 % number2);
    return result;

    //return number1 / number2; 
}

(int, int) groupingDivide(int number1, int number2)
{

    return (number1 / number2, number1 % number2);

    //return number1 / number2; 
}

var divideResult = divide(14, 3);

(int bolumSonucu, int kalan) = (divideResult.Item1, divideResult.Item2);

int p, q;
(p, q) = (5, 10);
(string a, string b) = ("Türkay", "Ürkmez");
(p, bool isOk) = (90, false);

(int sonuc, int mod) = groupingDivide(14, 3);

Console.WriteLine($"Sonuç: {sonuc} Kalan:{mod}");
#endregion

#region Property Pattern artık daha güçlü!

foreach (object customer1 in customers)
{

    //Customer client = (Customer)customer1;

    //if (client.Address.City == "İstanbul")
    //{
    //    Console.WriteLine(client.Name);
    //}

    if (customer1 is Customer { Address.City: "İstanbul" })
    {
        Console.WriteLine(((Customer)customer1).Name);
    }
}

#endregion

#region Caller Argument Expression attribute'u geldi!

void CheckCondition(bool condition, [CallerArgumentExpression(nameof(condition))] string? logMessage = null)
{
    Console.WriteLine($"Parametreye gönderilen koşul: {logMessage}. Sonuç ise {condition}");
}
(int a1, int b1) = (5, 3);
CheckCondition(a1 > b1);
string test = "test";
CheckCondition(test.Length < 2);

#endregion

#region Exception Guards
void SaveCustomer(Customer customer)
{
    //if (customer is null)
    //{
    //    throw new ArgumentNullException();
    //}
    ArgumentNullException.ThrowIfNull(customer);
}

#endregion
