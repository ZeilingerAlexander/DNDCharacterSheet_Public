using DND_CharacterSheet_Zeilinger.ViewModels;
using ReadingAndLoadingFromFiäles05122022;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace DND_CharacterSheet_Zeilinger
{
    internal class Config
    {
        public static string DefaultPath = AppDomain.CurrentDomain.BaseDirectory + @"\Config\default.xyz";
        public static string ItemsPath = AppDomain.CurrentDomain.BaseDirectory + @"\Config\items.json";
        public static string AttacksPath = AppDomain.CurrentDomain.BaseDirectory + @"\Config\attacks.json";
        public static string SpellsPath = AppDomain.CurrentDomain.BaseDirectory + @"Config\spells.json";
        public static void SaveConfig(MainWindowViewModel v)
        {
            FileStream fs = new FileStream(DefaultPath, FileMode.Truncate);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(v.Strength);
                sw.WriteLine(v.Dexterity);
                sw.WriteLine(v.Constituation);
                sw.WriteLine(v.Intelligence);
                sw.WriteLine(v.Wisdom);
                sw.WriteLine(v.Charisma);
                sw.WriteLine(v.ProficiencyBonus);
                sw.WriteLine(v.Prof_Acrobatics);
                sw.WriteLine(v.Prof_AnimalHandling);
                sw.WriteLine(v.Prof_Arcana);
                sw.WriteLine(v.Prof_Athletics);
                sw.WriteLine(v.Prof_Deception);
                sw.WriteLine(v.Prof_History);
                sw.WriteLine(v.Prof_Insight);
                sw.WriteLine(v.Prof_Intimidation);
                sw.WriteLine(v.Prof_Investigation);
                sw.WriteLine(v.Prof_Medicine);
                sw.WriteLine(v.Prof_Nature);
                sw.WriteLine(v.Prof_Perception);
                sw.WriteLine(v.Prof_Performance);
                sw.WriteLine(v.Prof_Persuasion);
                sw.WriteLine(v.Prof_Religion);
                sw.WriteLine(v.Prof_SleightOfHand);
                sw.WriteLine(v.Prof_Stealth);
                sw.WriteLine(v.Prof_Survival);
                sw.WriteLine(v.Sav_Strength);
                sw.WriteLine(v.Sav_Intelligence);
                sw.WriteLine(v.Sav_Dexterity);
                sw.WriteLine(v.Sav_Wisdom);
                sw.WriteLine(v.Sav_Constitution);
                sw.WriteLine(v.Sav_Charisma);
                sw.WriteLine(v.Armor);
                sw.WriteLine(v.Tools);
                sw.WriteLine(v.Weapons);
                sw.WriteLine(v.Languages);
                sw.WriteLine(v.WalkingSpeed);
                sw.WriteLine(v.Inspired);
                sw.WriteLine(v.Hp_Current);
                sw.WriteLine(v.Hp_Max);
                sw.WriteLine(v.Hp_Temp);
                sw.WriteLine(v.Initiative);
                sw.WriteLine(v.ArmorClass);
                sw.WriteLine(v.Defenses);
                sw.WriteLine(v.Conditions);
                sw.WriteLine(v.Advantages);
                sw.WriteLine(v.Name);
                sw.WriteLine(v.Race);
                sw.WriteLine(v.Class);
                sw.WriteLine(v.Alignment);
                sw.WriteLine(v.Background);
                sw.WriteLine(v.EXP);
                sw.WriteLine(v.HitDice);
                sw.WriteLine(v.PlayerName);
                sw.WriteLine(v.Ds_Success1);
                sw.WriteLine(v.Ds_Success2);
                sw.WriteLine(v.Ds_Success3);
                sw.WriteLine(v.Ds_Fail1);
                sw.WriteLine(v.Ds_Fail2);
                sw.WriteLine(v.Ds_Fail3);
                sw.WriteLine(v.Notes);
            }
            JsonLoader.WriteToJsonFile(ItemsPath, v.Items);
            JsonLoader.WriteToJsonFile(AttacksPath, v.Attacks);
            JsonLoader.WriteToJsonFile(SpellsPath, v.Spells);
            Debug.WriteLine("Wrote Config");
        }
        public static void LoadConfig(MainWindowViewModel v)
        {
            try
            {
                FileStream fs = new FileStream(DefaultPath, FileMode.Open);
                using (StreamReader sr = new StreamReader(fs))
                {
                    try
                    {
                        v.Strength = int.Parse(sr.ReadLine());
                        v.Dexterity = int.Parse(sr.ReadLine());
                        v.Constituation = int.Parse(sr.ReadLine());
                        v.Intelligence = int.Parse(sr.ReadLine());
                        v.Wisdom = int.Parse(sr.ReadLine());
                        v.Charisma = int.Parse(sr.ReadLine());
                        v.ProficiencyBonus = int.Parse(sr.ReadLine());
                        v.Prof_Acrobatics = bool.Parse(sr.ReadLine());
                        v.Prof_AnimalHandling = bool.Parse(sr.ReadLine());
                        v.Prof_Arcana = bool.Parse(sr.ReadLine());
                        v.Prof_Athletics = bool.Parse(sr.ReadLine());
                        v.Prof_Deception = bool.Parse(sr.ReadLine());
                        v.Prof_History = bool.Parse(sr.ReadLine());
                        v.Prof_Insight = bool.Parse(sr.ReadLine());
                        v.Prof_Intimidation = bool.Parse(sr.ReadLine());
                        v.Prof_Investigation = bool.Parse(sr.ReadLine());
                        v.Prof_Medicine = bool.Parse(sr.ReadLine());
                        v.Prof_Nature = bool.Parse(sr.ReadLine());
                        v.Prof_Perception = bool.Parse(sr.ReadLine());
                        v.Prof_Performance = bool.Parse(sr.ReadLine());
                        v.Prof_Persuasion = bool.Parse(sr.ReadLine());
                        v.Prof_Religion = bool.Parse(sr.ReadLine());
                        v.Prof_SleightOfHand = bool.Parse(sr.ReadLine());
                        v.Prof_Stealth = bool.Parse(sr.ReadLine());
                        v.Prof_Survival = bool.Parse(sr.ReadLine());
                        v.Sav_Strength = bool.Parse(sr.ReadLine());
                        v.Sav_Intelligence = bool.Parse(sr.ReadLine());
                        v.Sav_Dexterity = bool.Parse(sr.ReadLine());
                        v.Sav_Wisdom = bool.Parse(sr.ReadLine());
                        v.Sav_Constitution = bool.Parse(sr.ReadLine());
                        v.Sav_Charisma = bool.Parse(sr.ReadLine());
                        v.Armor = sr.ReadLine();
                        v.Tools = sr.ReadLine();
                        v.Weapons = sr.ReadLine();
                        v.Languages = sr.ReadLine();
                        v.WalkingSpeed = int.Parse(sr.ReadLine());
                        v.Inspired = bool.Parse(sr.ReadLine());
                        v.Hp_Current = int.Parse(sr.ReadLine());
                        v.Hp_Max = int.Parse(sr.ReadLine());
                        v.Hp_Temp = int.Parse(sr.ReadLine());
                        v.Initiative = int.Parse(sr.ReadLine());
                        v.ArmorClass = int.Parse(sr.ReadLine());
                        v.Defenses = sr.ReadLine();
                        v.Conditions = sr.ReadLine();
                        v.Advantages = sr.ReadLine();
                        v.Name = sr.ReadLine();
                        v.Race = sr.ReadLine();
                        v.Class = sr.ReadLine();
                        v.Alignment = sr.ReadLine();
                        v.Background = sr.ReadLine();
                        v.EXP = int.Parse(sr.ReadLine());
                        v.HitDice = sr.ReadLine();
                        v.PlayerName = sr.ReadLine();
                        v.Ds_Success1 = bool.Parse(sr.ReadLine());
                        v.Ds_Success2 = bool.Parse(sr.ReadLine());
                        v.Ds_Success3 = bool.Parse(sr.ReadLine());
                        v.Ds_Fail1 = bool.Parse(sr.ReadLine());
                        v.Ds_Fail2 = bool.Parse(sr.ReadLine());
                        v.Ds_Fail3 = bool.Parse(sr.ReadLine());
                        v.Notes = sr.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        MessageBox.Show("Failed to read Config, Config File Depricated.");
                    }
                }
                v.Items = JsonLoader.ReadFromJsonFile<ObservableCollection<MainWindowViewModel.Item>>(ItemsPath);
                v.Attacks = JsonLoader.ReadFromJsonFile<ObservableCollection<MainWindowViewModel.Attack>>(AttacksPath);
                v.Spells = JsonLoader.ReadFromJsonFile<ObservableCollection<MainWindowViewModel.Spell>>(SpellsPath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Failed to load Config, make sure you have saved at least once");
            }
        }
    }
}
