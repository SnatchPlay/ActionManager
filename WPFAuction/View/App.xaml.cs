using BusinessLogic;
using DAL;
using DAL.Repository;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Resolution;

namespace WPFAuction
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UnityContainer container;
        static string conn;

        //public object ConfigurationManager { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureUnity();
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            LoginWindow login = container.Resolve<LoginWindow>();
            login.ShowDialog();
            if (login.DialogResult.GetValueOrDefault())
            {
                
                this.ShutdownMode = ShutdownMode.OnMainWindowClose;
                var mainWindow = container.Resolve<MainWindow>();
                this.MainWindow = mainWindow;
                this.MainWindow.Show();
            }
            else
            {
                this.Shutdown();
            }
        }

        private static void ConfigureUnity()
        {
            container = new UnityContainer();

            container.RegisterType<IRepository<User>, UserRepository>()
                 .RegisterType<IRepository<ActionDTO>, ActionRep>()
                 .RegisterType<IRepository<Category>, CategoryRep>()
                 .RegisterType<IRepository<TypeDTO>, TypeRep>()
                 .RegisterType<IRepository<Goods>, GoodsRep>()
                 .RegisterType<UserLogic>();
        }


    }
}

