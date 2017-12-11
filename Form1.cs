using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace averageGrades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            //input a streamReader file variable within the try-catch block
            try {
                StreamReader inputFile;
                string line; //Used to read a line from the file
                int total;
                double average;
                int count = 0; //The student counter

                //create a delimeter array
                char[] delim = { ',' };

                //open the file 
                inputFile = File.OpenText("grades.csv");

                //create a loop to the read the lines from the file 
                while (!inputFile.EndOfStream) {
                    //Increment the student counter -- In other words each line that is in the file counts as a student
                    count++;
                    line = inputFile.ReadLine();

                    //get the test scores and put them in the array 
                    string[] scores = line.Split(delim);
                    //Set the total to 0 
                    total = 0;

                    //Get the total of the scores -- then get the average
                    foreach (string str in scores) {
                        total += int.Parse(str);
                    }
                    average = (double)total / (scores.Length);

                    //display the averages
                    averagesListBox.Items.Add("Student " + count + "'s average is " + average.ToString("n1"));

                }
                //close the fle 
                inputFile.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Close the application 
            this.Close();
        }
    }
}
