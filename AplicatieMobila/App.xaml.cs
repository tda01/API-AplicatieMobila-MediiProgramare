using AplicatieMobila.Data;

namespace AplicatieMobila
{
    public partial class App : Application
    {

        public static ProductDatabase Database { get; private set; }

        public App()
        {
            Database = new ProductDatabase(new RestService());
            MainPage = new AppShell(); 

        }
    }
}