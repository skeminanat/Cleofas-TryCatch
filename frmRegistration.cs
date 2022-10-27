using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace OrganizationProfile
{
    
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        private bool test;
        
        public frmRegistration()
        {
            InitializeComponent();
             
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
            "BS Information Technology",
            "BS Computer Science",
            "BS Information Systems",
            "BS in Accountancy",
            "BS in Hospitality Management",
            "BS in Tourism Management"

            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
        }
        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);
                test = true;
            }catch(FormatException fe)
            {
                MessageBox.Show(fe.Message);
                test = false;
            }
          
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new OverflowException();
                }
            }catch (OverflowException oe)
            {
                MessageBox.Show(oe.Message);
                test = false;
            }
            
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }
                else
                {
                    throw new FormatException();
                }
            }catch(FormatException fe)
            {
                MessageBox.Show(fe.Message);
                test = false;
            }

            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }
                else
                {
                    throw new FormatException();
                }
            }catch (FormatException fe)
            {
                MessageBox.Show("Invalid Input");
                test = false;
            }

            return _Age;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            StudentInformationClass.setFullName = FullName(txtLastName.Text,
           txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
            StudentInformationClass.setProgram = cbPrograms.Text;
            StudentInformationClass.setGender = cbGender.Text;
            StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
            StudentInformationClass.setAge = Age(txtAge.Text);
            StudentInformationClass.setBirthday = datePickerBirtday.Value.ToString("yyyy-MM-dd");

                if (test == true)
                {
                frmConfirmation frm = new frmConfirmation();
                frm.Show();
                }
                
            
        }
    }
}
