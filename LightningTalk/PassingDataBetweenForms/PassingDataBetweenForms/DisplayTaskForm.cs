﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PassingDataBetweenForms
{
    public partial class DisplayTaskForm : Form
    {
        private string taskName, source, target;
    
        public DisplayTaskForm()
        {
            InitializeComponent();
        }

        /*The constructor approach*/
        public DisplayTaskForm(string taskName, string source, 
                               string target) : this()
        {
            this.taskName = taskName;
            this.source = source;
            this.target = target;
            
            populateListView();
        }

        private void populateListView()
        {
            ListViewItem task = new ListViewItem(taskName);
            task.SubItems.Add(source);
            task.SubItems.Add(target);

            lvTask.Items.Add(task);
        }
    }
}
