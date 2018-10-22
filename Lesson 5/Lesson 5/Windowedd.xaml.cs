using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lesson_5
{
    /// <summary>
    /// Логика взаимодействия для Windowedd.xaml
    /// </summary>
    public partial class Windowedd : Window
    {
        public Windowedd(Employee e)
        {
            InitializeComponent();
            Redact1.DataContext = e;
        }
    }
}
