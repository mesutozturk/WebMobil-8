using Oop101;

var tarih = DateTime.Now;
var rastgeleSayi = new Random().Next(1, 100);

try
{
    var kisi1 = new Kisi
    {
        Ad = "123132132",
        Soyad = "Fıdıl"
    };
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    
}
