using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using DAL;
using DTO;
using DAL.Repository;

namespace WinFormAction
{
    internal static class Program
    {
        public static IUnityContainer Container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureUnity();
            UnityContainer Container = new UnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginform = Container.Resolve<LoginForm>();
            var temp = loginform.ShowDialog();
            if (temp == DialogResult.OK)
            {
                Application.Run(Container.Resolve<MainForm>());
            }
            else
            {
                Application.Exit();
            }

            //Application.Run(new LoginForm());
        }
        private static void ConfigureUnity()
        {
            Container = new UnityContainer();
            Container.RegisterType<IRepository<User>, UserRepository>()
                .RegisterType<IRepository<ActionDTO>, ActionRep>()
                .RegisterType<IRepository<Category>, CategoryRep>()
                .RegisterType<IRepository<TypeDTO>, TypeRep>()
                .RegisterType<IRepository<Goods>, GoodsRep>();
        }
    }
}
