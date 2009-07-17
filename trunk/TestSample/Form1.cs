using System;
using System.Windows.Forms;
using Transitions;
using System.Drawing;
using System.Collections.Generic;

namespace TestSample
{
    public partial class Form1 : Form
    {
        #region Public methods

        /// <summary>
        /// Constructor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Form event handlers

        private void Form1_Load(object sender, EventArgs e)
        {
            Transition.run(this, "Opacity", 0.0, 1.0, new TransitionType_Deceleration(800));
        }
        
        private void cmdCrossFadePictures_Click(object sender, EventArgs e)
        {
        }

        private void cmdBounceMe_Click(object sender, EventArgs e)
        {
            int iDestination = gbBounce.Height - cmdBounceMe.Height;
            Transition.run(cmdBounceMe, "Top", iDestination, new TransitionType_Bounce(1500));
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
   
            int iDestination = gbDropAndBounce.Height - cmdDropAndBounce.Height - 10;
            Transition.run(cmdDropAndBounce, "Top", iDestination, new TransitionType_UserDefined(elements, 2000));

            Transition t1 = new Transition(new TransitionType_Linear(2000));
            t1.add(cmdDropAndBounce, "Left", cmdDropAndBounce.Left + 400);

            Transition t2 = new Transition(new TransitionType_EaseInEaseOut(2000));
            t2.add(cmdDropAndBounce, "Top", 19);
            t2.add(cmdDropAndBounce, "Left", 6);

            Transition.runChain(t1, t2);
        }

        private void cmdThrowAndCatch_Click(object sender, EventArgs e)
        {
            Transition.run(cmdThrowAndCatch, "Top", 12, new TransitionType_ThrowAndCatch(1500));
        }

        private void cmdTextTransition_Click(object sender, EventArgs e)
        {
            Transition t = new Transition(new TransitionType_Linear(1000));
            if (lblTextTransition1.Text == "Hello, World!")
            {
                t.add(lblTextTransition1, "Text", "A longer piece of text.");
                t.add(lblTextTransition1, "ForeColor", Color.Red);

                t.add(lblTextTransition2, "Text", "Hello, World!");
                t.add(lblTextTransition2, "ForeColor", Color.Blue);
            }
            else
            {
                t.add(lblTextTransition1, "Text", "Hello, World!");
                t.add(lblTextTransition1, "ForeColor", Color.Blue);

                t.add(lblTextTransition2, "Text", "A longer piece of text.");
                t.add(lblTextTransition2, "ForeColor", Color.Red);
            }
            t.run();
        }

        private void cmdSwap_Click(object sender, EventArgs e)
        {
            Control ctrlOnScreen, ctrlOffScreen;
            if (gbBounce.Left == GROUP_BOX_LEFT)
            {
                ctrlOnScreen = gbBounce;
                ctrlOffScreen = gbThrowAndCatch;
            }
            else
            {
                ctrlOnScreen = gbThrowAndCatch;
                ctrlOffScreen = gbBounce;
            }
            ctrlOnScreen.SendToBack();
            ctrlOffScreen.BringToFront();

            Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
            t.add(ctrlOnScreen, "Left", -1 * ctrlOnScreen.Width);
            t.add(ctrlOffScreen, "Left", GROUP_BOX_LEFT);
            t.run();
        }

        private void ctrlChangeFormColor_Click(object sender, EventArgs e)
        {
            Color destination = (BackColor == BACKCOLOR_PINK) ? BACK_COLOR_YELLOW : BACKCOLOR_PINK;
            Transition.run(this, "BackColor", destination, new TransitionType_Linear(1000));
        }

        #endregion

        #region Private data

        // Colors used by the change-form-color transition...
        private Color BACKCOLOR_PINK = Color.FromArgb(255, 220, 220);
        private Color BACK_COLOR_YELLOW = Color.FromArgb(255, 255, 220);

        // The left point of the 'bounce' and 'throw-and-catch' group boxes...
        private const int GROUP_BOX_LEFT = 12;

        #endregion

        private void cmdMore_Click(object sender, EventArgs e)
        {
            int iFormWidth;
            if (cmdMore.Text == "More >>")
            {
                iFormWidth = 984;
                cmdMore.Text = "<< Less";
            }
            else
            {
                iFormWidth = 452;
                cmdMore.Text = "More >>";
            }

            Transition.run(this, "Width", iFormWidth, new TransitionType_EaseInEaseOut(1000));
        }
    }
}
