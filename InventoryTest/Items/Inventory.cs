using PropertyChanged;
using RPGCore.Economy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RPGCore.Items
{
    [ImplementPropertyChanged]
    public class Inventory
    {
        public Inventory() { items = new List<ItemBase>(); Money = new Currency(); }
        public Inventory(List<ItemBase> _i, Currency _m)
        {
            Items = new List<ItemBase>(_i);
            Money = _m;
        }
        XmlSerializer xs;

        #region Basic Fields
        private List<ItemBase> items;

        public List<ItemBase> Items
        {
            get { return items; }
            set { items = value; }
        }
        private Currency money;

        public Currency Money
        {
            get { return money; }
            set { money = value; }
        }

        #endregion
        #region Inventory Functions
        public void AddItem(ItemBase item)
        {
            Items.Add(item);
        }
        public void RemoveItem(ItemBase item)
        {
            if (Items.Where(o => o == item).Count() >= 1)
                Items.Remove(item);
        }
        public List<T> GetItemsOfType<T>()
        {
            List<T> list = new List<T>();
            list = Items.OfType<T>().ToList<T>();
            return list;
        }
        #endregion

        public void Serialize()
        {
            xs = new XmlSerializer(typeof(List<ItemBase>));
            var ms = new MemoryStream();
            xs.Serialize(ms, Items);
            var b =ms.ToArray();

            File.WriteAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "inv.txt"), b);
        }

        public override string ToString()
        {
            return string.Format("Items Count = {0}; Money = {1}", items.Count(), Money);
        }
    }
}
