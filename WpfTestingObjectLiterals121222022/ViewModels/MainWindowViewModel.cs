using MVCWpfRechner.Commands;
using MVCWpfRechner.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DND_CharacterSheet_Zeilinger.ViewModels
{
    public delegate void emptyDelegate();
    internal class MainWindowViewModel : BaseViewModel
    {
        #region structs
        internal struct Item
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Amount { get; set; }
            public double Weight { get; set; }
        }
        internal struct Spell
        {
            public string Name { get; set; }
            public int Range { get; set; }
            public string HitDC { get; set; }
            public int Damage { get; set; }
            public string Notes { get; set; }
            public int Time { get; set; }
            public int Level { get; set; }
        }
        internal struct Attack
        {
            public string Name { get; set; }
            public int Range { get; set; }
            public string HitDC { get; set; }
            public int Damage { get; set; }
            public string Notes { get; set; }
        }
        #endregion
        #region Variables
        #region main values
        private int _strength;
        public int Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                Recalculate();
                OnPropertyChanged(nameof(Strength));
            }
        }
        private int _dexterity;
        public int Dexterity
        {
            get { return _dexterity; }
            set
            {
                _dexterity = value;
                Recalculate();
                OnPropertyChanged(nameof(Dexterity));
            }
        }
        private int _constitution;
        public int Constituation
        {
            get { return _constitution; }
            set
            {
                _constitution = value;
                Recalculate();
                OnPropertyChanged(nameof(Constituation));
            }
        }
        private int _intelligence;
        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                _intelligence = value;
                Recalculate();
                OnPropertyChanged(nameof(Intelligence));
            }
        }

        private int _wisdom;
        public int Wisdom
        {
            get { return _wisdom; }
            set
            {
                _wisdom = value;
                Recalculate();
                OnPropertyChanged(nameof(Wisdom));
            }
        }

        private int _charisma;
        public int Charisma
        {
            get { return _charisma; }
            set
            {
                _charisma = value;
                Recalculate();
                OnPropertyChanged(nameof(Charisma));
            }
        }
        #endregion
        #region proficiency
        private int _proficiencyBonus;
        public int ProficiencyBonus
        {
            get
            {
                return _proficiencyBonus;
            }
            set
            {
                _proficiencyBonus = value;
                Recalculate();
                OnPropertyChanged(nameof(ProficiencyBonus));
            }
        }

        private bool _prof_Acrobatics;
        public bool Prof_Acrobatics
        {
            get
            {
                return _prof_Acrobatics;
            }
            set
            {
                _prof_Acrobatics = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Acrobatics));
            }
        }
        private bool _prof_AnimalHandling;
        public bool Prof_AnimalHandling
        {
            get { return _prof_AnimalHandling; }
            set
            {
                _prof_AnimalHandling = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_AnimalHandling));
            }
        }

        private bool _prof_Arcana;
        public bool Prof_Arcana
        {
            get { return _prof_Arcana; }
            set
            {
                _prof_Arcana = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Arcana));
            }
        }

        private bool _prof_Athletics;
        public bool Prof_Athletics
        {
            get { return _prof_Athletics; }
            set
            {
                _prof_Athletics = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Athletics));
            }

        }

        private bool _prof_Deception;
        public bool Prof_Deception
        {
            get { return _prof_Deception; }
            set
            {
                _prof_Deception = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Deception));
            }

        }

        private bool _prof_History;
        public bool Prof_History
        {
            get { return _prof_History; }
            set
            {
                _prof_History = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_History));
            }

        }

        private bool _prof_Insight;
        public bool Prof_Insight
        {
            get { return _prof_Insight; }
            set
            {
                _prof_Insight = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Insight));
            }

        }

        private bool _prof_Intimidation;
        public bool Prof_Intimidation
        {
            get { return _prof_Intimidation; }
            set
            {
                _prof_Intimidation = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Intimidation));
            }

        }

        private bool _prof_Investigation;
        public bool Prof_Investigation
        {
            get { return _prof_Investigation; }
            set
            {
                _prof_Investigation = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Investigation));
            }

        }

        private bool _prof_Medicine;
        public bool Prof_Medicine
        {
            get { return _prof_Medicine; }
            set
            {
                _prof_Medicine = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Medicine));
            }

        }

        private bool _prof_Nature;
        public bool Prof_Nature
        {
            get { return _prof_Nature; }
            set
            {
                _prof_Nature = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Nature));
            }

        }

        private bool _prof_Perception;
        public bool Prof_Perception
        {
            get { return _prof_Perception; }
            set
            {
                _prof_Perception = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Perception));
            }

        }

        private bool _prof_Performance;
        public bool Prof_Performance
        {
            get { return _prof_Performance; }
            set
            {
                _prof_Performance = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Performance));
            }

        }

        private bool _prof_Persuasion;
        public bool Prof_Persuasion
        {
            get { return _prof_Persuasion; }
            set
            {
                _prof_Persuasion = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Persuasion));
            }

        }

        private bool _prof_Religion;
        public bool Prof_Religion
        {
            get { return _prof_Religion; }
            set
            {
                _prof_Religion = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Religion));
            }

        }

        private bool _prof_SleightOfHand;
        public bool Prof_SleightOfHand
        {
            get { return _prof_SleightOfHand; }
            set
            {
                _prof_SleightOfHand = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_SleightOfHand));
            }

        }

        private bool _prof_Stealth;
        public bool Prof_Stealth
        {
            get { return _prof_Stealth; }
            set
            {
                _prof_Stealth = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Stealth));
            }

        }

        private bool _prof_Survival;
        public bool Prof_Survival
        {
            get { return _prof_Survival; }
            set
            {
                _prof_Survival = value;
                Recalculate();
                OnPropertyChanged(nameof(Prof_Survival));
            }
        }
        #endregion
        #region saving throws
        private bool _sav_Strength;
        public bool Sav_Strength
        {
            get
            {
                return _sav_Strength;
            }
            set
            {
                _sav_Strength = value;
                Recalculate();
                OnPropertyChanged(nameof(Sav_Strength));
            }
        }
        private bool _sav_Intelligence;
        public bool Sav_Intelligence
        {
            get { return _sav_Intelligence; }
            set
            {
                _sav_Intelligence = value;
                Recalculate();
                OnPropertyChanged(nameof(Sav_Intelligence));
            }
        }

        private bool _sav_Dexterity;
        public bool Sav_Dexterity
        {
            get { return _sav_Dexterity; }
            set
            {
                _sav_Dexterity = value;
                Recalculate();
                OnPropertyChanged(nameof(Sav_Dexterity));
            }
        }

        private bool _sav_Wisdom;
        public bool Sav_Wisdom
        {
            get { return _sav_Wisdom; }
            set
            {
                _sav_Wisdom = value;
                Recalculate();
                OnPropertyChanged(nameof(Sav_Wisdom));
            }
        }

        private bool _sav_Constitution;
        public bool Sav_Constitution
        {
            get { return _sav_Constitution; }
            set
            {
                _sav_Constitution = value;
                Recalculate();
                OnPropertyChanged(nameof(Sav_Constitution));
            }
        }

        private bool _sav_Charisma;
        public bool Sav_Charisma
        {
            get { return _sav_Charisma; }
            set
            {
                _sav_Charisma = value;
                Recalculate();
                OnPropertyChanged(nameof(Sav_Charisma));
            }
        }
        #endregion
        #region useless info
        private string _armor;
        public string Armor
        {
            get
            {
                return _armor;
            }
            set
            {
                _armor = value;
                OnPropertyChanged(nameof(Armor));
            }
        }
        private string _weapons;
        public string Weapons
        {
            get { return _weapons; }
            set
            {
                _weapons = value;
                OnPropertyChanged(nameof(Weapons));
            }
        }

        private string _tools;
        public string Tools
        {
            get { return _tools; }
            set
            {
                _tools = value;
                OnPropertyChanged(nameof(Tools));
            }
        }

        private string _languages;
        public string Languages
        {
            get { return _languages; }
            set
            {
                _languages = value;
                OnPropertyChanged(nameof(Languages));
            }
        }
        private int _walkingSpeed;
        public int WalkingSpeed
        {
            get
            {
                return _walkingSpeed;
            }
            set
            {
                _walkingSpeed = value;
                OnPropertyChanged(nameof(WalkingSpeed));
            }
        }

        private bool _inspired;
        public bool Inspired
        {
            get
            {
                return _inspired;
            }
            set
            {
                _inspired = value;
                OnPropertyChanged(nameof(Inspired));
            }
        }

        private int _hp_Current;
        public int Hp_Current
        {
            get
            {
                return _hp_Current;
            }
            set
            {
                _hp_Current = value;
                OnPropertyChanged(nameof(Hp_Current));
            }
        }
        private int _hp_Max;
        public int Hp_Max
        {
            get { return _hp_Max; }
            set
            {
                _hp_Max = value;
                OnPropertyChanged(nameof(Hp_Max));
            }
        }

        private int _hp_Temp;
        public int Hp_Temp
        {
            get { return _hp_Temp; }
            set
            {
                _hp_Temp = value;
                OnPropertyChanged(nameof(Hp_Temp));
            }
        }
        private int _initiative;
        public int Initiative
        {
            get { return _initiative; }
            set
            {
                _initiative = value;
                OnPropertyChanged(nameof(Initiative));
            }
        }

        private int _armorClass;
        public int ArmorClass
        {
            get { return _armorClass; }
            set
            {
                _armorClass = value;
                OnPropertyChanged(nameof(ArmorClass));
            }
        }

        private string _defenses;
        public string Defenses
        {
            get { return _defenses; }
            set
            {
                _defenses = value;
                OnPropertyChanged(nameof(Defenses));
            }
        }

        private string _conditions;
        public string Conditions
        {
            get { return _conditions; }
            set
            {
                _conditions = value;
                OnPropertyChanged(nameof(Conditions));
            }
        }

        private string _advantages;
        public string Advantages
        {
            get { return _advantages; }
            set
            {
                _advantages = value;
                OnPropertyChanged(nameof(Advantages));
            }
        }
        #endregion
        #region Character Information
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _race;
        public string Race
        {
            get { return _race; }
            set
            {
                _race = value;
                OnPropertyChanged(nameof(Race));
            }

        }

        private string _class;
        public string Class
        {
            get { return _class; }
            set
            {
                _class = value;
                OnPropertyChanged(nameof(Class));
            }
        }

        private string _alignment;
        public string Alignment
        {
            get { return _alignment; }
            set
            {
                _alignment = value;
                OnPropertyChanged(nameof(Alignment));
            }

        }

        private string _background;
        public string Background
        {
            get { return _background; }
            set
            {
                _background = value;
                OnPropertyChanged(nameof(Background));
            }
        }

        private int _exp;
        public int EXP
        {
            get { return _exp; }
            set
            {
                _exp = value;
                OnPropertyChanged(nameof(EXP));
            }
        }

        private string _hitDice;
        public string HitDice
        {
            get { return _hitDice; }
            set
            {
                _hitDice = value;
                OnPropertyChanged(nameof(HitDice));
            }
        }

        private string _playerName;
        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                _playerName = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }

        private bool _ds_success1;
        public bool Ds_Success1
        {
            get { return _ds_success1; }
            set
            {
                _ds_success1 = value;
                OnPropertyChanged(nameof(Ds_Success1));
            }
        }

        private bool _ds_success2;
        public bool Ds_Success2
        {
            get { return _ds_success2; }
            set
            {
                _ds_success2 = value;
                OnPropertyChanged(nameof(Ds_Success2));
            }
        }

        private bool _ds_success3;
        public bool Ds_Success3
        {
            get { return _ds_success3; }
            set
            {
                _ds_success3 = value;
                OnPropertyChanged(nameof(Ds_Success3));
            }

        }

        private bool _ds_fail1;
        public bool Ds_Fail1
        {
            get { return _ds_fail1; }
            set
            {
                _ds_fail1 = value;
                OnPropertyChanged(nameof(Ds_Fail1));
            }
        }

        private bool _ds_fail2;
        public bool Ds_Fail2
        {
            get { return _ds_fail2; }
            set
            {
                _ds_fail2 = value;
                OnPropertyChanged(nameof(Ds_Fail2));
            }
        }

        private bool _ds_fail3;
        public bool Ds_Fail3
        {
            get { return _ds_fail3; }
            set
            {
                _ds_fail3 = value;
                OnPropertyChanged(nameof(Ds_Fail3));
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }
        #endregion
        #region Items

        private string _itemCurrent_Name;
        public string ItemCurrent_Name
        {
            get => _itemCurrent_Name;
            set
            {
                _itemCurrent_Name = value;
                OnPropertyChanged(nameof(ItemCurrent_Name));
                _addItemCmd.RaiseCanExecuteChanged();
            }
        }
        private string _itemCurrent_Description;
        public string ItemCurrent_Description
        {
            get { return _itemCurrent_Description; }
            set
            {
                _itemCurrent_Description = value;
                OnPropertyChanged(nameof(ItemCurrent_Description));
                _addItemCmd.RaiseCanExecuteChanged();
            }
        }

        private int _itemCurrent_Amount;
        public int ItemCurrent_Amount
        {
            get { return _itemCurrent_Amount; }
            set
            {
                _itemCurrent_Amount = value;
                OnPropertyChanged(nameof(ItemCurrent_Amount));
                _addItemCmd.RaiseCanExecuteChanged();
            }
        }

        private double _itemCurrent_Weight;
        public double ItemCurrent_Weight
        {
            get { return _itemCurrent_Weight; }
            set
            {
                _itemCurrent_Weight = value;
                OnPropertyChanged(nameof(ItemCurrent_Weight));
                _addItemCmd.RaiseCanExecuteChanged();
            }
        }

        private double _itemTotalAmount;

        public double ItemTotalAmount
        {
            get { return _itemTotalAmount; }
            set
            {
                _itemTotalAmount = value; OnPropertyChanged(nameof(ItemTotalAmount));
            }
        }

        private double _itemTotalWeight;

        public double ItemTotalWeight
        {
            get { return _itemTotalWeight; }
            set
            {
                _itemTotalWeight = value;
                OnPropertyChanged(nameof(ItemTotalWeight));
            }
        }

        private Item _selectedItem;
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                IsItemSelected = true;
                _delItemCmd.RaiseCanExecuteChanged();
            }
        }
        private bool _isItemSelected;
        private bool IsItemSelected
        {
            get => _isItemSelected;
            set
            {
                _isItemSelected = value;
                _delItemCmd.RaiseCanExecuteChanged();
            }
        }
        public RelayCommand _addItemCmd;
        public ICommand AddItemCMD { get { return _addItemCmd; } }
        /// <summary>
        /// Takes entries from ItemCurrent_ and ups the total amounts and weights on end
        /// </summary>
        public void AddItem()
        {
            if (Items.Any(i => i.Name == ItemCurrent_Name && i.Description == ItemCurrent_Description && i.Weight == ItemCurrent_Weight))
            {
                // Item already exists in the inventory so overwrite it with a new item that has the same properties but up its amount
                Item existingItem = Items.First(i => i.Name == ItemCurrent_Name && i.Description == ItemCurrent_Description && i.Weight == ItemCurrent_Weight);
                Items[Items.IndexOf(existingItem)] = new Item()
                {
                    Name = existingItem.Name,
                    Description = existingItem.Description,
                    Weight = existingItem.Weight,
                    Amount = ItemCurrent_Amount + existingItem.Amount
                };
            }
            else
            {
                Items.Add(new Item()
                {
                    Name = ItemCurrent_Name,
                    Description = ItemCurrent_Description,
                    Amount = ItemCurrent_Amount,
                    Weight = ItemCurrent_Weight
                });
            }
            CalulateTotalWeightAndAmount();
        }
        private RelayCommand _delItemCmd;
        public ICommand DelItemCMD { get { return _delItemCmd; } }
        public void DelItem()
        {
            Items.Remove(SelectedItem);
            IsItemSelected = false;
            CalulateTotalWeightAndAmount();
        }
        /// <summary>
        /// Calculates the total weight and Amount of all items
        /// </summary>
        private void CalulateTotalWeightAndAmount()
        {
            double NewTotalAmount = 0;
            double NewTotalWeight = 0;
            foreach (Item i in Items)
            {
                NewTotalAmount += i.Amount;
                NewTotalWeight += i.Weight * i.Amount;
            }
            ItemTotalAmount = NewTotalAmount;
            ItemTotalWeight = NewTotalWeight;
        }

        #endregion
        #region Attacks
        private string _attackCurrent_Name;
        public string AttackCurrent_Name
        {
            get => _attackCurrent_Name;
            set
            {
                _attackCurrent_Name = value;
                _addAttackCMD.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(AttackCurrent_Name));
            }
        }

        private int _attackCurrent_Range;
        public int AttackCurrent_Range
        {
            get { return _attackCurrent_Range; }
            set
            {
                _attackCurrent_Range = value;
                OnPropertyChanged(nameof(AttackCurrent_Range));
            }
        }

        private string _attackCurrent_HitDC;
        public string AttackCurrent_HitDC
        {
            get { return _attackCurrent_HitDC; }
            set
            {
                _attackCurrent_HitDC = value;
                _addAttackCMD.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(AttackCurrent_HitDC));
            }
        }

        private int _attackCurrent_Damage;
        public int AttackCurrent_Damage
        {
            get { return _attackCurrent_Damage; }
            set
            {
                _attackCurrent_Damage = value;
                OnPropertyChanged(nameof(AttackCurrent_Damage));
            }

        }

        private string _attackCurrent_Notes;
        public string AttackCurrent_Notes
        {
            get { return _attackCurrent_Notes; }
            set
            {
                _attackCurrent_Notes = value;
                _addAttackCMD.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(AttackCurrent_Notes));
            }
        }

        private RelayCommand _addAttackCMD;
        public ICommand AddAttackCMD
        {
            get { return _addAttackCMD; }
        }
        private RelayCommand _delAttackCMD;
        public ICommand DelAttackCMD
        {
            get { return _delAttackCMD; }
        }
        /// <summary>
        /// Adds an attack if it doesnt already exist
        /// </summary>
        void AddAttack()
        {
            // Check if it already exists
            if (Attacks.Any(a =>
            a.Name == AttackCurrent_Name && a.Range == AttackCurrent_Range && a.HitDC == AttackCurrent_HitDC && a.Damage == AttackCurrent_Damage &&
            a.Notes == AttackCurrent_Notes))
            {
                return;
            }

            Attacks.Add(new Attack()
            {
                Name = AttackCurrent_Name,
                Range = AttackCurrent_Range,
                HitDC = AttackCurrent_HitDC,
                Damage = AttackCurrent_Damage,
                Notes = AttackCurrent_Notes
            });

        }
        void DeleteAttack()
        {
            Attacks.Remove(SelectedAttack);
            IsAttackSelected = false;
        }

        private Attack _selectedAttack;
        public Attack SelectedAttack
        {
            get { return _selectedAttack; }
            set
            {
                _selectedAttack = value;
                IsAttackSelected = true;
                _delAttackCMD.RaiseCanExecuteChanged();
            }
        }
        private bool _isAttackSelected;
        private bool IsAttackSelected
        {
            get { return _isAttackSelected; }
            set
            {
                _isAttackSelected = value;
                _delAttackCMD.RaiseCanExecuteChanged();
            }
        }
        #endregion
        #region Spells
        private string _spellCurrent_Name;
        public string SpellCurrent_Name
        {
            get => _spellCurrent_Name;
            set
            {
                _spellCurrent_Name = value;
                OnPropertyChanged(nameof(SpellCurrent_Name));
                _addSpellCMD.RaiseCanExecuteChanged();
            }
        }
        private int _spellCurrent_Range;
        public int SpellCurrent_Range
        {
            get { return _spellCurrent_Range; }
            set
            {
                _spellCurrent_Range = value;
                OnPropertyChanged(nameof(SpellCurrent_Range));
            }
        }

        private string _spellCurrent_HitDC;
        public string SpellCurrent_HitDC
        {
            get { return _spellCurrent_HitDC; }
            set
            {
                _spellCurrent_HitDC = value;
                OnPropertyChanged(nameof(SpellCurrent_HitDC));
                _addSpellCMD.RaiseCanExecuteChanged();
            }

        }

        private int _spellCurrent_Damage;
        public int SpellCurrent_Damage
        {
            get { return _spellCurrent_Damage; }
            set
            {
                _spellCurrent_Damage = value;
                OnPropertyChanged(nameof(SpellCurrent_Damage));
            }

        }

        private string _spellCurrent_Notes;
        public string SpellCurrent_Notes
        {
            get { return _spellCurrent_Notes; }
            set
            {
                _spellCurrent_Notes = value;
                OnPropertyChanged(nameof(SpellCurrent_Notes));
                _addSpellCMD.RaiseCanExecuteChanged();
            }

        }

        private int _spellCurrent_Time;
        public int SpellCurrent_Time
        {
            get { return _spellCurrent_Time; }
            set
            {
                _spellCurrent_Time = value;
                OnPropertyChanged(nameof(SpellCurrent_Time));
            }

        }

        private int _spellCurrent_Level;
        public int SpellCurrent_Level
        {
            get { return _spellCurrent_Level; }
            set
            {
                _spellCurrent_Level = value;
                OnPropertyChanged(nameof(SpellCurrent_Level));
            }
        }

        private RelayCommand _addSpellCMD;
        public ICommand AddSpellCMD
        {
            get { return _addSpellCMD; }
        }
        private RelayCommand _delSpellCMD;
        public ICommand DelSpellCMD
        {
            get { return _delSpellCMD; }
        }
        /// <summary>
        /// Adds a Spell if it doesnt already exist
        /// </summary>
        void AddSpell()
        {
            // Check if it already exists
            if (Spells.Any(s =>
            s.Name == SpellCurrent_Name && s.Range == SpellCurrent_Range && s.HitDC == SpellCurrent_HitDC && s.Damage == SpellCurrent_Damage &&
            s.Notes == SpellCurrent_Notes && s.Time == SpellCurrent_Time && s.Level == _spellCurrent_Level))
            {
                return;
            }

            Spells.Add(new Spell()
            {
                Name = SpellCurrent_Name,
                Range = SpellCurrent_Range,
                HitDC = SpellCurrent_HitDC,
                Damage = SpellCurrent_Damage,
                Notes = SpellCurrent_Notes,
                Time = SpellCurrent_Time,
                Level = _spellCurrent_Level
            });

        }
        void DeleteSpell()
        {
            Spells.Remove(SelectedSpell);
            IsSpellSelected = false;
        }

        private Spell _selectedSpell;
        public Spell SelectedSpell
        {
            get { return _selectedSpell; }
            set
            {
                _selectedSpell = value;
                IsSpellSelected = true;
                _delSpellCMD.RaiseCanExecuteChanged();
            }
        }
        private bool _isSpellSelected;
        private bool IsSpellSelected
        {
            get { return _isSpellSelected; }
            set
            {
                _isSpellSelected = value;
                _delSpellCMD.RaiseCanExecuteChanged();
            }
        }
        #endregion
        #region Display Only Variables
        private int _display_Strength;
        public int Display_Strength
        {
            get => _display_Strength;
            set
            {
                _display_Strength = value;
                OnPropertyChanged(nameof(Display_Strength));
            }
        }
        private int _display_Dexterity;
        public int Display_Dexterity
        {
            get { return _display_Dexterity; }
            set
            {
                _display_Dexterity = value;
                OnPropertyChanged(nameof(Display_Dexterity));
            }
        }

        private int _display_Constitution;
        public int Display_Constitution
        {
            get { return _display_Constitution; }
            set
            {
                _display_Constitution = value;
                OnPropertyChanged(nameof(Display_Constitution));
            }
        }

        private int _display_Intelligence;
        public int Display_Intelligence
        {
            get { return _display_Intelligence; }
            set
            {
                _display_Intelligence = value;
                OnPropertyChanged(nameof(Display_Intelligence));
            }
        }

        private int _display_Wisdom;
        public int Display_Wisdom
        {
            get { return _display_Wisdom; }
            set
            {
                _display_Wisdom = value;
                OnPropertyChanged(nameof(Display_Wisdom));
            }
        }

        private int _display_Charisma;
        public int Display_Charisma
        {
            get { return _display_Charisma; }
            set
            {
                _display_Charisma = value;
                OnPropertyChanged(nameof(Display_Charisma));
            }
        }

        private int _display_sav_Strength;
        public int Display_Sav_Strength
        {
            get => _display_sav_Strength;
            set
            {
                _display_sav_Strength = value;
                OnPropertyChanged(nameof(Display_Sav_Strength));
            }
        }
        private int _display_sav_Intelligence;
        public int Display_Sav_Intelligence
        {
            get => _display_sav_Intelligence;
            set
            {
                _display_sav_Intelligence = value;
                OnPropertyChanged(nameof(Display_Sav_Intelligence));
            }
        }

        private int _display_sav_Dexterity;
        public int Display_Sav_Dexterity
        {
            get => _display_sav_Dexterity;
            set
            {
                _display_sav_Dexterity = value;
                OnPropertyChanged(nameof(Display_Sav_Dexterity));
            }
        }

        private int _display_sav_Wisdom;
        public int Display_Sav_Wisdom
        {
            get => _display_sav_Wisdom;
            set
            {
                _display_sav_Wisdom = value;
                OnPropertyChanged(nameof(Display_Sav_Wisdom));
            }
        }

        private int _display_sav_Constitution;
        public int Display_Sav_Constitution
        {
            get => _display_sav_Constitution;
            set
            {
                _display_sav_Constitution = value;
                OnPropertyChanged(nameof(Display_Sav_Constitution));
            }
        }

        private int _display_sav_Charisma;
        public int Display_Sav_Charisma
        {
            get => _display_sav_Charisma;
            set
            {
                _display_sav_Charisma = value;
                OnPropertyChanged(nameof(Display_Sav_Charisma));
            }
        }

        private int _display_prof_Acrobatics;
        public int Display_Prof_Acrobatics
        {
            get => _display_prof_Acrobatics;
            set
            {
                _display_prof_Acrobatics = value;
                OnPropertyChanged(nameof(Display_Prof_Acrobatics));
            }
        }
        private int _display_prof_AnimalHandling;
        public int Display_Prof_AnimalHandling
        {
            get => _display_prof_AnimalHandling;
            set
            {
                _display_prof_AnimalHandling = value;
                OnPropertyChanged(nameof(Display_Prof_AnimalHandling));
            }
        }

        private int _display_prof_Arcana;
        public int Display_Prof_Arcana
        {
            get => _display_prof_Arcana;
            set
            {
                _display_prof_Arcana = value;
                OnPropertyChanged(nameof(Display_Prof_Arcana));
            }
        }

        private int _display_prof_Athletics;
        public int Display_Prof_Athletics
        {
            get => _display_prof_Athletics;
            set
            {
                _display_prof_Athletics = value;
                OnPropertyChanged(nameof(Display_Prof_Athletics));
            }
        }

        private int _display_prof_Deception;
        public int Display_Prof_Deception
        {
            get => _display_prof_Deception;
            set
            {
                _display_prof_Deception = value;
                OnPropertyChanged(nameof(Display_Prof_Deception));
            }
        }

        private int _display_prof_History;
        public int Display_Prof_History
        {
            get => _display_prof_History;
            set
            {
                _display_prof_History = value;
                OnPropertyChanged(nameof(Display_Prof_History));
            }
        }

        private int _display_prof_Insight;
        public int Display_Prof_Insight
        {
            get => _display_prof_Insight;
            set
            {
                _display_prof_Insight = value;
                OnPropertyChanged(nameof(Display_Prof_Insight));
            }
        }

        private int _display_prof_Intimidation;
        public int Display_Prof_Intimidation
        {
            get => _display_prof_Intimidation;
            set
            {
                _display_prof_Intimidation = value;
                OnPropertyChanged(nameof(Display_Prof_Intimidation));
            }
        }

        private int _display_prof_Investigation;
        public int Display_Prof_Investigation
        {
            get => _display_prof_Investigation;
            set
            {
                _display_prof_Investigation = value;
                OnPropertyChanged(nameof(Display_Prof_Investigation));
            }
        }

        private int _display_prof_Medicine;
        public int Display_Prof_Medicine
        {
            get => _display_prof_Medicine;
            set
            {
                _display_prof_Medicine = value;
                OnPropertyChanged(nameof(Display_Prof_Medicine));
            }
        }

        private int _display_prof_Nature;
        public int Display_Prof_Nature
        {
            get => _display_prof_Nature;
            set
            {
                _display_prof_Nature = value;
                OnPropertyChanged(nameof(Display_Prof_Nature));
            }
        }

        private int _display_prof_Perception;
        public int Display_Prof_Perception
        {
            get => _display_prof_Perception;
            set
            {
                _display_prof_Perception = value;
                OnPropertyChanged(nameof(Display_Prof_Perception));
            }
        }

        private int _display_prof_Performance;
        public int Display_Prof_Performance
        {
            get => _display_prof_Performance;
            set
            {
                _display_prof_Performance = value;
                OnPropertyChanged(nameof(Display_Prof_Performance));
            }
        }

        private int _display_prof_Persuasion;
        public int Display_Prof_Persuasion
        {
            get => _display_prof_Persuasion;
            set
            {
                _display_prof_Persuasion = value;
                OnPropertyChanged(nameof(Display_Prof_Persuasion));
            }
        }

        private int _display_prof_Religion;
        public int Display_Prof_Religion
        {
            get => _display_prof_Religion;
            set
            {
                _display_prof_Religion = value;
                OnPropertyChanged(nameof(Display_Prof_Religion));
            }
        }

        private int _display_prof_SleightOfHand;
        public int Display_Prof_SleightOfHand
        {
            get => _display_prof_SleightOfHand;
            set
            {
                _display_prof_SleightOfHand = value;
                OnPropertyChanged(nameof(Display_Prof_SleightOfHand));
            }
        }

        private int _display_prof_Stealth;
        public int Display_Prof_Stealth
        {
            get => _display_prof_Stealth;
            set
            {
                _display_prof_Stealth = value;
                OnPropertyChanged(nameof(Display_Prof_Stealth));
            }
        }

        private int _display_prof_Survival;
        public int Display_Prof_Survival
        {
            get => _display_prof_Survival;
            set
            {
                _display_prof_Survival = value;
                OnPropertyChanged(nameof(Display_Prof_Survival));
            }
        }
        #endregion
        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        private ObservableCollection<Spell> _spells;
        public ObservableCollection<Spell> Spells
        {
            get => _spells;
            set
            {
                _spells = value;
                OnPropertyChanged(nameof(Spells));
            }
        }
        private ObservableCollection<Attack> _attacks;
        public ObservableCollection<Attack> Attacks
        {
            get => _attacks;
            set
            {
                _attacks = value;
                OnPropertyChanged(nameof(Attacks));
            }
        }
        #endregion
        #region SaveLoad
        private RelayCommand _loadCMD;
        public ICommand LoadCMD
        {
            get => _loadCMD;
        }
        private RelayCommand _saveCMD;
        public ICommand SaveCMD
        {
            get => _saveCMD;
        }

        void LoadConfig()
        {
            Config.LoadConfig(this);
        }
        void SaveConfig()
        {
            Config.SaveConfig(this);
        }
        #endregion
        /// <summary>
        /// call this whenever calcualtions have to be done again
        /// </summary>
        void Recalculate()
        {
            Display_Strength = (Strength - 10) / 2;
            Display_Dexterity = (Dexterity - 10) / 2;
            Display_Constitution = (Constituation - 10) / 2;
            Display_Intelligence = (Intelligence - 10) / 2;
            Display_Wisdom = (Wisdom - 10) / 2;
            Display_Charisma = (Charisma - 10) / 2;

            Display_Sav_Strength = Sav_Strength ? Strength + ProficiencyBonus : Strength;
            Display_Sav_Dexterity = Sav_Dexterity ? Dexterity + ProficiencyBonus : Dexterity;
            Display_Sav_Constitution = Sav_Constitution ? Constituation + ProficiencyBonus : Constituation;
            Display_Sav_Intelligence = Sav_Intelligence ? Intelligence + ProficiencyBonus : Intelligence;
            Display_Sav_Wisdom = Sav_Wisdom ? Wisdom + ProficiencyBonus : Wisdom;
            Display_Sav_Charisma = Sav_Charisma ? Charisma + ProficiencyBonus : Charisma;

            Display_Prof_Acrobatics = Prof_Acrobatics ? Dexterity + ProficiencyBonus : Dexterity;
            Display_Prof_AnimalHandling = Prof_AnimalHandling ? Wisdom + ProficiencyBonus : Wisdom;
            Display_Prof_Arcana = Prof_Arcana ? Intelligence + ProficiencyBonus : Intelligence;
            Display_Prof_Athletics = Prof_Athletics ? Strength + ProficiencyBonus : Strength;
            Display_Prof_Deception = Prof_Deception ? Charisma + ProficiencyBonus : Charisma;
            Display_Prof_History = Prof_History ? Intelligence + ProficiencyBonus : Intelligence;
            Display_Prof_Insight = Prof_Insight ? Wisdom + ProficiencyBonus : Wisdom;
            Display_Prof_Intimidation = Prof_Intimidation ? Charisma + ProficiencyBonus : Charisma;
            Display_Prof_Investigation = Prof_Investigation ? Intelligence + ProficiencyBonus : Intelligence;
            Display_Prof_Medicine = Prof_Medicine ? Wisdom + ProficiencyBonus : Wisdom;
            Display_Prof_Nature = Prof_Nature ? Intelligence + ProficiencyBonus : Intelligence;
            Display_Prof_Perception = Prof_Perception ? Wisdom + ProficiencyBonus : Wisdom;
            Display_Prof_Performance = Prof_Performance ? Charisma + ProficiencyBonus : Charisma;
            Display_Prof_Persuasion = Prof_Persuasion ? Charisma + ProficiencyBonus : Charisma;
            Display_Prof_Religion = Prof_Religion ? Intelligence + ProficiencyBonus : Intelligence;
            Display_Prof_SleightOfHand = Prof_SleightOfHand ? Dexterity + ProficiencyBonus : Dexterity;
            Display_Prof_Stealth = Prof_Stealth ? Dexterity + ProficiencyBonus : Dexterity;
            Display_Prof_Survival = Prof_Survival ? Wisdom + ProficiencyBonus : Wisdom;
        }

        public MainWindowViewModel()
        {
            Items = new();
            Spells = new();
            Attacks = new();
            // AddCmd Check if current name and description not null as weight and amount are already checked individually
            _addItemCmd = new RelayCommand(AddItem, () =>
            ItemCurrent_Name != null && ItemCurrent_Name.Length > 0 && ItemCurrent_Description != null && ItemCurrent_Description.Length > 0);

            _delItemCmd = new RelayCommand(DelItem, () => IsItemSelected == true);

            // check if name notes and hitdc not null and bigger then 0 
            _addAttackCMD = new RelayCommand(AddAttack, () =>
            AttackCurrent_Name != null && AttackCurrent_Name.Length > 0 && AttackCurrent_HitDC != null && AttackCurrent_HitDC.Length > 0 &&
            AttackCurrent_Notes != null && AttackCurrent_Notes.Length > 0);

            _delAttackCMD = new RelayCommand(DeleteAttack, () => IsAttackSelected == true);

            // check if name hitdc and notes not null and bigger then 0
            _addSpellCMD = new RelayCommand(AddSpell, () =>
            SpellCurrent_Name != null && SpellCurrent_Name.Length > 0 && SpellCurrent_HitDC != null && SpellCurrent_HitDC.Length > 0 &&
            SpellCurrent_Notes != null && SpellCurrent_Notes.Length > 0);

            _delSpellCMD = new RelayCommand(DeleteSpell, () => IsSpellSelected == true);

            _loadCMD = new RelayCommand(LoadConfig);
            _saveCMD = new RelayCommand(SaveConfig);

            // Recalculate once for all the values to update visually
            Recalculate();
        }
    }
}
