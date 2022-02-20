using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

        }

        private void DOB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int age = UserAge(DOB.SelectedDate.Value);

            if ((age > 135))
            {
                MessageBox.Show("Wrong date of birth");
            }
            else if (DOB.SelectedDate.Value.Year >= DateTime.Today.Year) {
                if (DOB.SelectedDate.Value.Month > DateTime.Today.Month) {
                    if (DOB.SelectedDate.Value.Day > DateTime.Today.Day) { 
                        MessageBox.Show("Person have not been born yet");
                    }
                        
                }
            }
            else if ((DOB.SelectedDate.Value.Day == DateTime.Today.Day) && (DOB.SelectedDate.Value.Month == DateTime.Today.Month))
            {
                AgeUSER.Text = "You are " + age.ToString() + " year(s) old today! HAPPY BIRTHDAY!!!";

            }
            else { AgeUSER.Text = "You are " + age.ToString() + " year(s) old "; }

            Zodiac.Text = "Your zodiac sign is " + ZodiacSign(DOB.SelectedDate.Value);
            Chinese.Text = "Your chinese sign is " + Chinesse(DOB.SelectedDate.Value.Year);
        }

        int UserAge(DateTime a) {
            if (a.Month > DateTime.Today.Month) {
                return DateTime.Today.Year - (a.Year+1);
            }
            else if (a.Month == DateTime.Today.Month) {
                if (a.Day > DateTime.Today.Day) {
                    return DateTime.Today.Year - (a.Year + 1);
                }
            }
            return DateTime.Today.Year - a.Year;
        }

        private void AgeUSER_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AgeUSER.Text = (UserAge(DOB.SelectedDate.Value).ToString());
        }

        string ZodiacSign(DateTime a) {
            int days = a.Day;
            switch (a.Month)
            {
                case 1:
                    if (days >= 1 & days <= 19)
                    {
                        return "Capricorn";
                    }
                    else return "Aquarius";
                case 2:
                    if (days >= 1 & days <= 19) { return "Aquarius"; }
                    else return "Pisces";
                case 3:
                    if (days >= 1 & days <= 20) { return "Pisces"; }
                    else return "Aries";
                case 4:
                    if (days >= 1 & days <= 20) { return "Aries"; }
                    else return "Taurus";
                case 5:
                    if (days >= 1 & days <= 20) { return "Taurus";}
                    else return "Gemini";
                case 6:
                    if (days >= 1 & days <= 20){ return "Gemini";}
                    else return "Cancer";
                case 7:
                    if (days >= 1 & days <= 22){return "Cancer";}
                    else return "Leo";
                case 8:
                    if (days >= 1 & days <= 22){return "Leo";}
                    else return "Virgo";
                case 9:
                    if (days >= 1 & days <= 22){return "Virgo";}
                    else return "Libra";
                case 10:
                    if (days >= 1 & days <= 22){return "Libra";}
                    else return "Scorpio";
                case 11:
                    if (days >= 1 & days <= 22){return "Scorpio";}
                    else return "Sagittarius";
                case 12:
                    if (days >= 1 & days <= 21){return "Sagittarius";}
                    else return "Capricorn";

            }
            return null;
        }

        string Chinesse(int a)
        {
            string[] animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
            int ei = (int)Math.Floor((a - 4.0) % 10 / 2);
            int ai = (a - 4) % 12;
            return animals[ai];
        }



        // root is a Panel that is defined elsewhere.

    }
           
}
