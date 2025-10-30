using Acapra.Domain.DTOs;
using Acapra.Domain.Entities;
using Acapra.Domain.Interfaces.Repositories;
using Acapra.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acapra.Domain.Interfaces.Dapper;
using System.Threading.Tasks;

namespace Acapra.Infra.Repositories
{
    public class FormularioRespostasRepository : IFormularioRespostasRepository
    {
        private readonly DbSet<FormularioRespostasModel> _dbSet;
        private readonly AcapraDbContext _dbContext;
        private readonly IDapperAcapra _dapperAcapra;

        public FormularioRespostasRepository(AcapraDbContext context, IDapperAcapra dapperAcapra)
        {
            _dbContext = context;
            _dbSet = context.Set<FormularioRespostasModel>();
            _dapperAcapra = dapperAcapra;
        }

        public List<FormularioRespostasModel> ListarRespostas()
        {
            return _dbSet.ToList();
        }

        public bool CadastrarRespostas(int parm_id, List<CadastroRespostas> respostas)
        {
            foreach (var resposta in respostas)
            {
                var formularioResposta = new FormularioRespostasModel()
                {
                    usuarioId = parm_id,
                    formularioPerguntaId = resposta.perguntaId,
                    resposta = resposta.resposta,
                    ultimaAlteracao = DateTime.Now
                };

                _dbSet.Add(formularioResposta);
            }

            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<ConsultaRespostasUsuario> ConsultaRespostas(int id)
        {
            var query = $@"SELECT * FROM acapra.vw_resposta_usuario WHERE id = {id}";

            return _dapperAcapra.RunQuery<ConsultaRespostasUsuario>(query);
        }

    }
}
