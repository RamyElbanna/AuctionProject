namespace Auction.DataAccess
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }

        public double StartingPrice { get; set; }
    }
}
