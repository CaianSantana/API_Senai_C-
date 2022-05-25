using chapter.Models;

namespace chapter.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarId(int id);

        void Cadastrar(Usuario usuario);

        void Alterar(int id, Usuario usuario);

        void Deletar(int id);

        Usuario Login(string email, string senha);
    }
}
