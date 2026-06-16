using System;
using System.Windows.Forms;
using service15.Forms;

namespace service15
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Настройки конфигурации приложения, характерные для .NET 5 / .NET Core 3.1
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Запуск главной формы
            Application.Run(new MainForm());
        }
    }
}