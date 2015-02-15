﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLibrary
{
    public partial class About : Form
    {
        private Logger logger;

        public About(Logger logger)
        {
            InitializeComponent();
            this.logger = logger;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url = ((LinkLabel)sender).Text;
            System.Diagnostics.Process.Start(url);
        }
    }
}
