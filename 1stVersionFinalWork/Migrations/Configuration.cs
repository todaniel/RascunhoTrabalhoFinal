namespace _1stVersionFinalWork.Migrations
{
    using _1stVersionFinalWork.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_1stVersionFinalWork.Models.OrdersDB>
    {
        public Configuration(){
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_1stVersionFinalWork.Models.OrdersDB context){


            var clientes = new List<Clientes> {

        new Clientes  {ClienteID=1, Nome = "Rui Vitória", Contacto ="910000000", Contribuinte= "000000001", Mail= "aluno00001ipt.pt" },
        new Clientes  {ClienteID=2, Nome = "Jorge Derrotado Jesus", Contacto ="910000001", Contribuinte= "000000002", Mail= "aluno00002ipt.pt" },
        new Clientes  {ClienteID=3, Nome = "Nuno Aziado Espirito Santo", Contacto ="910000002", Contribuinte= "000000003", Mail= "aluno00003ipt.pt" },
        new Clientes  {ClienteID=4, Nome = "Pinto da Tosta", Contacto ="910000003", Contribuinte= "000000004", Mail= "aluno00004ipt.pt" },
        new Clientes  {ClienteID=5, Nome = "Quinze Anos a Perder", Contacto ="910000004", Contribuinte= "000000005", Mail= "aluno00005ipt.pt" },
        new Clientes  {ClienteID=6, Nome = "Águia Vitória", Contacto ="910000005", Contribuinte= "000000006", Mail= "aluno00006ipt.pt" },
        new Clientes  {ClienteID=7, Nome = "Leonardo Leão Manso", Contacto ="910000006", Contribuinte= "000000007", Mail= "aluno00007ipt.pt" },
        new Clientes  {ClienteID=8, Nome = "Alberto Fraco Dragão", Contacto ="910000007", Contribuinte= "000000008", Mail= "aluno00008ipt.pt" },
        new Clientes  {ClienteID=9, Nome = "Miquelina Andrioleta", Contacto ="910000008", Contribuinte= "000000009", Mail= "aluno00009ipt.pt" },
        new Clientes  {ClienteID=10, Nome = "Liga Portuguesa", Contacto ="910000009", Contribuinte= "000000010", Mail= "aluno00010@ipt.pt" }
        };

        clientes.ForEach(cc => context.Clientes.AddOrUpdate(c => c.Nome, cc));
        context.SaveChanges(); // commit


            var jornadas = new List<Jornadas> {

        new Jornadas  {JornadaID=1, DataInicio=new DateTime(2017,05,05), DataFinal=new DateTime(2017,05,05), Descricao= "Jornada a começar às 01:15"},
        new Jornadas  {JornadaID=2, DataInicio=new DateTime(2017,05,06), DataFinal=new DateTime(2017,05,06), Descricao= "Jornada a começar às 00:00 e acabar antes das 06:30"},
        new Jornadas  {JornadaID=3, DataInicio=new DateTime(2017,05,07), DataFinal=new DateTime(2017,05,07), Descricao= "Jornada a começar às 01:15"},
        new Jornadas  {JornadaID=4, DataInicio=new DateTime(2017,05,08), DataFinal=new DateTime(2017,05,08), Descricao= "Jornada a começar às 00:30"},
        new Jornadas  {JornadaID=5, DataInicio=new DateTime(2017,05,09), DataFinal=new DateTime(2017,05,10), Descricao= "Jornada a começar às 23:30"},
        new Jornadas  {JornadaID=6, DataInicio=new DateTime(2017,05,10), DataFinal=new DateTime(2017,05,10), Descricao= "Jornada a começar às 03:00"},
        new Jornadas  {JornadaID=7, DataInicio=new DateTime(2017,05,11), DataFinal=new DateTime(2017,05,12), Descricao= "Jornada a começar às 23:00"},
        new Jornadas  {JornadaID=8, DataInicio=new DateTime(2017,05,12), DataFinal=new DateTime(2017,05,12), Descricao= "Jornada a terminar às 06:45"},
        new Jornadas  {JornadaID=9, DataInicio=new DateTime(2017,05,13), DataFinal=new DateTime(2017,05,13), Descricao= "Jornada a começar às 01:15 e acabar às 08:30"},
        new Jornadas  {JornadaID=10, DataInicio=new DateTime(2017,05,14), DataFinal=new DateTime(2017,05,15), Descricao= "Jornada a terminar às 22:00"}
        };

        jornadas.ForEach(jj => context.Jornadas.AddOrUpdate(j => j.JornadaID, jj));
        context.SaveChanges(); // commit


            var encomendas = new List<Encomendas> {

        new Encomendas  {EncomendaID=1, LocalExpedicao = "Tomar", DataExpedicao=new DateTime(2017,03,01), DonoFK=1, JornadaFK=2},
        new Encomendas  {EncomendaID=2, LocalExpedicao = "Entroncamento", DataExpedicao=new DateTime(2017,04,02), DonoFK=3, JornadaFK=2},
        new Encomendas  {EncomendaID=3, LocalExpedicao = "Torres Novas", DataExpedicao=new DateTime(2017,05,03), DonoFK=8, JornadaFK=1},
        new Encomendas  {EncomendaID=4, LocalExpedicao = "Entroncamento", DataExpedicao=new DateTime(2017,05,04), DonoFK=1, JornadaFK=9},
        new Encomendas  {EncomendaID=5, LocalExpedicao = "Ourém", DataExpedicao=new DateTime(2017,05,05), DonoFK=3, JornadaFK=3},
        new Encomendas  {EncomendaID=6, LocalExpedicao = "Entroncamento", DataExpedicao=new DateTime(2017,05,06), DonoFK=5, JornadaFK=4},
        new Encomendas  {EncomendaID=7, LocalExpedicao = "Tomar", DataExpedicao=new DateTime(2017,05,07), DonoFK=9, JornadaFK=6},
        new Encomendas  {EncomendaID=8, LocalExpedicao = "Tomar", DataExpedicao=new DateTime(2017,05,08), DonoFK=7, JornadaFK=7},
        new Encomendas  {EncomendaID=9, LocalExpedicao = "Ourém", DataExpedicao=new DateTime(2017,05,09), DonoFK=4, JornadaFK=5},
        new Encomendas  {EncomendaID=10, LocalExpedicao = "Torres Novas", DataExpedicao=new DateTime(2017,05,10), DonoFK=6, JornadaFK=6}
        };

        encomendas.ForEach(ee => context.Encomendas.AddOrUpdate(e => e.EncomendaID, ee));
        context.SaveChanges(); // commit


            var produtos = new List<Produtos> {

        new Produtos  {ProdutoID=2, Nome= "Broa Amarela" , Tipo= "Pão", Descricao= "Pão de Milho amarelo", Preco=2, IVA=6, Imagem="~Images/1.jpg"},
        new Produtos  {ProdutoID=3, Nome= "Paposseco" , Tipo= "Pão", Descricao= "Pequenos Pãezinhos de trigo", Preco=14, IVA=6, Imagem="~Images/2.jpg"},
        new Produtos  {ProdutoID=4, Nome= "Bola Mistura" , Tipo= "Pão", Descricao= "Bolas Pequenas de Trigo e Centeio", Preco=2, IVA=6, Imagem="~Images/3.jpg"},
        new Produtos  {ProdutoID=5, Nome= "Pão Caseiro Mistura" , Tipo= "Pão", Descricao= "Pão de Trigo tipo Caseiro com Centeio", Preco=2, IVA=6, Imagem="~Images/4.jpg"},
        new Produtos  {ProdutoID=6, Nome= "Cacete Mistura" , Tipo= "Pão", Descricao= "Cacete Trigo e Centeio", Preco=2, IVA=6, Imagem="~Images/5.jpg"},
        new Produtos  {ProdutoID=7, Nome= "Broa Branca" , Tipo= "Pão", Descricao= "Pão de Milho Branco", Preco=2, IVA=6, Imagem="~Images/6.jpg"},
        new Produtos  {ProdutoID=8, Nome= "Pão Centeio" , Tipo= "Pão", Descricao= "Pão de Centeio com Trigo", Preco=2, IVA=6, Imagem="~Images/7.jpg"},
        new Produtos  {ProdutoID=9, Nome= "Pão de Leite" , Tipo= "Bolos", Descricao= "Pão de Leite", Preco=2, IVA=6, Imagem="~Images/8.jpg"},
        new Produtos  {ProdutoID=10, Nome= "Bola Berlim" , Tipo= "Bolos", Descricao= "Bola Berlim sem Creme", Preco=3, IVA=6, Imagem="~Images/99.jpg"}
        };

        produtos.ForEach(pp => context.Produtos.AddOrUpdate(p => p.ProdutoID, pp));
        context.SaveChanges(); // commit


            var itensEncom = new List<ItensEncomenda> {

        new ItensEncomenda  {ID=1, Quantidade= 3 , Preco=8, IVA=6, ProdutoFK=1, EncomendaFK=1},
        new ItensEncomenda  {ID=2, Quantidade= 20 , Preco=14, IVA=6, ProdutoFK=2, EncomendaFK=4},
        new ItensEncomenda  {ID=3, Quantidade= 6 , Preco=9, IVA=6, ProdutoFK=2, EncomendaFK=2},
        new ItensEncomenda  {ID=4, Quantidade= 8 , Preco=11, IVA=6, ProdutoFK=2, EncomendaFK=2},
        new ItensEncomenda  {ID=5, Quantidade= 1 , Preco=1, IVA=6, ProdutoFK=5, EncomendaFK=8},
        new ItensEncomenda  {ID=6, Quantidade= 3 , Preco=2, IVA=6, ProdutoFK=6, EncomendaFK=1},
        new ItensEncomenda  {ID=7, Quantidade= 1 , Preco=1, IVA=6, ProdutoFK=7, EncomendaFK=7},
        new ItensEncomenda  {ID=8, Quantidade= 28 , Preco=18, IVA=6, ProdutoFK=9, EncomendaFK=1},
        new ItensEncomenda  {ID=9, Quantidade= 4 , Preco=16, IVA=6, ProdutoFK=6, EncomendaFK=5},
        new ItensEncomenda  {ID=10, Quantidade= 9 , Preco=9, IVA=6, ProdutoFK=4, EncomendaFK=3}
        };

        itensEncom.ForEach(ii => context.ItensEncomenda.AddOrUpdate(i => i.ID, ii));
        context.SaveChanges(); // commit


            var tiposMsg = new List<TiposMsg> {

        new TiposMsg  {TipoID=1, Descricao= "Sugestão"},
        new TiposMsg  {TipoID=2, Descricao= "Dúvida" },
        new TiposMsg  {TipoID=3, Descricao= "Reclamação"}
        };

            tiposMsg.ForEach(tt => context.TiposMsg.AddOrUpdate(t => t.TipoID, tt));
            context.SaveChanges(); // commit


            var msg = new List<Mensagens> {

        new Mensagens  {MensagemID=1, Texto= "Texto só para testar" , Data=new DateTime(2017,05,14), Respondida=true, DataResposta=new DateTime(2017,05,20), TextoResposta="bla bla Benfica rumo ao tetra", DonoDaMensagemFK=1, TipoFK=1},
        new Mensagens  {MensagemID=2, Texto= "Texto só para testar" , Data=new DateTime(2017,05,15), Respondida=true, DataResposta=new DateTime(2017,05,20), TextoResposta="bla bla Benfica rumo ao tetra", DonoDaMensagemFK=2, TipoFK=1},
        new Mensagens  {MensagemID=3, Texto= "Texto só para testar" , Data=new DateTime(2017,05,16), Respondida=true, DataResposta=new DateTime(2017,05,20), TextoResposta="bla bla Benfica rumo ao tetra", DonoDaMensagemFK=5, TipoFK=1},
        new Mensagens  {MensagemID=4, Texto= "Texto só para testar" , Data=new DateTime(2017,05,17), Respondida=true, DataResposta=new DateTime(2017,05,21), TextoResposta="bla bla Benfica rumo ao tetra", DonoDaMensagemFK=9, TipoFK=2},
        new Mensagens  {MensagemID=5, Texto= "Texto só para testar" , Data=new DateTime(2017,05,18), Respondida=true, DataResposta=new DateTime(2017,05,22), TextoResposta="bla bla Benfica rumo ao tetra", DonoDaMensagemFK=8, TipoFK=3},
        new Mensagens  {MensagemID=6, Texto= "Texto só para testar" , Data=new DateTime(2017,05,19), Respondida=true, DataResposta=new DateTime(2017,05,23), TextoResposta="bla bla Benfica rumo ao tetra", DonoDaMensagemFK=7, TipoFK=2},
        new Mensagens  {MensagemID=7, Texto= "Texto só para testar" , Data=new DateTime(2017,05,20), Respondida=true, DataResposta=new DateTime(2017,05,25), TextoResposta="bla bla Benfica rumo ao tetra", DonoDaMensagemFK=7, TipoFK=3},
        new Mensagens  {MensagemID=8, Texto= "Texto só para testar" , Data=new DateTime(2017,05,21), Respondida=true, DataResposta=new DateTime(2017,05,26), TextoResposta="bla bla Benfica rumo ao tetra", DonoDaMensagemFK=7, TipoFK=2},
        new Mensagens  {MensagemID=9, Texto= "Texto só para testar" , Data=new DateTime(2017,05,22), Respondida=true, DataResposta=new DateTime(2017,05,26), TextoResposta="bla bla Benfica rumo ao tetra", DonoDaMensagemFK=4, TipoFK=1},
        new Mensagens  {MensagemID=10, Texto= "Texto só para testar" , Data=new DateTime(2017,05,25), Respondida=true, DataResposta=new DateTime(2017,05,26), TextoResposta="bla bla Benfica rumo ao tetra", DonoDaMensagemFK=6, TipoFK=3}
        };

        msg.ForEach(mm => context.Mensagens.AddOrUpdate(m => m.MensagemID, mm));
        context.SaveChanges(); // commit


        //********************************************************************************************************

        }
    }
}
