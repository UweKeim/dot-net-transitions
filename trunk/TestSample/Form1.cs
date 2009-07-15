using System;
using System.Windows.Forms;
using Transitions;
using System.Drawing;
using System.Collections.Generic;

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
            Transition.run(this, "Opacity", 0.0, 1.0, new TransitionType_Deceleration(800));
        }
        
        private void button1_Click(object sender, EventArgs e)
		{
            Opacity = 0.6;

            Transition t1 = new Transition(new TransitionType_EaseInEaseOut(500));
            t1.add(this, "Top", 100);
            t1.add(this, "Left", 100);

            Transition t2 = new Transition(new TransitionType_Acceleration(1000));
            t2.add(this, "Top", 500);
            t2.add(this, "Left", 200);
            //t2.add(this, "Opacity", 0.7);

            Transition t3 = new Transition(new TransitionType_Deceleration(800));
            t3.add(this, "Top", 200);
            t3.add(this, "Left", 600);
            //t3.add(this, "Opacity", 0.8);

            Transition t4 = new Transition(new TransitionType_Linear(200));
            t4.add(this, "Opacity", 1.0);

            Transition.runChain(t1, t2, t3, t4);

		}

        private void cmdCrossFadePictures_Click(object sender, EventArgs e)
        {
        }

        private void cmdBounceMe_Click(object sender, EventArgs e)
        {
            int iDestination = ClientRectangle.Height - cmdBounceMe.Height;
            Transition.run(cmdBounceMe, "Top", iDestination, new TransitionType_Bounce(1400));
        }

        private void cmdFlashMe_Click(object sender, EventArgs e)
        {
            Transition.run(cmdFlashMe, "BackColor", Color.Pink, new TransitionType_Flash(2, 300));
        }

        private void cmdRipple_Click(object sender, EventArgs e)
        {
            ctrlRipple.ripple();
        }

        private void cmdDropAndBounce_Click(object sender, EventArgs e)
        {
            IList<TransitionElement> elements = new List<TransitionElement>();
            elements.Add(new TransitionElement(40, 100, InterpolationMethod.Accleration));
            elements.Add(new TransitionElement(65, 65, InterpolationMethod.Deceleration));
            elements.Add(new TransitionElement(80, 100, InterpolationMethod.Accleration));
            elements.Add(new TransitionElement(90, 90, InterpolationMethod.Deceleration));
            elements.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
   
            int iDestination = ClientRectangle.Height - cmdDropAndBounce.Height;
            Transition.run(cmdDropAndBounce, "Top", iDestination, new TransitionType_UserDefined(elements, 2000));


        }

        private void cmdThrowAndCatch_Click(object sender, EventArgs e)
        {
            Transition.run(cmdThrowAndCatch, "Top", 0, new TransitionType_ThrowAndCatch(2500));
        }



    }
}
