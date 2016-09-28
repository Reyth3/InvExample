using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RPGCore.Items
{
    [Serializable]
    [ImplementPropertyChanged]
    [XmlInclude(typeof(Consumable))]
    [XmlInclude(typeof(Weapon))]
    public class ItemBase
    {
        public ItemBase() { }
        public ItemBase(string _n, string _d, int _v)
        {
            Name = _n;
            Description = _d;
            Value = _v;
        }
        #region Basic Fields
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string description;
        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int _value;

        [XmlAttribute]
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        #endregion
    }

    [Serializable]
    [ImplementPropertyChanged]
    public class Consumable : ItemBase
    {
        public Consumable()
        {
        }

        public Consumable(string _n, string _d, int _v, int _HPr, int _MPr)
        {
            Name = _n;
            Description = _d;
            Value = _v;
            HealthRecovery = _HPr;
            ManaRecovery = _MPr;
        }

        #region Basic Fields
        private int healthRecovery;

        [XmlAttribute]
        public int HealthRecovery
        {
            get { return healthRecovery; }
            set { healthRecovery = value; }
        }
        private int manaRecovery;

        [XmlAttribute]
        public int ManaRecovery
        {
            get { return manaRecovery; }
            set { manaRecovery = value; }
        }
        #endregion
    }

    [Serializable]
    [ImplementPropertyChanged]
    public class Weapon : ItemBase
    {
        public Weapon()
        {
        }

        public Weapon(string _n, string _d, int _v, int _dmg)
        {
            Name = _n;
            Description = _d;
            Value = _v;
            Damage = _dmg;
        }

        #region Basic Fields
        private int damage;

        [XmlAttribute]
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        #endregion
    }

}
