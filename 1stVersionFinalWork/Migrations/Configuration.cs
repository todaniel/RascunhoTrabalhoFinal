namespace FinalWork.Migrations
{
    using FinalWork.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalWork.Models.OrdersDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex); // Add the original exception as the innerException
            }
        }


        protected override void Seed(FinalWork.Models.OrdersDB context)
        {


            var clientes = new List<Clientes> {

        new Clientes  {ClienteID=1, Nome = "Rui Vitória", Contacto ="910000000", Contribuinte= "000000001", Mail= "aluno00001@ipt.pt", NomeLogin="tester1" },
        new Clientes  {ClienteID=2, Nome = "Jorge Derrotado Jesus", Contacto ="910000001", Contribuinte= "000000002", Mail= "aluno00002@ipt.pt", NomeLogin="tester2" },
        new Clientes  {ClienteID=3, Nome = "Nuno Aziado Espirito Santo", Contacto ="910000002", Contribuinte= "000000003", Mail= "aluno00003@ipt.pt", NomeLogin="tester3" },
        new Clientes  {ClienteID=4, Nome = "Pinto Da Tosta", Contacto ="910000003", Contribuinte= "000000004", Mail= "aluno00004@ipt.pt", NomeLogin="tester4" },
        new Clientes  {ClienteID=5, Nome = "Quinze Anos Perdendo", Contacto ="910000004", Contribuinte= "000000005", Mail= "aluno00005@ipt.pt", NomeLogin="tester5" },
        new Clientes  {ClienteID=6, Nome = "Águia Vitória", Contacto ="910000005", Contribuinte= "000000006", Mail= "aluno00006@ipt.pt", NomeLogin="tester6" },
        new Clientes  {ClienteID=7, Nome = "Leonardo Leão Manso", Contacto ="910000006", Contribuinte= "000000007", Mail= "aluno00007@ipt.pt", NomeLogin="tester7" },
        new Clientes  {ClienteID=8, Nome = "Alberto Fraco Dragão", Contacto ="910000007", Contribuinte= "000000008", Mail= "aluno00008@ipt.pt", NomeLogin="tester8" },
        new Clientes  {ClienteID=9, Nome = "Miquelina Andrioleta", Contacto ="910000008", Contribuinte= "000000009", Mail= "aluno00009@ipt.pt", NomeLogin="tester9" },
        new Clientes  {ClienteID=10, Nome = "Liga Portuguesa", Contacto ="910000009", Contribuinte= "000000010", Mail= "aluno00010@ipt.pt", NomeLogin="tester10" }
        };

            clientes.ForEach(cc => context.Clientes.AddOrUpdate(c => c.Nome, cc));
            //context.SaveChanges(); // commit
            SaveChanges(context);


            var jornadas = new List<Jornadas> {

        new Jornadas  {JornadaID=1, DataInicio=new DateTime(2017,05,05), DataFinal=new DateTime(2017,05,05), Descricao= "Jrd_20170505 - Inicio às 01:15h"},
        new Jornadas  {JornadaID=2, DataInicio=new DateTime(2017,05,06), DataFinal=new DateTime(2017,05,06), Descricao= "Jrd_20170506 - Inicio às 00:00h, Fim até às 06:30h"},
        new Jornadas  {JornadaID=3, DataInicio=new DateTime(2017,05,07), DataFinal=new DateTime(2017,05,07), Descricao= "Jrd_20170507 - Inicio às 01:15h"},
        new Jornadas  {JornadaID=4, DataInicio=new DateTime(2017,05,08), DataFinal=new DateTime(2017,05,08), Descricao= "Jrd_20170508 - Inicio às 01:15h"},
        new Jornadas  {JornadaID=5, DataInicio=new DateTime(2017,05,09), DataFinal=new DateTime(2017,05,10), Descricao= "Jrd_20170510 - Inicio às 01:15h"},
        new Jornadas  {JornadaID=6, DataInicio=new DateTime(2017,05,10), DataFinal=new DateTime(2017,05,10), Descricao= "Jrd_20170510 - Inicio às 01:15h"},
        new Jornadas  {JornadaID=7, DataInicio=new DateTime(2017,05,11), DataFinal=new DateTime(2017,05,12), Descricao= "Jrd_20170512 - Inicio às 01:15h"},
        new Jornadas  {JornadaID=8, DataInicio=new DateTime(2017,05,12), DataFinal=new DateTime(2017,05,12), Descricao= "Jrd_20170512 - Inicio às 01:15h"},
        new Jornadas  {JornadaID=9, DataInicio=new DateTime(2017,05,13), DataFinal=new DateTime(2017,05,13), Descricao= "Jrd_20170513 - Inicio às 01:15h, Fim às 08:30h"},
        new Jornadas  {JornadaID=10, DataInicio=new DateTime(2017,05,14), DataFinal=new DateTime(2017,05,15), Descricao= "Jrd_20170515 - Inicio às 01:15h"}
        };

            jornadas.ForEach(jj => context.Jornadas.AddOrUpdate(j => j.JornadaID, jj));
            //context.SaveChanges(); // commit
            SaveChanges(context);


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
            //context.SaveChanges(); // commit
            SaveChanges(context);



            var produtos = new List<Produtos> {

        new Produtos  {ProdutoID=1, Nome= "Bola Caseira" , Tipo= "Pão", Descricao= "Bola de Farinha de Trigo", Preco=1.8m, IVA=6},
        new Produtos  {ProdutoID=2, Nome= "Broa Amarela" , Tipo= "Pão", Descricao= "Pão de Milho amarelo", Preco=1.8m, IVA=6, Imagem="../Images/broa.jpg"},
        new Produtos  {ProdutoID=3, Nome= "Paposseco" , Tipo= "Pão", Descricao= "Pequenos Pãezinhos de trigo", Preco=0.14m, IVA=6, Imagem="../Images/paposseco.jpg"},
        new Produtos  {ProdutoID=4, Nome= "Bola Mistura" , Tipo= "Pão", Descricao= "Bolas Pequenas de Trigo e Centeio", Preco=0.22m, IVA=6, Imagem="../Images/bola.jpg"},
        new Produtos  {ProdutoID=5, Nome= "Pão Caseiro Mistura" , Tipo= "Pão", Descricao= "Pão de Trigo tipo Caseiro com Centeio", Preco=1.8m, IVA=6, Imagem="../Images/caseiro.jpg"},
        new Produtos  {ProdutoID=6, Nome= "Cacete Mistura" , Tipo= "Pão", Descricao= "Cacete Trigo e Centeio", Preco=0.8m, IVA=6, Imagem="../Images/cacete.jpg"},
        new Produtos  {ProdutoID=7, Nome= "Broa Branca" , Tipo= "Pão", Descricao= "Pão de Milho Branco", Preco=1.8m, IVA=6, Imagem="../Images/broa.jpg"},
        new Produtos  {ProdutoID=8, Nome= "Pão Centeio" , Tipo= "Pão", Descricao= "Pão de Centeio com Trigo", Preco=1.9m, IVA=6, Imagem="../Images/centeio.jpg"},
        new Produtos  {ProdutoID=9, Nome= "Pão de Leite" , Tipo= "Bolos", Descricao= "Pão de Leite", Preco=0.75m, IVA=6}
        };

            produtos.ForEach(pp => context.Produtos.AddOrUpdate(p => p.ProdutoID, pp));
            //context.SaveChanges(); // commit
            SaveChanges(context);


            var itensEncom = new List<ItensEncomenda> {

        new ItensEncomenda  {ID=1, Quantidade= 3 ,  IVA=6, ProdutoFK=1, EncomendaFK=9},
        new ItensEncomenda  {ID=2, Quantidade= 20 , IVA=6, ProdutoFK=2, EncomendaFK=4},
        new ItensEncomenda  {ID=3, Quantidade= 6 ,  IVA=6, ProdutoFK=2, EncomendaFK=2},
        new ItensEncomenda  {ID=4, Quantidade= 8 ,  IVA=6, ProdutoFK=2, EncomendaFK=6},
        new ItensEncomenda  {ID=5, Quantidade= 1 ,  IVA=6, ProdutoFK=5, EncomendaFK=8},
        new ItensEncomenda  {ID=6, Quantidade= 3 ,  IVA=6, ProdutoFK=6, EncomendaFK=1},
        new ItensEncomenda  {ID=7, Quantidade= 1 ,  IVA=6, ProdutoFK=7, EncomendaFK=7},
        new ItensEncomenda  {ID=8, Quantidade= 28,  IVA=6, ProdutoFK=9, EncomendaFK=10},
        new ItensEncomenda  {ID=9, Quantidade= 4 ,  IVA=6, ProdutoFK=6, EncomendaFK=5},
        new ItensEncomenda  {ID=10, Quantidade= 3 , IVA=6, ProdutoFK=7, EncomendaFK=1},
        new ItensEncomenda  {ID=11, Quantidade= 5 , IVA=6, ProdutoFK=3, EncomendaFK=3},
        new ItensEncomenda  {ID=12, Quantidade= 1 , IVA=6, ProdutoFK=4, EncomendaFK=1},
        new ItensEncomenda  {ID=13, Quantidade= 1 , IVA=6, ProdutoFK=1, EncomendaFK=8},
        new ItensEncomenda  {ID=14, Quantidade= 8 , IVA=6, ProdutoFK=1, EncomendaFK=10},
        new ItensEncomenda  {ID=15, Quantidade= 2 , IVA=6, ProdutoFK=2, EncomendaFK=4},
        new ItensEncomenda  {ID=16, Quantidade= 9 , IVA=6, ProdutoFK=4, EncomendaFK=3}
        };

            itensEncom.ForEach(ii => context.ItensEncomenda.AddOrUpdate(i => i.ID, ii));
            //context.SaveChanges(); // commit
            SaveChanges(context);


            var tiposMsg = new List<TiposMsg> {

        new TiposMsg  {TipoID=1, Descricao= "Sugestão"},
        new TiposMsg  {TipoID=2, Descricao= "Dúvida" },
        new TiposMsg  {TipoID=3, Descricao= "Reclamação"}
        };

            tiposMsg.ForEach(tt => context.TiposMsg.AddOrUpdate(t => t.TipoID, tt));
            //context.SaveChanges(); // commit
            SaveChanges(context);


            var msg = new List<Mensagens> {

        new Mensagens  {MensagemID=1, Texto= "Comecem a produzir bolas de centeio" , Data=new DateTime(2017,05,14), Respondida=true, DataResposta=new DateTime(2017,05,20), TextoResposta="Analisaremos a sua sugestão! Obrigado.", DonoDaMensagemFK=1, TipoFK=1},
        new Mensagens  {MensagemID=2, Texto= "Façam bolas caseiras mais pequenas" , Data=new DateTime(2017,05,15), Respondida=true, DataResposta=new DateTime(2017,05,20), TextoResposta="Analisaremos a sua sugestão! Obrigado.", DonoDaMensagemFK=2, TipoFK=1},
        new Mensagens  {MensagemID=3, Texto= "Alarguem hora atendimento" , Data=new DateTime(2017,05,16), Respondida=true, DataResposta=new DateTime(2017,05,20), TextoResposta="Tentaremos iniciar mais cedo!", DonoDaMensagemFK=5, TipoFK=1},
        new Mensagens  {MensagemID=4, Texto= "Que mistura é utilizada nas bolas?" , Data=new DateTime(2017,05,17), Respondida=true, DataResposta=new DateTime(2017,05,21), TextoResposta="Mistura de trigo e centeio.", DonoDaMensagemFK=9, TipoFK=2},
        new Mensagens  {MensagemID=5, Texto= "A broa na semana passada estava muito cozida!" , Data=new DateTime(2017,05,18), Respondida=true, DataResposta=new DateTime(2017,05,22), TextoResposta="Teremos em atenção a sua reclamação.", DonoDaMensagemFK=8, TipoFK=3},
        new Mensagens  {MensagemID=6, Texto= "Qual a diferença entre broa branca e amarela?" , Data=new DateTime(2017,05,19), Respondida=true, DataResposta=new DateTime(2017,05,23), TextoResposta="Apenas se diferenciam pelo milho utilizado, milho branco e marelo respectivamente.", DonoDaMensagemFK=7, TipoFK=2},
        new Mensagens  {MensagemID=7, Texto= "Esqueceram o sal no caseiro na última sexta?" , Data=new DateTime(2017,05,20), Respondida=true, DataResposta=new DateTime(2017,05,25), TextoResposta="Lamentamos e pedimos desculpa pela falha! Tentaremos resolver.", DonoDaMensagemFK=7, TipoFK=3},
        new Mensagens  {MensagemID=8, Texto= "Qual a mistura do centeio?" , Data=new DateTime(2017,05,21), Respondida=true, DataResposta=new DateTime(2017,05,26), TextoResposta="Trigo e centeio com maior percentagem no último! ", DonoDaMensagemFK=7, TipoFK=2},
        new Mensagens  {MensagemID=9, Texto= "Façam broas mais pequenas" , Data=new DateTime(2017,05,22), Respondida=true, DataResposta=new DateTime(2017,05,26), TextoResposta="Analisaremos a sua sugestão! Obrigado.", DonoDaMensagemFK=4, TipoFK=1},
        new Mensagens  {MensagemID=10, Texto= "Os papossecos têm estado muito secos!" , Data=new DateTime(2017,05,25), Respondida=true, DataResposta=new DateTime(2017,05,26),
            TextoResposta ="O clima não tem ajudado, temos tentado deixar mais mal cozidos! Tente conservar os mesmos num saco próprio para pão e evite contacto ao ar livre. Obrigado!", DonoDaMensagemFK=6, TipoFK=3}
        };

            msg.ForEach(mm => context.Mensagens.AddOrUpdate(m => m.MensagemID, mm));
            //context.SaveChanges(); // commit
            SaveChanges(context);


            //********************************************************************************************************

        }
    }



}
