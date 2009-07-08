using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

        private void Form1_Load(object sender, EventArgs e)
        {
        }

		private void button1_Click(object sender, EventArgs e)
		{

			//Transition t = new Transition(new TransitionMethod_Linear(500));
			//t.add(this, "Width", 500);
			//t.add(this, "Height", 100);
			//t.go();

		}
    }
}
