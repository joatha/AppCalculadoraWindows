using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCalculadoraWindows
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firsNumber, secondNumber; 
        public MainPage()
        {
            InitializeComponent();
            limpar(new object(), new EventArgs());
        }

        void limpar (object sender, EventArgs e )
        {
            firsNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }
        void SelecaoDeNumero(object sender, EventArgs e )
        {
            Button button = (Button)sender;
            string presionar = button.Text;

            if(this.resultText.Text=="0" || currentState <0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;

            }
            this.resultText.Text += presionar;

            double number;
            if(double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                if(currentState == 1)
                {
                    firsNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        void selecaoOperador (object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string presionar = button.Text;
            mathOperator = presionar;
        }

        void calculo (object sender, EventArgs e )
        {
            if(currentState == 2)
            {
                double result = 0;
                if(mathOperator == "+")
                {
                    result = firsNumber + secondNumber;
                }
                if (mathOperator == "-")
                {
                    result = firsNumber - secondNumber;
                }
                if (mathOperator == "X")
                {
                    result = firsNumber * secondNumber;
                }
                if (mathOperator == "/")
                {
                    result = firsNumber / secondNumber;
                }
                //this.resultText.Text = result.ToString();
                this.resultText.Text = result.ToString("N0");
                firsNumber = result;
                currentState = -1;
            }
        }

    }
}
