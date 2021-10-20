using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Infra.Data.Repositories.Queries
{
    public static class FilmeQueries
    {
        public static string Apagar = @"Delete From Filme Where FilmeId=@FilmeId";

        public static string Atualizar = @"Update Filme Set Titulo=@Titulo, Diretor=@Diretor Where FilmeId=@FilmeId";

        public static string CheckId = @"Select FilmeId From Filme Where FilmeId=@FilmeId";

        public static string Inserir = @"Insert Into Filme(Titulo, Diretor) Values(@Titulo, @Diretor);
                                            Select SCOPE_IDENTITY();";

        public static string Listar = @"Select 
                                            FilmeId as FilmeId,
                                            Titulo as Titulo,
                                            Diretor as Diretor   
                                        From Filme
                                        Order by Titulo";

        public static string Obter = @"Select 
                                            FilmeId as FilmeId,
                                            Titulo as Titulo,
                                            Diretor as Diretor   
                                        From Filme
                                        Where FilmeId=@FilmeId";
    }
}
