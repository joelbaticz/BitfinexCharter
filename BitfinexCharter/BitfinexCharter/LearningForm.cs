using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitfinexCharter.Services;

namespace BitfinexCharter
{
    public partial class LearningForm : Form
    {
        private LearningFormService _formService;

        public LearningForm(LearningFormService formService)
        {
            InitializeComponent();
            _formService = formService;
        }

        private void btnNextCandle_Click(object sender, EventArgs e)
        {
            _formService.NextCandle();
        }

        private void btnPreviousCandle_Click(object sender, EventArgs e)
        {
            _formService.PreviousCandle();
        }

        private void btnLearn_Click(object sender, EventArgs e)
        {
            _formService.Learn();
        }

        private void cbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            _formService.ChangeResolution(cbResolution.Text);
        }

        private void cbNoOfCandles_SelectedIndexChanged(object sender, EventArgs e)
        {
            _formService.ChangeNoOfCandles(cbNoOfCandles.Text);
        }


        //FormWindowState LastWindowState = FormWindowState.Minimized;
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (_formService != null)
            {
                _formService.WindowSizeChanged();
            }
            //// When window state changes
            //if (WindowState != LastWindowState)
            //{
            //    LastWindowState = WindowState;


            //    if (WindowState == FormWindowState.Maximized)
            //    {

            //        // Maximized!
            //    }
            //    if (WindowState == FormWindowState.Normal)
            //    {

            //        // Restored!
            //    }
            //}

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _formService.StopLearning();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //_formService.Sort();
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {            
            _formService.SetPredict();
            btnPredict.Text = "Unpredict";

        }
    }
}
