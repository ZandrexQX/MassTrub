using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Масса_трубы
{
    public partial class Form1 : Form
    {
		private string _version = "V 0.3 by Zandrex";
		private string _name = "Расчет норморасхода труб";
		public Form1()
		{
			BackColor = SystemColors.AppWorkspace;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Text = _name;
			Size = new Size(300, 300);
			MaximizeBox = false;
			var label1 = new Label
			{
				Location = new Point(0, 10),
				Size = new Size(80, 20),
				Text = "Диаметр D:",
				TextAlign = ContentAlignment.MiddleRight
			};
			var label2 = new Label
			{
				Location = new Point(0, 40),
				Size = new Size(80, 20),
				Text = "Стенка В:",
				TextAlign = ContentAlignment.MiddleRight
			};
			var label3 = new Label
			{
				Location = new Point(0, 70),
				Size = new Size(80, 20),
				Text = "Длина L:",
				TextAlign = ContentAlignment.MiddleRight
			};
			var label4 = new Label
			{
				Location = new Point(0, 150),
				Size = new Size(120, 50),
				Text = "Масса заготовки:\nНорморасход:\nВсего:",
				TextAlign = ContentAlignment.MiddleRight
			};
			var label5 = new Label
			{
				Location = new Point(170, 70),
				Size = new Size(30, 20),
				Text = "N:",
				TextAlign = ContentAlignment.MiddleCenter
			};
			var label6 = new Label
			{
				Location = new Point(150, 240),
				Size = new Size(100, 20),
				Text = _version,
				TextAlign = ContentAlignment.MiddleCenter
			};
			var label7 = new Label
			{
				Location = new Point(200, 10),
				Size = new Size(40, 20),
				Text = "K-т, %",
				TextAlign = ContentAlignment.MiddleCenter
			};
			var label8 = new Label
			{
				Location = new Point(0, 210),
				Size = new Size(210, 20),
				Text = "Формула расчета по ГОСТ 8732-78",
				TextAlign = ContentAlignment.MiddleLeft
			};
			var boxD = new TextBox
			{
				Location = new Point(80, 10),
				Size = label1.Size
			};
			var boxB = new TextBox
			{
				Location = new Point(80, 40),
				Size = label2.Size
			};
			var boxL = new TextBox
			{
				Location = new Point(80, 70),
				Size = label3.Size
			};
			var boxK = new TextBox
			{
				Location = new Point (240, 10),
				Size = new Size(20, 20),
				Text = "8"
			};
			var boxTotal = new TextBox
			{
				BackColor = SystemColors.ButtonShadow,
				BorderStyle = BorderStyle.FixedSingle,
				AcceptsReturn = false,
				Multiline = true,
				Location = new Point(130, 150),
				Size = new Size(60,60),
				ReadOnly = true
			};
			var button = new Button
			{
				FlatStyle = FlatStyle.Popup,
				Location = new Point(0, 100),
				Size = new Size(150, 40),
				Text = "Рассчитать массу"
			};
			var numerics = new NumericUpDown
			{
				Location = new Point(200, 70),
				Size = new Size(40, 20),
				Maximum = new decimal(new int[] { 50, 0, 0, 0 })
			};
			Controls.Add(label1);
			Controls.Add(label2);
			Controls.Add(label3);
			Controls.Add(label4);
			Controls.Add(label5);
			Controls.Add(label6);
			Controls.Add(label7);
			Controls.Add(label8);
			Controls.Add(boxD);
			Controls.Add(boxB);
			Controls.Add(boxL);
			Controls.Add(boxK);
			Controls.Add(boxTotal);
			Controls.Add(button);
			Controls.Add(numerics);
			button.Click += (sender, args) =>
			{
				var k = Num(boxK.Text) / 100 + 1;
				var mass = GetMass(Num(boxD.Text), Num(boxB.Text), Num(boxL.Text));
				var norm = Norma(mass, k);
				var total = Total(norm, (double)numerics.Value);
				boxTotal.Text = $"{mass} \t{norm} \t{total} ";
			};
		}
		public double GetMass(double d, double b, double l)
        {
			return Math.Round((0.02466 * b * (d - b)) * l / 1000, 2);
		}
		public double Norma(double m, double k)
		{
			return Math.Round(m * k, 2);
		}
		public double Total(double norm, double n)
		{
			return norm * n;
		}
		public double Num(string text)
        {
			double result = 1;
			if (double.TryParse(text, out result)) return result;
			return result;
        }
	}
}
