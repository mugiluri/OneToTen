using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneToTen
{
    public partial class Form1 : Form
    {
        string input = string.Empty;        //String storing user input
        double result;                      //Correct answer
        double num01;                       //First variable
        double num02;                       //Second variable
        double answer;                      //Players input
        Char symbol;                        //+-*/ symbols
        int count = 0;                      //Number of questions answered
        int correctCount = 0;               //Correct answers
        double inputValue1;                 //Previous answer
        double inputValue2;                 //Current answer
        private int _ticks;                 //Timer count down after every second
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);
    public  Form1()
        {
            InitializeComponent();
            timer1.Start();
            this.status.Text = "";
          
        }

        public void start_Click(object sender, EventArgs e)     //When next button is clicked
        {
            if (inputValue1 == inputValue2 || count > 14)       //Checks if the player is clicking the Answer button repeatedly
            {
                //Does nothing -- Note: Alternative is to disable the Answer button -- enter.Enabled = false; 
            }
            else
            {
                count++;                                        //Alternative is counting when the answer is correct or wrong(For questions anwered)
                this.textBox5.Text = "";                        //Textbox five is the timer box
                this.textBox5.Text = count.ToString();
            }
            if (count < 15)                                     //Checking on the 15 questions to be answered
            {
                inputValue1 = inputValue2;
                Random numberGenerator = new Random();          //Creating an instance from the Random class
                Random symbolGenerator = new Random();          //"
                num01 = numberGenerator.Next(1, 11);            //Generate random numbers - 1 Min inclusive, 11 Max exclusive 
                num02 = numberGenerator.Next(1, 11);            //"

                int symbolIndex = symbolGenerator.Next(1, 5);   //1 is min inclusive & 5 max exclusive
                switch (symbolIndex)                            //Randomising arithmetic operations
                {
                    case 1:
                        symbol = '+';
                        break;
                    case 2:
                        symbol = '-';
                        break;
                    case 3:
                        symbol = '/';
                        break;
                    default:                                    //Else
                        symbol = '*';
                        break;
                }

                this.textBox1.Text = "";                        //Clears the Question window
                this.textBox2.Text = "";                        //Clears the Answer window
                this.textBox3.Text = "";                        //Clears the info window
                input = num01 + " " + symbol + " " + num02;     //random arithmetic question
                this.textBox3.ForeColor = Color.Blue;           //Changing the color of text
                this.textBox1.Text = input;                     //Asks the random arithmetic question
                enter.Enabled = true;                           //Enable the answer button

            }
            else
            {
                                                                //Does nothing - Next button disabled
            }
        }

        public void enter_Click(object sender, EventArgs e)                                     //When answer button clicked
        {
            if(count < 15)                                                                      //Checking on the 15 questions to be answered
            {
                if (this.textBox1.Text == "" || this.textBox2.Text == "")                       //If either question or answer window is empty
                {
                    if (this.textBox1.Text != "" && this.textBox2.Text == "")
                    {
                        this.textBox3.Text = "";                                                //It's good practice to clear window before printing
                        this.textBox3.ForeColor = Color.Red;                                    //Changing the color of text
                        this.textBox3.Text += "Error 2! You have not answered.";                //Prints on the info window
                    }
                    else
                    {
                        this.textBox3.Text = "";
                        this.textBox3.ForeColor = Color.Red;                                    //Changing the color of text
                        this.textBox3.Text += "Error 1! Please click the NEXT button.";         //Prints on the info window
                    }

                }
                else
                {
                    if (symbol == '+')
                    {
                        result = num01 + num02;
                    }
                    else if (symbol == '-')
                    {
                        result = num01 - num02;
                    }
                    else if (symbol == '/')
                    {
                        result = num01 / num02;
                    }
                    else
                    {
                        result = num01 * num02;
                    }

                    if (!double.TryParse(this.textBox2.Text, out _))                //Tries to convert input to double and returns Error if not Double
                    {
                        this.textBox3.Text = "";
                        this.textBox3.ForeColor = Color.Red;                        //Changing the color of text
                        this.textBox3.Text = "Error 3! You entered a Null value.";
                    }
                    else
                    {
                        answer = Convert.ToDouble(this.textBox2.Text);
                        inputValue2 = answer;
                        if (answer == result)
                        {
                            this.textBox3.Text = "";                                //Printing in the info window
                            this.textBox3.ForeColor = Color.Blue;                   //Changing the color of text
                            this.textBox3.Text += "Correct! ";                      //+= appends data to the end of the existing data
                            this.textBox3.Text += Convert.ToString(result);
                            this.textBox3.Text += " is the right answer.";
                            correctCount++;
                            enter.Enabled = false;                                  //Disable the answer button
                            //count++;
                            //this.textBox5.Text = "";
                            //this.textBox5.Text = count.ToString();
                            //this.textBox3.Text += " Your previous answer was ";
                            //this.textBox3.Text += inputValue1.ToString();
                            //this.textBox3.Text += ". Your current answer is ";
                            //this.textBox3.Text += inputValue2.ToString();

                        }
                        else
                        {
                            this.textBox3.Text = "";                                //Printing in the info window
                            this.textBox3.ForeColor = Color.Blue;                   //Changing the color of text
                            this.textBox3.Text += "That's false. The answer is ";   //+= appends data to the end of the existing data
                            this.textBox3.Text += result;                           //Prints the correct answer without converting
                            this.textBox3.Text += ".";
                            enter.Enabled = false;                                  //Disable the answer button
                            //count++;
                            //this.textBox5.Text = "";
                            //this.textBox5.Text = count.ToString();
                            //this.textBox3.Text += ". Your previous answer was ";
                            //this.textBox3.Text += inputValue1.ToString();
                            //this.textBox3.Text += ". Your current answer is ";
                            //this.textBox3.Text += inputValue2.ToString();
                        }
                    }
                }
            }
            else
            {
                                                                                    //Does nothing - Answer button disabled
            }

        }

        public void textBox4_TextChanged(object sender, EventArgs e)
        {
        
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;                                                       //Timer increases after every 1000 milliseconds
            this.textBox4.Text = _ticks.ToString();                         //Converts ticks to string for it to be dispalay in the timer window
            if(count == 15)                                                 //Counts every time a question is answered
            {
                this.textBox3.Text += " Quiz complete. Hurray!";            //Adds text to the info window
                timer1.Stop();                                              //Stops the counter ate the 15th count
                this.score.Text = "";
                this.score.Text += " Your Score : ";
                double myScore = correctCount * (180.00 / _ticks);          //Calculating score
                this.score.Text += String.Format("{0:0.00}", myScore);      //Prints score in two decimal places
                this.status.Text = "Correct answers : ";
                this.status.Text += correctCount;
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)          //Close icon
        {
            this.Close();                                                   //Closes the window
        }

        private void maximize_Click(object sender, EventArgs e)             //Maximize icon
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;                    //Maximizes window
            }
            else
            {
                WindowState = FormWindowState.Normal;                       //Returns window to normal
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)//Minimize icon
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;//Minimizes window
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
    }
}
