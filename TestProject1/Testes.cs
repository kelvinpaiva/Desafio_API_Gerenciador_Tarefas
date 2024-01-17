using NUnit.Framework;
using APIGerenciador_Tarefas;
using APIGerenciador_Tarefas.Models;
using APIGerenciador_Tarefas.Development;
using System.Collections.Generic;
using APIGerenciador_Tarefas.Models.DAO;
using System;
using System.Linq;

namespace TestProject1
{
    public class Tests
    {
        Tarefa_Develop Tarefa = new Tarefa_Develop();
        Projeto_Develop Projeto = new Projeto_Develop();
        Lancamento_Comentario_Develop Comentario = new Lancamento_Comentario_Develop();
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Lista_Tarefa()
        {

            if (Tarefa.Listar_Tarefas() is List<TarTarefa>)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void Test_Cadastra_Tarefa()
        {
            bool passou = false;
            TarTarefa_DAO tarefaTeste = new TarTarefa_DAO();
            tarefaTeste.TarStatus = 1;
            tarefaTeste.TarPrioridade = 1;
            tarefaTeste.IdPro = 2;
            tarefaTeste.IdUsuario = 1;
            tarefaTeste.TarDescricao = "Teste de Tarefa";
            tarefaTeste.TarTitulo = "Teste de Tarefa";
            tarefaTeste.TarDataValidade = DateOnly.FromDateTime(DateTime.Now);
            Tarefa.Cadastro_Tarefa(tarefaTeste);

            List<TarTarefa> lista = Tarefa.Listar_Tarefas();

            foreach(TarTarefa linha in lista)
            {
                if (linha.TarDescricao.Equals("Teste de Tarefa")) passou = true;
            }
            if (passou.Equals(true))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void Test_Edita_Tarefa()
        {
            List<TarTarefa> lista = Tarefa.Listar_Tarefas();
            TarTarefa tarefa_Editar = lista[0];
            TarTarefa_DAO tarefa_DAO = new TarTarefa_DAO();
            bool passou = false;
            tarefa_DAO.Id = tarefa_Editar.Id;
            tarefa_DAO.IdPro = tarefa_Editar.IdPro;
            tarefa_DAO.IdUsuario = 1;
            tarefa_DAO.TarStatus = tarefa_Editar.TarStatus;
            tarefa_DAO.TarPrioridade = tarefa_Editar.TarPrioridade;
            tarefa_DAO.TarDescricao = "Teste de Tarefa Editada";
            tarefa_DAO.TarTitulo = "Teste de Tarefa Editada";
            tarefa_DAO.TarDataValidade = DateOnly.FromDateTime(DateTime.Now);
            Tarefa.Editar_Tarefa(tarefa_DAO);
            lista.Clear();
            lista = Tarefa.Listar_Tarefas();

            foreach (TarTarefa linha in lista)
            {
                if (linha.TarDescricao.Equals("Teste de Tarefa Editada")) passou = true;
            }
            if (passou.Equals(true))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void Test_Exclui_Tarefa()
        {
            List<TarTarefa> lista = Tarefa.Listar_Tarefas();
            TarTarefa tarefa_Excluir = lista[0];
            TarTarefa_DAO tarefa_DAO = new TarTarefa_DAO();
            tarefa_DAO.Id = tarefa_Excluir.Id;
            bool passou = true;
            Tarefa.Excluir_Tarefa(tarefa_DAO.Id, 1);
            lista.Clear();
            lista = Tarefa.Listar_Tarefas();

            foreach (TarTarefa linha in lista)
            {
                if (linha.Id.Equals(1)) passou = false;
            }
            if (passou.Equals(true))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void Test_Lista_Projeto()
        {
            if (Projeto.Listar_Projetos() is List<ProProjeto>)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void Test_Cadastra_Projeto()
        {
            bool passou = false;
            ProProjeto_DAO ProjetoTeste = new ProProjeto_DAO();
            ProjetoTeste.IdUsuario = 1;
            ProjetoTeste.ProTitulo = "Teste de Projeto";
            Projeto.Cadastro_Projeto(ProjetoTeste);

            List<ProProjeto> lista = Projeto.Listar_Projetos();

            foreach (ProProjeto linha in lista)
            {
                if (linha.ProTitulo.Equals("Teste de Projeto")) passou = true;
            }
            if (passou.Equals(true))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void Test_Edita_Projeto()
        {
            List<ProProjeto> lista = Projeto.Listar_Projetos();
            ProProjeto pro = lista[0];
            bool passou = false;
            ProProjeto_DAO ProjetoTeste = new ProProjeto_DAO();
            ProjetoTeste.Id = pro.Id;
            ProjetoTeste.ProTitulo = "Teste de Projeto Editado";
            Projeto.Editar_Projeto(ProjetoTeste);
            lista.Clear();
            lista = Projeto.Listar_Projetos();

            foreach (ProProjeto linha in lista)
            {
                if (linha.ProTitulo.Equals("Teste de Projeto Editado")) passou = true;
            }
            if (passou.Equals(true))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void Test_Exclui_Projeto()
        {
            List<ProProjeto> lista = Projeto.Listar_Projetos();
            ProProjeto pro = lista.Last();
            Projeto.Excluir_Projeto(1, pro.Id);
            bool passou = true;
            lista.Clear();
            lista = Projeto.Listar_Projetos();

            foreach (ProProjeto linha in lista)
            {
                if (linha.Id.Equals(pro.Id)) passou = false;
            }

            if (passou.Equals(true))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void Test_Adiciona_Comentario()
        {
            List<ProProjeto> listaProjeto = Projeto.Listar_Projetos();
            if(listaProjeto.Count.Equals(0))
            {
                ProProjeto_DAO projeto_DAO = new ProProjeto_DAO();
                projeto_DAO.IdUsuario = 1;
                projeto_DAO.ProTitulo = "Teste de Cadastro de comentário";
                Projeto.Cadastro_Projeto(projeto_DAO);
            }
            ProProjeto pro = listaProjeto[0];

            List<TarTarefa> listaTarefa = Tarefa.Listar_Tarefas();
            if (listaProjeto.Count.Equals(0))
            {
                ProProjeto_DAO projeto_DAO = new ProProjeto_DAO();
                TarTarefa_DAO tarefaTeste = new TarTarefa_DAO();
                tarefaTeste.TarStatus = 1;
                tarefaTeste.TarPrioridade = 1;
                tarefaTeste.IdPro = pro.Id;
                tarefaTeste.IdUsuario = 1;
                tarefaTeste.TarDescricao = "Teste de Cadastro de comentário";
                tarefaTeste.TarTitulo = "Teste de Cadastro de comentário";
                tarefaTeste.TarDataValidade = DateOnly.FromDateTime(DateTime.Now);
                Projeto.Cadastro_Projeto(projeto_DAO);
            }
            TarTarefa tar = listaTarefa[0];

            Comentario_DAO Coment = new Comentario_DAO();
            Coment.IdTar = tar.Id;
            Coment.IdUsuario = 1;
            Coment.LctComentario="Comentário de teste de comentário";

            var retorno = Comentario.Cadastra_Comentario_Tarefa(Coment);


            if (retorno.Equals(1))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}