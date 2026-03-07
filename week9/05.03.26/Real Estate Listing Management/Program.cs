using System.Security.Cryptography.X509Certificates;

namespace Real_Estate_Listing_Management
{
	public class RealEstateListing
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public string Location { get; set; }

		2
	}

	public class RealEstateApp
	{
		private List<RealEstateListing> listings = new List<RealEstateListing>();

		public void AddListing(RealEstateListing listing)
		{
			listings.Add(listing);
		}

		public void RemoveListing(int listingID)
		{
			listings.RemoveAll(l => l.ID == listingID);
		}

		public void UpdateListing(RealEstateListing updatedListing)
		{
			foreach(var listing in listings)
			{
				if (listing.ID == updatedListing.ID)
				{
					listing.Title = updatedListing.Title;
					listing.Location = updatedListing.Location;
					listing.Price = updatedListing.Price;
					listing.Description = updatedListing.Description;
					
				}
			}
		}

		public List<RealEstateListing> GetListings()
		{
			return listings;
		}

		public List<RealEstateListing> GetListingsByLocation(string location)
		{
			List<RealEstateListing> res = new List<RealEstateListing>();

			foreach(var listing in listings)
			{
				if (listing.Location == location)
				{
					res.Add(listing);
				}
			}
			return res;
		}
		public List<RealEstateListing> GetListigsByPriceRange(int minPrice,int maxPrice)
		{
			List<RealEstateListing> res = new List<RealEstateListing>();
			foreach(var listing in listings)
			{
				if(listing.Price>minPrice && listing.Price < maxPrice)
				{
					res.Add(listing);
				}
			}
			return res;

		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			RealEstateApp app = new RealEstateApp();

			RealEstateListing l1 = new RealEstateListing();
			l1.ID = 1;
			l1.Title = "Villa";
			l1.Description = "Luxury Villa";
			l1.Price = 5000000;
			l1.Location = "Delhi";

			RealEstateListing l2 = new RealEstateListing();
			l2.ID = 2;
			l2.Title = "Apartment";
			l2.Description = "2BHK Flat";
			l2.Price = 2000000;
			l2.Location = "Mumbai";

			app.AddListing(l1);
			app.AddListing(l2);

			Console.WriteLine("All Listings:");
			foreach (var listing in app.GetListings())
			{
				Console.WriteLine(listing.ID + " " + listing.Title + " " + listing.Price);
			}

			Console.WriteLine("\nListings in Delhi:");
			foreach (var listing in app.GetListingsByLocation("Delhi"))
			{
				Console.WriteLine(listing.Title);
			}
		}
	}
}
