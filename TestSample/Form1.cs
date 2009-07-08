using System;
using System.Windows.Forms;
using Transitions;

namespace TestSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		private void button1_Click(object sender, EventArgs e)
		{
			Left = -300;
			Opacity = 0.0;
            label1.Text = "Hello";

			Transition t = new Transition(new TransitionMethod_Linear(500));
			t.add(this, "Left", 0);
			t.add(this, "Opacity", 1.0);
            t.add(label1, "Text", "A much longer piece of text");
			t.go();

		}

    }
}
