using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AlinaTashkhuzhaeva422_PetAndDegs
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AlinaTashkhuzhaeva422_PetAndDogsEntities2 db = new AlinaTashkhuzhaeva422_PetAndDogsEntities2();
        public static MainWindow main;
        public static int id_user;
    }
}
