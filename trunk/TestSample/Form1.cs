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

        private void Form1_Load(object sender, EventArgs e)
        {
            Transition.run(this, "Opacity", 0.0, 1.0, new TransitionMethod_Deceleration(800));
        }
        
        private void button1_Click(object sender, EventArgs e)
		{
			//Left = -300;
			//Opacity = 0.6;
            //label1.Text = "Hello";

			//Transition t = new Transition(new TransitionMethod_Linear(1000));
			//t.add(this, "Left", 0);
			//t.add(this, "Opacity", 1.0);
			//t.add(label1, "Text", "A much longer piece of text");
			//t.run();

            Top = 100;
            Left = 100;

            Transition t1 = new Transition(new TransitionMethod_EaseInEaseOut(2000));
            t1.add(this, "Top", 500);
            t1.add(this, "Left", 200);

            Transition t2 = new Transition(new TransitionMethod_EaseInEaseOut(1000));
            t2.add(this, "Top", 200);
            t2.add(this, "Left", 600);

            TransitionChain.run(t1, t2);

		}



    }
}
