using eCommerce.API.Database;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly eCommerceContext _db;
        public UsuarioRepository(eCommerceContext db)
        {
            _db = db;

        }

        

        public List<Usuario> Get()
        {
            return _db.Usuarios.Include(a=>a.Contato).OrderBy(a=>a.Id).ToList();
        }

        public Usuario Get(int id)
        {
            return _db.Usuarios.Include(a=>a.Contato).Include(a=>a.Departamentos).Include(a=>a.EnderecosEntrega).FirstOrDefault(a=>a.Id ==id)!;
        }

        public void Add(Usuario usuario)
        {
            CriandoVinculosUsuarioDepartamento(usuario);

            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
        }

        

        public void Update(Usuario usuario)
        {
            ExcluirVinculoDeprtamentoUsuario(usuario);

            CriandoVinculosUsuarioDepartamento(usuario);

            _db.Usuarios.Update(usuario);
            _db.SaveChanges();
   
        }
        public void Delete(int id)
        {
            _db.Usuarios.Remove(Get(id));
            _db.SaveChanges();
        }


        private void CriandoVinculosUsuarioDepartamento(Usuario usuario)
        {
            /*Verifica se o departamento ja existe no banco ou nao. Caso exista o banco
                         vai retornar o valor do departamento existente e associar ao usuario */
            if (usuario.Departamentos != null)
            {
                var departamentos = usuario.Departamentos;

                usuario.Departamentos = new List<Departamento>();

                foreach (var departamento in departamentos)
                {
                    if (departamento.Id > 0)
                    {
                        //Aqui se refere a uma informacao que foi encontrada direto do banco de dados
                        usuario.Departamentos.Add(_db.Departamentos.Find(departamento.Id)!);
                    }
                    else
                    {
                        /*Pelo falo que nao existe nenhum departamento cadastrado, pode-se entao inserir
                         * um valor do objeto
                         */
                        usuario.Departamentos.Add(departamento);
                    }
                }
            }
        }

        private void ExcluirVinculoDeprtamentoUsuario(Usuario usuario)
        {
            var usuarioDoBanco = _db.Usuarios.Include(a => a.Departamentos).FirstOrDefault(a => a.Id == usuario.Id);

            foreach (var departamento in usuarioDoBanco!.Departamentos!)
            {
                usuarioDoBanco.Departamentos.Remove(departamento);
            }

            _db.SaveChanges();
            _db.ChangeTracker.Clear();
        }

    }
}
