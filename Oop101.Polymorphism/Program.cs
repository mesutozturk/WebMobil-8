using Oop101.Polymorphism.Models;

List<Sekil> sekiller = new();

Sekil kare1 = new Kare()
{
    X = 5
};
Sekil kare2 = new Kare()
{
    X = 3
};

Sekil dikdortgen1 = new DikDortgen()
{
    X = 3,
    Y = 4
};

Sekil dikdortgen2 = new DikDortgen()
{
    X = 5,
    Y = 12
};

sekiller.Add(kare1);
sekiller.Add(kare2);
sekiller.Add(dikdortgen1);
sekiller.Add(dikdortgen2);

