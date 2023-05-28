using eCommerce.Office;
using eCommerce.Office.Models;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceOfficeContext();


#region Consulta EF < 5.0
var resultado = db.Setores!.Include(a => a.ColaboradoresSetores).ThenInclude(a => a.Colaborador);

foreach(var setor in resultado)
{
    Console.WriteLine("-"+setor.Nome);
    foreach (var colabSetor in setor.ColaboradoresSetores)
    {
        Console.WriteLine("-"+colabSetor.Colaborador.Nome);
    }
}
#endregion

Console.WriteLine("---------------------------------");

#region Consulta EF > 5.0
var resultado2 = db.Colaboradores!.Include(a => a.Turmas);

foreach (var colaborador in resultado2)
{
    Console.WriteLine("-"+colaborador.Nome);

    foreach(var turma in colaborador.Turmas)
    {
        Console.WriteLine("-"+turma.Nome);
    }

}



#endregion

Console.WriteLine("---------------------------------");

var colabVeicu = db.Colaboradores!.Include(a => a.Veiculos);

foreach(var colab in colabVeicu)
{
    Console.WriteLine("-"+colab.Nome);
    foreach(var veiculo in colab.Veiculos)
    {
        Console.WriteLine("-"+veiculo.Nome);
    }
}

