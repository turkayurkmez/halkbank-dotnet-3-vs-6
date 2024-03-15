// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.Json;
using WhatsNewInDotnetSix;

Console.WriteLine("Hello, World!");
//dynamic PGO (Profile-Guided Optimization)
//Build süresi, özellikle üçüncü taraf işlemler
//1. Dosya okuma yazma
//2. JSON ile serileştirme
//3. Database bağlantıları

#region JSonSerializer, artık IAsyncEnumerable interface'i ile çalışabiliyor!


async IAsyncEnumerable<int> Show(int maxNumber)
{
    for (int i = 0; i < maxNumber; i++)
    {
        yield return i;
    }
}

using var stream = Console.OpenStandardOutput();
var data = new { Values = Show(8) };
//Dikkat Serialize asenkron metodu sayesinde IAsyncEnumerable özelliği serileştirildi!;
await JsonSerializer.SerializeAsync(stream, data);
Console.WriteLine();
Console.WriteLine("----------------------------------");
Console.WriteLine("Deserialize ediliyor!");
Console.WriteLine();

//StreamReader streamReader = new StreamReader (stream);


var readableStream = new MemoryStream(Encoding.UTF8.GetBytes("[1,2,3,4,5,6,7,8,9,10]"));
await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<int>(readableStream))
{
    Console.Write(item + " - ");
}
Console.WriteLine();

//await foreach (var item in data.Values)
//{
//    Console.WriteLine(item);
//}


#endregion

#region System.LINQ'de neler var neler :)


#region yeni Fonksiyon: TryGetNonEnumeratedCount
var collection = Enumerable.Range(1, 15);
var totalCount = collection.Count(x => x % 3 == 0);
var countInCollect = collection.TryGetNonEnumeratedCount(out int count) ? count : 0;
Console.WriteLine($"Toplam eleman sayısı (TryGetNonEnumeratedCount .net 6.0 ile geldi): {countInCollect}");


#endregion

#region ...By ile biten LINQ fonksiyonları
//en fazla bütçeli şirketi bul:
var customers = new CustomerService().GetCustomers();
var maxBudget = customers.Max(c => c.Budget);
var bigCustomer = customers.FirstOrDefault(c => c.Budget == maxBudget);

//Tek satırda maxBy ile:
var bigCustomer2 = customers.OrderBy(c => c.Id).MaxBy(c => c.Budget);
Console.WriteLine($"En düşük bütçeli şirket: {customers.MinBy(b => b.Budget).Name}, en büyük bütçeli şirket: {bigCustomer2.Name} ");

Console.WriteLine();
Console.WriteLine(" Çalışılan Ülkeler");
var countries = customers.DistinctBy(c => c.Country);
countries.ToList().ForEach(cust => Console.WriteLine(cust.Country));





#endregion

#region Chunk...

var chunks = collection.Chunk(size: 3);
foreach (var item in chunks)
{
    Console.WriteLine($"[{string.Join(",", item)}]");
}
#endregion

Console.WriteLine();
#region Index ve Range objeleri LINQ'de kullanılabiliyor

var lastItem = collection.ElementAt(^1);
Console.WriteLine($"İlk eleman:{collection.ElementAt(0)} son eleman ise {lastItem}");
Console.WriteLine($"İlk üç eleman: {string.Join(",", collection.Take(..3))}");
Console.WriteLine($"6. elemandan son elemana: {string.Join(",", collection.Take(6..))}");
Console.WriteLine($"6. elemandan son elemana: {string.Join(",", collection.Take(^4..))}");



#endregion

var firstOrNegative = collection.FirstOrDefault(x => x > 10, -1);
Console.WriteLine($"First Or Default: {firstOrNegative}");
//var firstOrDefault = customers.FirstOrDefault(c => c.Id == 10, new Customer { Id = 0, Name = "Varsayılan müşteri" });
var singleOrNegative = collection.SingleOrDefault(x => x > 14, -1);
Console.WriteLine($"Single Or Default: {singleOrNegative}");




#endregion


#region Yeni tipler: DateOnly ve TimeOnly
var customer = new Customer() { Id = 4, Country = "Türkiye", Name = "Arçelik" };
customer.RegisterDate = new DateOnly(2024, 1, 1);
Console.WriteLine(customer.RegisterDate.ToLongDateString());
customer.MeanProcessTime = new TimeOnly(3, 45, 20, 98);
Console.WriteLine(customer.MeanProcessTime.ToShortTimeString());

#endregion