using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*Check that there is sufficient data to perform a calculation
Calculate the volume of the shipping container
Determine the multiplier
Calculate the total cost
Display the cost to the user
Postal Calculator

Business Rule 1: Accept width, height and optionally the length of a parcel.  Accept the shipping method - Ground, Air, Next Day.

Business Rule 2: Once you have the minimum amount of information you need, produce a result on screen.  The result will be the volume of the package (width * height and optionally * length) multiplied by the "multiplier" for each shipping method.

Ground: .15 multiplier
Air: .25 multiplier
Next Day: .45

Non-Functional Requirement 1: You must name the project ChallengePostalCalculatorHelperMethods.

Non-Functional Requirement 2: You must use methods.  Each method must do one thing and do it well.  
*/
namespace ChallengPostalCalculatrHelperMethod
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            performChanged();
        }

/*private double calculate(string WidthTextbox, string HeigthTextbox, string LengthTextbox, double addMulti, int length = 0)
        {

            if (lengthTextBox.Text.Trim().Length == 0)
            {

                int width = int.Parse(WidthTextbox);
                int height = int.Parse(HeigthTextbox);
                double mutiplier = width * height;
                mutiplier *= addMulti;
                return mutiplier;

            }
            else
            {
                int width = int.Parse(WidthTextbox);
                int height = int.Parse(HeigthTextbox);
                length += int.Parse(LengthTextbox);
                double mutiplier = width * height * length;
                mutiplier *= addMulti;
                return mutiplier;

            }


        }*/
        private void performChanged()
        {
            //Do the values in the textboxes and checkboxes exist
             if (!valuesExist()) return;

            //What is the volume?
            int volume = 0;
            if (!tryGetvolume(out volume)) return;//This tryGetVolume() method will eventually evaluate whether or not the text can be parsed to an int. It will return true if it can, and false if it cannot. If it returns false, then we will return out of the performChanged() method.

            //What is the multiplier?
            double postageMultiplier = getPostageMultiplier();

            //what is the cost?
            double cost = volume * postageMultiplier;

            // show the user
            resultLabel.Text = string.Format("Your parcel will cost: {0:C} to ship.", cost);
        }

        private double getPostageMultiplier()
        {
            if (groundRadioButton.Checked) return .15;
           else if (airRadioButton.Checked) return .25;
           else if (nextDayRadioButton.Checked) return.45;
           else return 0;
        }

        private bool tryGetvolume(out int volume)
        {
            volume = 0;
            int width = 0;
            int height = 0;
            int length = 0;
            //Next, we’ll work with the tryGetVolume() method stub we generated. What we need to do is determine if the values the user input can be converted to integers. To do this, we’ll create integers for width, height and length, each set to 0. Then, we can use several conditional checks, each checking if(!int.TryParse()) for each for each of the TextBoxes, with the output being set to the appropriate variable (width, height or length). If width or height cannot be parsed, we’ll return false. If length cannot be parsed, we will set length equal to 1, because it is an optional value. If all those conditional checks go through, we’ll return true:
            if (!int.TryParse(widthTextBox.Text.Trim(), out width)) return false;
            if (!int.TryParse(heightTextBox.Text.Trim(), out height)) return false;
            if (!int.TryParse(lengthTextBox.Text.Trim(), out length)) length = 1;
            volume = width * height * length;
            return true;
            
        }

        private bool valuesExist()
        {
            if (!groundRadioButton.Checked
                && !airRadioButton.Checked
                && !nextDayRadioButton.Checked)
                return false;
            if (widthTextBox.Text.Trim().Length == 0
                || heightTextBox.Text.Trim().Length == 0)
                return false;

            return true;
        }
        //At this point, your code is fully functional and meets the requirement set out in the challenge. However, we can still make it better. When you think about it, why should we need six different events all calling the exact same method? There is a way around this. What we can do is create a new event called handleChange:
        //Now, you can delete all the EventHandlers that we previously had. What we’ll now do is go back into the properties for each server control, and instead of having the event register where it previously did, we can change it to handleChange:
        protected void handleChange(object sender, EventArgs e)
        {

            // resultLabel.Text = string.Format("Ground shipping fee:{0}", calculate(widthTextBox.Text, heightTextBox.Text, lengthTextBox.Text,  0.15)) ;
            performChanged();

            //  resultLabel.Text= string.Format("Air shipping fee:{0}", calculate(widthTextBox.Text, heightTextBox.Text, lengthTextBox.Text,  0.25));
            // performChanged(); 

            // resultLabel.Text =string.Format("Next Day shipping fee:{0}", calculate(widthTextBox.Text, heightTextBox.Text, lengthTextBox.Text,  0.45));
            // performChanged();
        }

        
    }
       
    }
