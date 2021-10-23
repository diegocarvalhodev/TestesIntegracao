using System;
using System.Collections.Generic;
using System.Linq;
using Alura.CoisasAFazer.Core.Models;

namespace Alura.CoisasAFazer.Infrastructure
{
    public class RepositorioTarefa : IRepositorioTarefas
    {
        DbTarefasContext _ctx;

        public RepositorioTarefa(DbTarefasContext context)
        {
            this._ctx = context;
        }

        public void AtualizarTarefas(params Tarefa[] tarefas)
        {
            this._ctx.Tarefas.UpdateRange(tarefas);
            this._ctx.SaveChanges();
        }

        public void ExcluirTarefas(params Tarefa[] tarefas)
        {
            this._ctx.Tarefas.RemoveRange(tarefas);
            this._ctx.SaveChanges();
        }

        public void IncluirTarefas(params Tarefa[] tarefas)
        {
            this._ctx.Tarefas.AddRange(tarefas);
            this._ctx.SaveChanges();
        }

        public Categoria ObtemCategoriaPorId(int id)
        {
            return this._ctx.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Tarefa> ObtemTarefas(Func<Tarefa, bool> filtro)
        {
            return this._ctx.Tarefas.Where(filtro);
        }
    }
}
