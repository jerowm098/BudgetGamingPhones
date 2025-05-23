namespace InfinixShop_Common
{
    public class PhoneItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PhoneItem() { }

        public PhoneItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
