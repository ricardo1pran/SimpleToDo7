using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SimpleToDo7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool checkAlerts()
        {
            return Properties.Settings.Default.showToDoAlerts;
        }

        private bool checkEditComplete()
        {
            return Properties.Settings.Default.allowEditCompleted;
        }

        private bool checkExitConfirm()
        {
            return Properties.Settings.Default.showExitConfirm;
        }

        private bool checkNoHeader()
        {
            return Properties.Settings.Default.noHeaderTXT;
        }

        private void addToDo()
        {
            var todotext = textBox1.Text;
            listBox1.Items.Add(todotext);
            resetTextbox1();
        }

        private void editToDo()
        {
            var editedToDo = textBox1.Text;
            listBox1.Items[listBox1.SelectedIndex] = editedToDo;
        }

        public void resetAfterEdit()
        {
            // call reset button function
            resetTextbox1();

            // reset the rest:
            // rename buttons
            button6.Text = "Edit";
            button1.Text = "Add ToDo!";

            // enable the rest of buttons
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button7.Enabled = true;

            // enable listbox
            listBox1.Enabled = true;
        }

        private void resetTextbox1()
        {
            textBox1.Text = "";
        }

        private void resetStatusStrip()
        {
            toolStripStatusLabel1.Text = "Standby";
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetTextbox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Reset if button is edit state
            if (button1.Text.Contains("Edit"))
            {
                // functon to Edit
                editToDo();

                // reset all button states
                resetAfterEdit();
                return;
            }

            if (textBox1.Text.Equals(""))
            {
                if(checkAlerts())
                    MessageBox.Show("Please insert ToDo first", "Error: ToDo empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            addToDo();
            
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            resetStatusStrip();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            resetStatusStrip();
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            resetStatusStrip();
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            resetStatusStrip();
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            resetStatusStrip();
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            resetStatusStrip();
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            resetStatusStrip();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Clear the add ToDo textbox";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Add what you just type to the ToDo list!";
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Reorder the selected ToDo, up by 1 level";
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Reorder the selected ToDo, down by 1 level";
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Delete the selected ToDo";
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Edit the selected ToDo";
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Mark selected ToDo as completed!";
        }

        private void clearAllToDosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0)
            {
                if(checkAlerts())
                    MessageBox.Show("There are no ToDo(s) yet!", "Nothing to clear!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var ask = MessageBox.Show("Are you sure you want to clear all ToDos?\nThis action can't be undoned!", "Clear All Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ask.Equals(DialogResult.Yes))
            {
                listBox1.Items.Clear();
            }
        }

        private void clearAllToDosToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Caution: Clear all ToDos";
        }

        private void clearAllToDosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            resetStatusStrip();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                if(checkAlerts())
                    MessageBox.Show(this, "The ToDo List is Empty..\nNothing to save!", "Oops!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return;
            }
            toolStripStatusLabel1.Text = "Saving ToDo to .txt ... ";
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = 25;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Header file
                toolStripProgressBar1.Value = 30;
                var enter = Environment.NewLine;
                var separator = "----------------------------------------";
                var header = "----- Simple ToDo7 Saved ToDo List -----";
                toolStripProgressBar1.Value = 50;
                if(!checkNoHeader())
                    File.WriteAllText(saveFileDialog1.FileName, separator + enter + header + enter + separator + enter + enter);
                toolStripProgressBar1.Value = 75;
                foreach (var item in listBox1.Items)
                {
                    var bullet = "o ";
                    if (item.ToString().Contains("Completed")) bullet = "- ";
                    File.AppendAllText(saveFileDialog1.FileName, bullet + item.ToString() + enter);
                }
                toolStripProgressBar1.Value = 100;

                MessageBox.Show(this, "ToDo List saved succesfully!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resetStatusStrip();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                if(checkAlerts())
                    MessageBox.Show(this, "Please select a ToDo to be deleted!", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                return;
            }

            var ask = MessageBox.Show("Are you sure want to delete this ToDo?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ask.Equals(DialogResult.Yes))
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if(checkAlerts())
                    MessageBox.Show(this, "ToDo Deleted!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                if(checkAlerts())
                    MessageBox.Show(this, "Select a Todo first!", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                return;
            }

            if (listBox1.Items[listBox1.SelectedIndex].ToString().Contains("Completed!"))
            {
                if(checkAlerts())
                    MessageBox.Show(this, "Oops! ToDo is already completed!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                return;
            }
            var selectedTodo = listBox1.Items[listBox1.SelectedIndex].ToString();
            var completedTodo = "(" + selectedTodo + ") --Completed!";
            listBox1.Items[listBox1.SelectedIndex] = completedTodo;
            
            if(checkAlerts())
                MessageBox.Show(this, "ToDo Completed!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information
                );
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // if this button is for cancel edit:
            if (button6.Text.Contains("Cancel"))
            {
                // call reset after edit
                resetAfterEdit();

                // return
                return;
            }
            int selectedIndex = 0;
            var oldValue = "";

            if (listBox1.SelectedItem == null)
            {
                if(checkAlerts())
                    MessageBox.Show(this, "Select a Todo to edit!", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                return;
            }

            if(!checkEditComplete()) // if AllowEditComplete false (default)
                if (listBox1.Items[listBox1.SelectedIndex].ToString().Contains("Completed!"))
                {
                    if(checkAlerts())
                        MessageBox.Show(this, "Oops! ToDo is already completed and can't be edited!", "Can't edit completed ToDo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );
                    return;
                }

            // process selected data
            selectedIndex = listBox1.SelectedIndex;
            oldValue = listBox1.Items[listBox1.SelectedIndex].ToString();

            /*
             * Controlling The Forms
             * 
             * Disabling items, buttons, etc.
             * 
             */

            // put old value to textbox
            textBox1.Text = oldValue;

            // rename buttons
            button6.Text = "Cancel Edit";
            button1.Text = "Edit ToDo!";

            // disable the rest of buttons
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            //button6.Enabled = false;
            button7.Enabled = false;

            // disable listbox
            listBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0)
            {
                return;
            }
            
            int currPosition;
            currPosition = listBox1.SelectedIndex;
            
            // can't move if already on top
            if (currPosition == 0)
            {
                if(checkAlerts())
                    MessageBox.Show(this, "Oops! ToDo is already on Top!", "Can't move ToDo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                return;
            }

            var tempVal = listBox1.Items[currPosition];

            // moving process
            listBox1.Items[currPosition] = listBox1.Items[currPosition - 1];
            listBox1.Items[currPosition - 1] = tempVal;
            listBox1.SelectedIndex = (currPosition - 1);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0)
            {
                return;
            }

            int currPosition;
            currPosition = listBox1.SelectedIndex;

            // can't move if already on top
            if (currPosition == listBox1.Items.Count-1)
            {
                if(checkAlerts())
                    MessageBox.Show(this, "Oops! ToDo is already on Buttom!", "Can't move ToDo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                return;
            }

            var tempVal = listBox1.Items[currPosition];

            // moving process
            listBox1.Items[currPosition] = listBox1.Items[currPosition + 1];
            listBox1.Items[currPosition + 1] = tempVal;
            listBox1.SelectedIndex = (currPosition + 1);

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var aboutForm = new About();
            aboutForm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkExitConfirm())
            {
                var x = MessageBox.Show("All ToDos will be lost after you exit!\nAre you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x.Equals(DialogResult.Yes))
                {
                    return;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                return;
            }
        }

        private void featuresComingSoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Features Coming Soon!", "Coming Soon!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Features Coming Soon!", "Coming Soon!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var prefForm = new Preferences();
            prefForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simple Guide\n"
            + "\nView the status bar for hint about the buttons usages."
            + "\nSimply type your first thing you want to do in the textbox, and click \"Add ToDo!\""
            + "\nTo Complete or Delete a ToDo, simply click on the appropriate buttons."
            + "\nTo Edit a ToDo, simply click Edit Button, change the value, and click \"Edit ToDo!\" button."
            , "Simple Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

    }
}
