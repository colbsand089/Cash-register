// Colbey Sands November 26 2020
// Example of basic cash register.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
namespace sumative
{
    public partial class Trash : Form
    {
        
        double taxRate = 0.13;
        double coffeeCost = 1.45;
        double donutCost = 3.65;
        double trashbitCost =9.00;
        double numberOfCoffee = 0;
        double numberOfDonuts = 0;
        double numberOfTrashbits = 0;
        double costOfOrder = 0;
        double taxAmount = 0;
        double costOfOrderWithTax = 0;
        double tendered;
        double changeBack = 0;
        public Trash()
        {
            InitializeComponent();
        }

        private void CalculateTotalsButton_Click(object sender, EventArgs e)
        {
            // Calculations for user imput boxes.

            numberOfCoffee = Convert.ToInt32(coffeInputTextbox.Text);
            numberOfDonuts = Convert.ToInt32(donutInputTextbox.Text);
            numberOfTrashbits = Convert.ToInt32(trashbitsInputTextbox.Text);

            // Calculations for $ amounts.
            costOfOrder = coffeeCost * numberOfCoffee + donutCost * numberOfDonuts + trashbitCost * numberOfTrashbits;
            taxAmount = costOfOrder * taxRate;
            costOfOrderWithTax = costOfOrder + taxAmount;

            // Calculations for final $ amounts.
            subTotalCost.Text = $"{costOfOrder.ToString("$.00")}";
            taxCost.Text = $"{taxAmount.ToString("$.00")}";
            totalCost.Text = $"{costOfOrderWithTax.ToString("$.00")}";
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            // Things shown on the printer.
            SoundPlayer player = new SoundPlayer(Properties.Resources.Dot_Matrix_Printer_SoundBible_com_790333844);
            player.Play();
            printLabel.Text = $"Coffee:                   {numberOfCoffee}";
            Refresh();
            Thread.Sleep(400);

            player.Play();
            printLabel.Text += $"\nDonuts:                   {numberOfDonuts}";
            Refresh();
            Thread.Sleep(400);

            player.Play();
            printLabel.Text += $"\nTrashbits:                {numberOfTrashbits}";
            Refresh();
            Thread.Sleep(400);

            player.Play(); 
            printLabel.Text += $"\n\nSub Total:                {costOfOrder.ToString("$.00")}";
            Refresh();
            Thread.Sleep(400);

            player.Play();
            printLabel.Text += $"\nTax:                      {taxAmount.ToString("$.00")}";
            Refresh();
            Thread.Sleep(400);

            player.Play();
            printLabel.Text += $"\nTotal Cost:               {costOfOrderWithTax.ToString("$.00")}";
            Refresh();
            Thread.Sleep(400);

            player.Play();
            printLabel.Text += $"\n\nTendered                  {tendered.ToString("$.00")}";
            Refresh();
            Thread.Sleep(400);

            player.Play();
            printLabel.Text += $"\nChange back               {changeBack.ToString("$.00")}";
            Refresh();
            Thread.Sleep(400);

            printLabel.Text += $"\n\n        Have a trash day!";
        }

        private void CalculateChangeButton_Click(object sender, EventArgs e)
        {
            // Calulations for tendered and change.
            tendered = Convert.ToDouble(tenderedTextbox.Text);
            changeBack = tendered - costOfOrderWithTax;
            changeAmount.Text = $"{changeBack.ToString("$.00")}";
        }
    }
}
