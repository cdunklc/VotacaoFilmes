using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Infra.Data.Repositories.Queries
{
    public static class VotoQueries
    {
        public static string Apagar = @"Delete From Voto Where VotoId=@VotoId";

        public static string Atualizar = @"Update Voto Set FilmeId=@FilmeId, UsuarioId=@UsuarioId Where VotoId=@VotoId";

        public static string CheckId = @"Select VotoId From Voto Where VotoId=@VotoId";

        public static string Inserir = @"Insert Into Voto(FilmeId, UsuarioId) Values(@FilmeId, @UsuarioId);
                                            Select SCOPE_IDENTITY();";

        public static string Listar = @"Select  V.VotoID,
                                                F.FilmeId as FilmeId, F.Titulo as Titulo, F.Diretor as Diretor,
                                                U.UsuarioId as UsuarioId, U.Nome as Nome, U.Login as Login
                                        From Voto V
                                        Inner Join Filme F On F.FilmeId = V.FilmeId
                                        Inner Join Usuario U on U.UsuarioId = V.UsuarioId
                                        Order by V.VotoID;";

        public static string Obter = @"Select  V.VotoID,
                                                F.FilmeId as FilmeId, F.Titulo as Titulo, F.Diretor as Diretor,
                                                U.UsuarioId as UsuarioId, U.Nome as Nome, U.Login as Login
                                        From Voto V
                                        Inner Join Filme F On F.FilmeId = V.FilmeId
                                        Inner Join Usuario U on U.UsuarioId = V.UsuarioId
                                        Where VotoID = @VotoID";
    }
}
