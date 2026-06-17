using System;
using System.Windows.Forms;
using skladpredprieatie1.Forms;

namespace skladpredprieatie1
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