using AplicatieMobila.Data;

namespace AplicatieMobila
{
    public partial class App : Application
    {

        public static ShoppingListDatabase Database { get; private set; }

        public App()
        {
            Database = new ShoppingListDatabase(new RestService());
            MainPage = new AppShell();
        }
    }
}