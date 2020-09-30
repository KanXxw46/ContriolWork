using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ControlWork
{
    public class WeatherApp
    {
        public partial class App : Application
        {
            /// <summary>
            /// Prevent repeat run of the application
            /// </summary>
            /// <param name="e"></param>
            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);

                try
                {
                    bool isCreated;
                    Mutex mutex = new Mutex(false, "{CDC10BA9-A593-4351-8327-4C00AEBA6D1C}", out isCreated);
                    if (!isCreated)
                    {
                        // allready running
                        MessageBox.Show(
                            "Приложение уже запущенно, пожалуйста,\r\n" +
                            "закройте программу и повторите попытку",
                            "Повторный запуск программы",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        Application.Current.Shutdown();
                    }
                }
                catch (Exception) { }
            }
        }
}
