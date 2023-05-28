

using eCommerce.API.Database;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceContext();


void ExemploComTracking() { 
    //Exemplo de como fica com o tracking. Nao e necessario fazer db.Update()
    var usuarioTracking = db.Usuarios.Find(1);
    usuarioTracking!.Nome = "Juca Nascimento Leite";

    db.SaveChanges();
}


void ExemploSemTracking() { 
    //Removendo o tracking no ato da consulta
    var usuarioNoTracking = db.Usuarios.AsNoTracking().FirstOrDefault(a => a.Id == 1);
    usuarioNoTracking!.Nome = "Juca Nascimento Leite";

    db.Update(usuarioNoTracking);
    db.SaveChanges();

}

/*
 O tracking vem por padrao no EF. Para desabilitalo se utiliza um codigo adicional
no optionsBuilder dentro do Context:

.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)

Dessa forma o tracking fica desabilitado permanentemente no projeto
 
 */