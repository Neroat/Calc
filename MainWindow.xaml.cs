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
using Calc.ViewModel;

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new CalculatorViewModel();
            DataContext = viewModel;

        }
        void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Content.ToString();
            viewModel.NumberPressed(number);
        }
        void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            viewModel.ClearPressed();
        }
        void OperationButton_Click(Object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Content.ToString();
            viewModel.OperationPressed(operation);
        }
        void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.EqualsPressed();
        }
        void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DecimalPressed();

        }
        void ClearEntryButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ClearEntryPressed();
        }
        void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.BackspacePressed();
        }
        void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        { 
            viewModel.PlusMinusPressed();
        }
        void PowButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PowPressed();
        }
        void RootButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RootPressed();
        }
        void PercentButton_Click(object obj, RoutedEventArgs e)
        {
            viewModel.PercentPressed();
        }
        void RecipButton_Click(object obj, RoutedEventArgs e)
        {
            viewModel.RecipPressed();
        }
    }
}