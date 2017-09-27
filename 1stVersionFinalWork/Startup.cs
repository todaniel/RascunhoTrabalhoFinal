using FinalWork.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System;
using System.Web.ModelBinding;

namespace FinalWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            IniciaAplicacao();
        }



        private void IniciaAplicacao()
        {
            OrdersDB db = new OrdersDB();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!roleManager.RoleExists("Gestor"))
            {
                var role = new IdentityRole();
                role.Name = "Gestor";
                roleManager.Create(role);

                // criar um utilizador 'Gestor'
                var user = new ApplicationUser();
                user.UserName = "gest-antonio@hotmail.com";  // LOGIN
                user.Email = "gest-antonio@hotmail.com";
                string userPWD = "18939_TI2"; // PASSWORD
                var chkUser = userManager.Create(user, userPWD);

                //Adicionar o Utilizador à respetiva Role-Funcionário-
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Gestor");
                }

            }

            if (!roleManager.RoleExists("Cliente"))
            {
                var role = new IdentityRole();
                role.Name = "Cliente";
                roleManager.Create(role);

                // criar um utilizador 'Cliente'
                var user = new ApplicationUser();
                user.UserName = "test-cliente@hotmail.com";  // LOGIN
                user.Email = "test-cliente@hotmail.com";
                string userPWD = "18939_TI2"; // PASSWORD
                var chkUser = userManager.Create(user, userPWD);


                //Adicionar o Utilizador à respetiva Role-Cliente-
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Cliente");
                }
            }







            //Models.OrdersDB db = new Models.OrdersDB();

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));


            ////############################################################################3
            //// Criar a role 'Gestor'
            //if (!(roleManager.RoleExists("Gestor")))
            //{
            //    var role = new IdentityRole();
            //    role.Name = "Gestor";
            //    roleManager.Create(role);

            //    // criar 1º utilizador 'Gestor'
            //    var gest1 = new ApplicationUser();
            //    gest1.UserName = "gest-antonio@ipt.pt";
            //    gest1.Email = "gest-antonio@ipt.pt";
            //    //user.Nome = "Luís Freitas";

            //    string gest1PWD = "123_Asd";
            //    var chkgest1 = userManager.Create(gest1, gest1PWD);

            //    //Adicionar o Utilizador à respetiva Role-Dono-
            //    if (chkgest1.Succeeded)
            //    {
            //        var result1 = userManager.AddToRole(gest1.Id, "Gestor");
            //    }
            //}
            ////#########################################################################


            //// Criar a role 'Cliente'
            //if (!roleManager.RoleExists("Cliente"))
            //{
            //    var role = new IdentityRole();
            //    role.Name = "Cliente";
            //    roleManager.Create(role);
            //}

            //// criar 1º utilizador 'Cliente'
            ////var cliente1 = new ApplicationUser();
            //var cliente1 = new Clientes();
            //cliente1.Nome = "teste";
            //cliente1.NomeLogin = "teste@ipt.pt";

            //string gest1PWD = "123_Asd";
            //var chkgest1 = userManager.Create(cliente1, gest1PWD);

            ////Adicionar o Utilizador à respetiva Role-Dono-
            //if (chkgest1.Succeeded)
            //{
            //    var result1 = userManager.AddToRole(gest1.Id, "Gestor");
            //}


            ////// criar um utilizador 'Cliente'
            ////Clientes cliente1 = new Clientes();
            ////cliente1.ClienteID = 100;
            ////cliente1.Nome = "UserTest-1";
            ////cliente1.Contacto = "913231526";
            ////cliente1.Contribuinte = "913231526";
            ////cliente1.Mail = "aluno18939@ipt.pt";
            ////string userPWD = "123_Asd";

            ////// criar um utilizador 'Cliente'
            ////var user = new ApplicationUser();
            ////user.UserName = "a@a.aa";
            ////user.Email = "a@a.aa";
            //////user.Nome = "Luís Freitas";
            ////string userPWD = "123_Asd";
            ////var chkUser = userManager.Create(user, userPWD);

            ////Adicionar o Utilizador à respetiva Role-Cliente
            ////if (chkUser.Succeeded){
            ////    var result1 = userManager.AddToRole(user.Id, "Cliente");
            ////}
            //// }CONFIRMAR


        } //Fecha o 'IniciaAplicacao()'
    } //Fecha Classe
} //Fecha namespace
