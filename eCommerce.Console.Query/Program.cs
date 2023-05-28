
using eCommerce.API.Database;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceContext();
var usuarios = db.Usuarios!.ToList();


Console.WriteLine("LISTA DE USUARIOS");
foreach (var usuario in usuarios)
{
    Console.WriteLine($"-{usuario.Nome}");
}


Console.WriteLine("Buscar 1 usuario");

//Com where. FirstOrDefault para nao causar exception
//var user = db.Usuarios!.Where(a=>a.Email=="teste@teste.com").FirstOrDefault();

//Com where. OrderBy pelo fato que o LastOrDefault exige que a lista deva ser ordenada.
//var user = db.Usuarios!.OrderBy(a => a.Id).Where(a => a.Email == "teste@teste.com").LastOrDefault();

//Sem o where. Pode ser uma abordagem mais limpa de pesquisa
//var user = db.Usuarios!.FirstOrDefault(a => a.Email == "teste@teste.com");

//O Single tem como objetivo pegar apenas um registro. Geralmente usado em campos unique como CPF ou email
var user = db.Usuarios!.SingleOrDefault(a => a.Email == "teste@teste.com");


if (user == null)
    Console.WriteLine("Usuario nao encontrado");
else
    Console.WriteLine($"COD: {user.Id} Nome:{user.Nome}");

var count = db.Usuarios!.Where(a => a.Nome.Contains("a")).Count();

Console.WriteLine($"Numero de usuarios que contem a letra a {count}");

var max = db.Usuarios!.Max(a => a.Id);

Console.WriteLine($"Valor maximo do Id {max}");

//Consulta com where e condicao
var condicao = db.Usuarios!.Where(a => a.Nome.Contains("a") && a.Nome.Contains("c")).ToList();

//Funcoes do banco diretamente do EF
var usuarioList = db.Usuarios!.Where(a=>EF.Functions.Like(a.Nome,"%e")).ToList();



Console.WriteLine("LISTA DE USUARIOS ORDER");

//Um orderby normal
var usuariosOrder = db.Usuarios!.OrderBy(a=>a.Nome).ToList();

//Com o thenby e possivel fazer um orderby de n niveis de consulta diferente
var usuariosThenby = db.Usuarios!.OrderBy(a => a.Nome).ThenBy(a=>a.Sexo).ToList();

foreach (var usuario in usuariosOrder)
{
    Console.WriteLine($"-{usuario.Nome}");
}