using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etat_civile
{
    public partial class SAPNaissance : Form
    {
        public SAPNaissance()
        {
            InitializeComponent();
        }
        string Num;
        public SAPNaissance(string num)
        {
            InitializeComponent();
        }
        private void SAPNaissance_Load(object sender, EventArgs e)
        {

        }
    }
}
