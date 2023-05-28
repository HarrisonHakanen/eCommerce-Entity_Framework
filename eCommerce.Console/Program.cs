using eCommerce.Console.Database;


var db = new eCommerceDbContext();

foreach(var usuario in db.Usuarios)
{
    Console.WriteLine(usuario.Nome);
}


Console.WriteLine("Hello, World!");
