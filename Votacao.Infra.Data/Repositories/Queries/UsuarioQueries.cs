using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Infra.Data.Repositories.Queries
{
    public static class UsuarioQueries
    {
        public static string Apagar = @"Delete From Usuario Where UsuarioId=@UsuarioId";

        public static string Atualizar = @"Update Usuario Set Nome=@Nome, Login=@Login, Senha=@Senha Where UsuarioId=@UsuarioId";

        public static string CheckId = @"Select UsuarioId From Usuario Where UsuarioId=@UsuarioId";

        public static string Inserir = @"Insert Into Usuario(Nome, Login, Senha) Values(@Nome, @Login, @Senha);
                                            Select SCOPE_IDENTITY();";

        public static string Listar = @"Select 
                                            UsuarioId as UsuarioId,
                                            Nome as Nome,
                                            Login as Login
                                        From Usuario
                                        Order by Nome";

        public static string Obter = @"Select 
                                            UsuarioId as UsuarioId,
                                            Nome as Nome,
                                            Login as Login  
                                        From Usuario
                                        Where UsuarioId=@UsuarioId";
    }
}
