using Microsoft.AspNetCore.Mvc;
using Auction.Service;
using Microsoft.AspNetCore.Routing;
using Auction.DataAccess;

namespace Auction.WebApplication.Controllers
{
    // if i had enough time i would seperate the actions in defferent apropriate controllers :)
    public class HomeController : Controller
    {
        private readonly IItemRepo _itemRepo;
        private readonly IBidderRepo _bidderRepo;
        private readonly IAuctionDetailsRepo _auctionDetailsRepo;

        public HomeController(IItemRepo itemRepo, IBidderRepo bidderRepo, IAuctionDetailsRepo auctionDetailsRepo)
        {
            _itemRepo = itemRepo;
            _bidderRepo = bidderRepo;
            _auctionDetailsRepo = auctionDetailsRepo;
        }

        public IActionResult Index()
        {
            ViewBag.Items = _itemRepo.GetAll();
            ViewBag.Bidders = _bidderRepo.GetAll();
            return View();
        }

        [HttpPost]
        [Route("/addBidder")]
        public JsonResult AddBidder(string bidderName)
        {
            int bidderId = _bidderRepo.Add(new Bidder { Name = bidderName});
            if (bidderId > 0)
            {
                return Json(new { bidderId = bidderId, bidderName });
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [Route("/addItem")]
        public JsonResult AddItem(string itemName, double itemStartingPrice)
        {
            int itemId = _itemRepo.Add(new Item { Name = itemName, StartingPrice = itemStartingPrice });
            if (itemId > 0)
            {
                return Json(new { itemId = itemId, itemName = itemName });
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [Route("/saveAuctionWinnerDetails")]
        public JsonResult saveAuctionWinnerDetails(AuctionWinnerDetails auctionWinnerDetails)
        {
            int itemId = _auctionDetailsRepo.Add(auctionWinnerDetails);
            if (itemId > 0)
            {
                return Json(new { success = true});
            }
            else
            {
                return Json(new { success = false });

            }
        }
    }
}
