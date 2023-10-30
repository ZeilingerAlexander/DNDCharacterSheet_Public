using DND_CharacterSheet_Zeilinger;
using DND_CharacterSheet_Zeilinger.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfTestingObjectLiterals121222022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainView = new MainWindowViewModel();
        OpenFileDialog openFileDialog = new();
        SaveFileDialog saveFileDialog = new();
        public MainWindow()
        {
            InitializeComponent();
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Config"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\Config");
            }
            if (!File.Exists(Config.DefaultPath))
            {
                File.Create(Config.DefaultPath);
            }
            DataContext = mainView;
        }
        #region Dice Roller
        private void diceplus_Click(object sender, RoutedEventArgs e)
        {
            diceErgebnisse.Children.Clear();
            List<string> Ergebnisse = new List<string>();
            try
            {
                // Checking if textbox is empty
                if (DiceMathNum.Text == "" || DiceMathNum.Text == null)
                    DiceMathNum.Text = "0";
                // Math itself
                for (int i = 0; i < int.Parse(DiceAmount.Text); i++)
                {
                    Ergebnisse.Add("1d" + DiceNumber.Text + " = " + (rnd.Next(int.Parse(DiceNumber.Text) + 1) + int.Parse(DiceMathNum.Text)).ToString());
                }
                // Output
                foreach (string str in Ergebnisse)
                {
                    diceErgebnisse.Children.Add(new TextBlock { Text = str });
                }
            }
            catch (Exception)
            { MessageBox.Show("Something went horribly wrong while trying to roll some simple dices..."); }
        }
        private void diceminus_Click(object sender, RoutedEventArgs e)
        {
            diceErgebnisse.Children.Clear();
            List<string> Ergebnisse = new List<string>();
            try
            {
                // Checking if textbox is empty
                if (DiceMathNum.Text == "" || DiceMathNum.Text == null)
                    DiceMathNum.Text = "0";
                // Math itself
                for (int i = 0; i < int.Parse(DiceAmount.Text); i++)
                {
                    Ergebnisse.Add("1d" + DiceNumber.Text + " = " + (rnd.Next(int.Parse(DiceNumber.Text) + 1) - int.Parse(DiceMathNum.Text)).ToString());
                }
                // Output
                foreach (string str in Ergebnisse)
                {
                    diceErgebnisse.Children.Add(new TextBlock { Text = str });
                }
            }
            catch (Exception)
            { MessageBox.Show("Something went horribly wrong while trying to roll some simple dices..."); }
        }
        private void dicedivide_Click(object sender, RoutedEventArgs e)
        {
            diceErgebnisse.Children.Clear();
            List<string> Ergebnisse = new List<string>();
            try
            {
                // Checking if textbox is empty
                if (DiceMathNum.Text == "" || DiceMathNum.Text == null)
                    DiceMathNum.Text = "0";
                // Math itself
                for (int i = 0; i < int.Parse(DiceAmount.Text); i++)
                {
                    Ergebnisse.Add("1d" + DiceNumber.Text + " = " + (rnd.Next(int.Parse(DiceNumber.Text) + 1) / int.Parse(DiceMathNum.Text)).ToString());
                }
                // Output
                foreach (string str in Ergebnisse)
                {
                    diceErgebnisse.Children.Add(new TextBlock { Text = str });
                }
            }
            catch (Exception)
            { MessageBox.Show("Something went horribly wrong while trying to roll some simple dices..."); }
        }
        private void dicemultiply_Click(object sender, RoutedEventArgs e)
        {
            diceErgebnisse.Children.Clear();
            List<string> Ergebnisse = new List<string>();
            try
            {
                // Checking if textbox is empty
                if (DiceMathNum.Text == "" || DiceMathNum.Text == null)
                    DiceMathNum.Text = "0";
                // Math itself
                for (int i = 0; i < int.Parse(DiceAmount.Text); i++)
                {
                    Ergebnisse.Add("1d" + DiceNumber.Text + " = " + (rnd.Next(int.Parse(DiceNumber.Text) + 1) * int.Parse(DiceMathNum.Text)).ToString());
                }
                // Output
                foreach (string str in Ergebnisse)
                {
                    diceErgebnisse.Children.Add(new TextBlock { Text = str });
                }
            }
            catch (Exception)
            { MessageBox.Show("Something went horribly wrong while trying to roll some simple dices..."); }
        }
        private void diceequals_Click(object sender, RoutedEventArgs e)
        {
            diceErgebnisse.Children.Clear();
            List<string> Ergebnisse = new List<string>();
            try
            {
                // Math itself
                for (int i = 0; i < int.Parse(DiceAmount.Text); i++)
                {
                    Ergebnisse.Add("1d" + DiceNumber.Text + " = " + rnd.Next(int.Parse(DiceNumber.Text) + 1).ToString());
                }
                // Output
                foreach (string str in Ergebnisse)
                {
                    diceErgebnisse.Children.Add(new TextBlock { Text = str });
                }
            }
            catch (Exception)
            { MessageBox.Show("Something went horribly wrong while trying to roll some simple dices..."); }
        }
        /// <summary>
        /// On CLick D20s
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollD20Check(object sender, MouseButtonEventArgs e)
        {
            // Creating a new Textblock that matches the original one so we can get the text aka the number to roll from here!
            int num = 0;
            try
            {
                num = int.Parse(((TextBlock)e.OriginalSource).Text);
            }
            catch (Exception) { MessageBox.Show("Something doesnt seem quite right..."); }
            // After setting the number into an int we can use we roll the dice by clearing the ergebnis box and then adding a new dice to it
            diceErgebnisse.Children.Clear();
            try
            {
                // Im such an idiot why did i write this so overcomplicated... well below is the real one that works by just getting the values for the children element from e+#

                // Just Info about the roll displayed above, it removes some of it so it gets the display name of the info text block instead of the real name
                diceErgebnisse.Children.Add(new TextBlock { Text = GetName(e.OriginalSource).Replace("SkillBonus", "") + "_Check" });
                // The if is to check if the number is negative if it is it removes the + for it to look good, in the first if it also checks if its equal so when its 0 it says + instead of -
                if (num * -1 <= num)
                    diceErgebnisse.Children.Add(new TextBlock { Text = "1d20" + "+" + num.ToString() + " = " + (rnd.Next(21) + num).ToString() });
                else
                    diceErgebnisse.Children.Add(new TextBlock { Text = "1d20" + num.ToString() + " = " + (rnd.Next(21) + num).ToString() });
                {
                    //// Then we just check all the possible Outcomes
                    //switch (GetName(e.OriginalSource))
                    //{
                    //    {
                    //    //case "SkillBonusAcrobatics": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusAcrobatics.Text)).ToString() }); break;
                    //    //case "SkillBonusAnimalHandling": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusAnimalHandling.Text)).ToString() }); break;
                    //    //case "SkillBonusArcana": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusArcana.Text)).ToString() }); break;
                    //    //case "SkillBonusAthletics": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusAthletics.Text)).ToString() }); break;
                    //    //case "SkillBonusDeception": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusDeception.Text)).ToString() }); break;
                    //    //case "SillBonusHistory": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SillBonusHistory.Text)).ToString() }); break;
                    //    //case "SkillBonusInsight": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusInsight.Text)).ToString() }); break;
                    //    //case "SkillBonusIntimidation": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusIntimidation.Text)).ToString() }); break;
                    //    //case "SkillBonusInvestigation": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusInvestigation.Text)).ToString() }); break;
                    //    //case "SkillBonusMedicine": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusMedicine.Text)).ToString() }); break;
                    //    //case "SkillBonusNature": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusNature.Text)).ToString() }); break;
                    //    //case "SkillBonusPerception": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusPerception.Text)).ToString() }); break;
                    //    //case "SkillBonusPerformance": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusPerformance.Text)).ToString() }); break;
                    //    //case "SkillBonusPersuasion": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusPersuasion.Text)).ToString() }); break;
                    //    //case "SkillBonusReligion": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusReligion.Text)).ToString() }); break;
                    //    //case "SkillBonusSleightofHand": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusSleightofHand.Text)).ToString() }); break;
                    //    //case "SkillBonusStealth": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusStealth.Text)).ToString() }); break;
                    //    //case "SkillBonusSurvival": diceErgebnisse.Children.Add(new TextBlock { Text = "1d20 = " + (rnd.Next(21) + int.Parse(SkillBonusSurvival.Text)).ToString() }); break;
                    //}
                }
            }
            catch (Exception)
            { diceErgebnisse.Children.Add(new TextBlock { Text = "Something went wrong" }); }
        }
        /// <summary>
        /// Same as RollD20Check but for saving throws
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollD20SavingThrow(object sender, MouseButtonEventArgs e)
        {
            // Creating a new Textblock that matches the original one so we can get the text aka the number to roll from here!
            int num = 0;
            try
            {
                num = int.Parse(((TextBlock)e.OriginalSource).Text);
            }
            catch (Exception) { MessageBox.Show("Something doesnt seem quite right..."); }
            // After setting the number into an int we can use we roll the dice by clearing the ergebnis box and then adding a new dice to it
            diceErgebnisse.Children.Clear();
            try
            {
                // Just Info about the roll displayed above, it removes some of it so it gets the display name of the info text block instead of the real name
                diceErgebnisse.Children.Add(new TextBlock { Text = GetName(e.OriginalSource).Replace("Save", "") + "_Save" });
                // The if is to check if the number is negative if it is it removes the + for it to look good, in the first if it also checks if its equal so when its 0 it says + instead of -
                if (num * -1 <= num)
                    diceErgebnisse.Children.Add(new TextBlock { Text = "1d20" + "+" + num.ToString() + " = " + (rnd.Next(21) + num).ToString() });
                else
                    diceErgebnisse.Children.Add(new TextBlock { Text = "1d20" + num.ToString() + " = " + (rnd.Next(21) + num).ToString() });
            }
            catch (Exception)
            { diceErgebnisse.Children.Add(new TextBlock { Text = "Something went wrong" }); }
        }
        #endregion
        #region Utility Stuff
        /// <summary>
        /// This shi just gets the name of an object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetName(object obj)
        {
            // First see if it is a FrameworkElement
            var element = obj as FrameworkElement;
            if (element != null)
                return element.Name;
            // If not, try reflection to get the value of a Name property.
            try { return (string)obj.GetType().GetProperty("Name").GetValue(obj, null); }
            catch
            {
                // Last of all, try reflection to get the value of a Name field.
                try { return (string)obj.GetType().GetField("Name").GetValue(obj); }
                catch { return null; }
            }
        }
        static Random rnd = new Random();

        // Helps with deleting Items from Inv
        /// <summary>
        /// Finds the Visual Parent
        /// </summary>
        public static class GTVisualTreeHelper
        {
            //Finds the visual parent.
            public static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
            {
                if (child == null)
                {
                    return (null);
                }

                //get parent item
                DependencyObject parentObj = VisualTreeHelper.GetParent(child);

                //we've reached the end of the tree
                if (parentObj == null) return null;

                // check if the parent matches the type we are requested
                T parent = parentObj as T;

                if (parent != null)
                {
                    return parent;
                }
                else
                {
                    // here, To find the next parent in the tree. we are using recursion until we found the requested type or reached to the end of tree.
                    return FindVisualParent<T>(parentObj);
                }
            }
        }
        #endregion
    }
}
