using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using BitfinexCharter.Services;

namespace BitfinexCharter
{
    public partial class ConnectionForm : Form
    {
        public DBContextService _dbService;

        public ConnectionForm()
        {
            InitializeComponent();
        }

        public DBContextService Connect()
        {
            prgConnection.Value = 50;
            prgConnection.Refresh();
            prgConnection.Update();
            prgConnection.Invalidate();

            try
            {
                _dbService = new DBContextService();
            }
            catch (Exception e)
            {
                return null;
            }

            return _dbService;
        }
    }
}
