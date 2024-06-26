
namespace DeqSort
{
    public class Item
    {
        public Item prev;
        public int value;
        public Item next;

        public Item(int value = 0) 
        {
            this.prev = null;
            this.value = value;
            this.next = null;
        }

    }
}
