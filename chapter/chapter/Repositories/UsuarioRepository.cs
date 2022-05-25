using chapter.Contexts;
using chapter.Interfaces;
using chapter.Models;

namespace chapter.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ChapterContext _context;

        public UsuarioRepository(ChapterContext context)
        {
            _context = context;
        }
        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }
        public Usuario BuscarId(int id)
        {
            return _context.Usuarios.Find(id);
        }
        public void Alterar(int id, Usuario usuario)
        {

            Usuario usuarioEncontrado = _context.Usuarios.Find(id);
            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Senha = usuario.Senha;
                usuarioEncontrado.Tipo = usuario.Tipo;
            }
            _context.Usuarios.Update(usuarioEncontrado);
            _context.SaveChanges();
        }

      

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(usuario);

            _context.SaveChanges();
        }

        

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }
    }
}
