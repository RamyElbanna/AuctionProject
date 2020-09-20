namespace Auction.DataAccess
{
    public class AuctionWinnerDetails: BaseEntity
    {
        public string WinnerName { get; set; }
        public string ItemName { get; set; }
        public double StartingPrice { get; set; }
        public double PricePaid { get; set; }
        public double Profit { get; set; }

    }
}
