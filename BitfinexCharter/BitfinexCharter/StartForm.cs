using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using System.Web;
using System.Data.Entity;
using BitfinexCharter.Services;
using BitfinexCharter.Models;

namespace BitfinexCharter
{
    public partial class StartForm : Form
    {
        private DBContextService _dbService;

        public StartForm()
        {
            InitializeComponent();

            tlblStatus.Text = "Database: Connecting...";

            ConnectionForm connForm = new ConnectionForm();
            connForm.Show();


            _dbService = connForm.Connect();

            if (_dbService==null)
            {
                MessageBox.Show("Could not connect to the Database!");
                Application.Exit();
            }

            tlblStatus.Text = "Database: Connected.";

            connForm.Close();
        }

        private void btnDatabaseFunctions_Click(object sender, EventArgs e)
        {
            DatabaseForm databaseForm = new DatabaseForm(_dbService);
            databaseForm.Show();
        }

        private void btnLearningFunctions_Click(object sender, EventArgs e)
        {
            LearningFormService learningFormService = new LearningFormService(_dbService);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
