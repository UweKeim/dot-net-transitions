using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            Transition t = new Transition(this, new TransitionMethod_Linear(500));
            Width = 500;
            Height = 100;
            t.go();


            Transition t2 = new Transition(this, new TransitionMethod_Linear(500));
            Width = 500;
            Height = 100;
            t2.go();
        }
    }
}
