using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auth;

namespace CryptoTriangular
{
    static class Program
    {
        private static Thread splashThread;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                splashThread = new Thread(new ThreadStart(DisplaySplashScreen));
                splashThread.Start();
                Thread authThread = new Thread(new ThreadStart(AuthorizationMethod));
                authThread.SetApartmentState(ApartmentState.STA);
                authThread.Start();
            }
            catch (Exception  error)
            {
                //Log.Error(error);
                //HandleError.CloseProgram();
            }
        }

        private static void DisplaySplashScreen()
        {
            Application.Run(new SplashScreen());
        }

        private static void AuthorizationMethod()
        {
            bool shouldClose = false;
            try
            {
                var authorization = new AuthUser();
                ServerPackage package = null;
                package = authorization.ValidateUser();
                
                if (package == null)
                {
                    return;
                }
                if (package.validationResult == ValidationResult.expired)
                {
                    splashThread.Abort();
                    Application.Run(new PaymentWindow(package));
                }

                else if (package.validationResult == ValidationResult.actual)
                {
                    splashThread.Abort();
                    Application.Run(new MainWindow(package));
                }
                else //temporary
                {
                    splashThread.Abort();
                    Application.Run(new MainWindow(package));
                }
            }
            catch (Exception error)
            {
                //Log.Error(error);
                //HandleError.CloseProgram();
            }

        }

    }
}
