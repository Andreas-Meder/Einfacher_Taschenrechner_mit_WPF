using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace WpfTaschenrechner
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBerechnen_Click(object sender, RoutedEventArgs e)
        {
            // 1. Eingaben validieren und umwandeln (unterstützt Komma und Punkt)
            if (!double.TryParse(tbZahl1.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double zahl1))
            {
                tbErgebnis.Text = "Ungültige Zahl 1!";
                return;
            }

            if (!double.TryParse(tbZahl2.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double zahl2))
            {
                tbErgebnis.Text = "Ungültige Zahl 2!";
                return;
            }

            // 2. Operator aus der Tag-Eigenschaft des Buttons auslesen
            var button = sender as Button;
            string operation = button?.Tag?.ToString();

            double ergebnis = 0;

            // 3. Berechnung durchführen
            switch (operation)
            {
                case "+":
                    ergebnis = zahl1 + zahl2;
                    break;
                case "-":
                    ergebnis = zahl1 - zahl2;
                    break;
                case "*":
                    ergebnis = zahl1 * zahl2;
                    break;
                case "/":
                    if (zahl2 == 0)
                    {
                        tbErgebnis.Text = "Teilung durch 0 nicht möglich!";
                        return;
                    }
                    ergebnis = zahl1 / zahl2;
                    break;
                default:
                    return;
            }

            // 4. Ergebnis im Ergebnis-Textblock anzeigen
            tbErgebnis.Text = ergebnis.ToString("0.######");
        }
    }
}