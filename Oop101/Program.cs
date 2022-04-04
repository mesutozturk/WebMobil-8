using Oop101;

var tarih = DateTime.Now;
var rastgeleSayi = new Random().Next(1, 100);

try
{
    var kisi1 = new Kisi
    {
        Ad = "Kamil",
        Soyad = "Fıdıl",
        DogumTarihi = new DateTime(2000,1,1)
    };
    Console.WriteLine($"Yaş: {kisi1.Yas}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}