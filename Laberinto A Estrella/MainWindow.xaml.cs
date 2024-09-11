using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laberinto_A_Estrella
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
            var mapa = new bool[,]
            {
                //{true, true, true, true, true },
                //{true, true, true, true, true },
                //{true, true, false, true, true },
                //{true, true, true, true, true },
                //{true, true, true, true, true },
                {false, false, false, false, false },
				{false, false, false, false, false },
				{false, false, true, false, false },
				{false, false, false, false, false },
				{false, false, false, false, false },
			};
            var aEstrella = new AEstrella(5, 5, mapa);
            var inicial = aEstrella.BuscarRuta(aEstrella._nodos[0, 0], aEstrella._nodos[4, 4]);
		}
        ///-----------DISPATCHER CHECK ACCESS------------------

        //private void updateControl(object uiObject)
        //{
        //    Button buton = uiObject as Button;
        //    if( buton != null )
        //    {
        //        if (buton.Dispatcher.CheckAccess())
        //        {
        //            updateButton(buton);
        //        }
        //        else
        //        {
        //            //hilo distinto de la interfaz de usuario
        //            buton.Dispatcher.BeginInvoke(Dispatcher.Priority.Normal,
        //                new updateUiDelegate(updateButon), buton);
        //        }
        //    }
        //}
	}
}