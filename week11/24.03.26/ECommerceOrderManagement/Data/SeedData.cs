using ECommerceOrderManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOrderManagement.Data
{
	public static class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using var context = new ApplicationDbContext(
				serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

			// ─── Skip if already seeded ───────────────────────────────────────
			if (context.Categories.Any()) return;

			// ─── CATEGORIES ───────────────────────────────────────────────────
			var categories = new List<Category>
			{
				new Category { Name = "Electronics",     Description = "Gadgets, phones, laptops and accessories" },
				new Category { Name = "Clothing",        Description = "Men and women fashion apparel" },
				new Category { Name = "Home & Kitchen",  Description = "Furniture, appliances and kitchenware" },
				new Category { Name = "Books",           Description = "Fiction, non-fiction and educational books" },
				new Category { Name = "Sports & Fitness",Description = "Equipment and gear for sports and workouts" },
			};
			context.Categories.AddRange(categories);
			context.SaveChanges();

			// ─── PRODUCTS ─────────────────────────────────────────────────────
			var products = new List<Product>
			{
                // Electronics
                new Product { Name = "Samsung Galaxy S24",   Description = "Latest Samsung flagship smartphone",          Price = 79999, Stock = 25, CategoryId = categories[0].CategoryId },
				new Product { Name = "Dell Inspiron Laptop", Description = "15.6\" FHD laptop with Intel i5 processor",   Price = 55999, Stock = 15, CategoryId = categories[0].CategoryId },
				new Product { Name = "Sony WH-1000XM5",      Description = "Noise-cancelling wireless headphones",        Price = 24999, Stock = 40, CategoryId = categories[0].CategoryId },
				new Product { Name = "Apple iPad Air",       Description = "10.9 inch tablet with M1 chip",               Price = 59900, Stock = 20, CategoryId = categories[0].CategoryId },
				new Product { Name = "Logitech MX Master 3", Description = "Advanced wireless mouse for productivity",    Price = 7999,  Stock = 60, CategoryId = categories[0].CategoryId },

                // Clothing
                new Product { Name = "Levi's 501 Jeans",     Description = "Classic straight-fit denim jeans",            Price = 3499,  Stock = 80, CategoryId = categories[1].CategoryId },
				new Product { Name = "Nike Air Force 1",     Description = "Iconic white leather sneakers",               Price = 7995,  Stock = 50, CategoryId = categories[1].CategoryId },
				new Product { Name = "Zara Casual Shirt",    Description = "Slim-fit cotton casual shirt",                Price = 1999,  Stock = 100,CategoryId = categories[1].CategoryId },
				new Product { Name = "Adidas Hoodie",        Description = "Fleece pullover hoodie with kangaroo pocket", Price = 3299,  Stock = 70, CategoryId = categories[1].CategoryId },
				new Product { Name = "H&M Summer Dress",     Description = "Floral print midi dress for women",           Price = 2499,  Stock = 55, CategoryId = categories[1].CategoryId },

                // Home & Kitchen
                new Product { Name = "Instant Pot Duo 7-in-1",Description = "Multi-use pressure cooker",                 Price = 8999,  Stock = 30, CategoryId = categories[2].CategoryId },
				new Product { Name = "Philips Air Fryer",    Description = "3.5L digital air fryer with rapid air tech", Price = 6499,  Stock = 25, CategoryId = categories[2].CategoryId },
				new Product { Name = "IKEA LACK Coffee Table",Description = "Minimalist coffee table in black",          Price = 3499,  Stock = 20, CategoryId = categories[2].CategoryId },
				new Product { Name = "Dyson V11 Vacuum",     Description = "Cordless stick vacuum with powerful suction",Price = 42900, Stock = 12, CategoryId = categories[2].CategoryId },
				new Product { Name = "Himalayan Salt Lamp",  Description = "Natural crystal salt lamp with dimmer",      Price = 1299,  Stock = 90, CategoryId = categories[2].CategoryId },

                // Books
                new Product { Name = "Atomic Habits",        Description = "James Clear – build good habits, break bad ones", Price = 599,  Stock = 200, CategoryId = categories[3].CategoryId },
				new Product { Name = "The Alchemist",        Description = "Paulo Coelho – a journey of self-discovery",     Price = 399,  Stock = 150, CategoryId = categories[3].CategoryId },
				new Product { Name = "Clean Code",           Description = "Robert C. Martin – software craftsmanship",      Price = 1299, Stock = 80,  CategoryId = categories[3].CategoryId },
				new Product { Name = "Deep Work",            Description = "Cal Newport – focused success in distracted world",Price = 699, Stock = 120, CategoryId = categories[3].CategoryId },
				new Product { Name = "Rich Dad Poor Dad",    Description = "Robert Kiyosaki – personal finance classic",     Price = 449,  Stock = 180, CategoryId = categories[3].CategoryId },

                // Sports & Fitness
                new Product { Name = "Yoga Mat Premium",     Description = "6mm non-slip TPE yoga mat with carry strap",  Price = 1499, Stock = 75, CategoryId = categories[4].CategoryId },
				new Product { Name = "Adjustable Dumbbells", Description = "5-52.5 lb select-weight dumbbell set",        Price = 12999,Stock = 18, CategoryId = categories[4].CategoryId },
				new Product { Name = "Fitbit Charge 6",      Description = "Advanced fitness and health tracker",         Price = 14999,Stock = 35, CategoryId = categories[4].CategoryId },
				new Product { Name = "Resistance Bands Set", Description = "Set of 5 latex resistance bands",            Price = 799,  Stock = 120,CategoryId = categories[4].CategoryId },
				new Product { Name = "Decathlon Cycle",      Description = "21-speed mountain bicycle for adults",       Price = 18999,Stock = 10, CategoryId = categories[4].CategoryId },
			};
			context.Products.AddRange(products);
			context.SaveChanges();

			// ─── CUSTOMERS ────────────────────────────────────────────────────
			var customers = new List<Customer>
			{
				new Customer { FullName = "Rahul Sharma",   Email = "rahul.sharma@gmail.com",   Phone = "9876543210", Address = "12 MG Road, Bengaluru, Karnataka" },
				new Customer { FullName = "Priya Patel",    Email = "priya.patel@yahoo.com",    Phone = "9812345678", Address = "45 Nehru Nagar, Ahmedabad, Gujarat" },
				new Customer { FullName = "Amit Verma",     Email = "amit.verma@outlook.com",   Phone = "9988776655", Address = "7 Civil Lines, Allahabad, UP" },
				new Customer { FullName = "Sneha Iyer",     Email = "sneha.iyer@hotmail.com",   Phone = "9765432109", Address = "88 Anna Salai, Chennai, Tamil Nadu" },
				new Customer { FullName = "Karan Mehta",    Email = "karan.mehta@gmail.com",    Phone = "9654321098", Address = "33 Sector 17, Chandigarh, Punjab" },
				new Customer { FullName = "Divya Nair",     Email = "divya.nair@gmail.com",     Phone = "9543210987", Address = "19 MG Road, Kochi, Kerala" },
				new Customer { FullName = "Rohan Gupta",    Email = "rohan.gupta@rediffmail.com",Phone = "9432109876", Address = "55 Park Street, Kolkata, WB" },
			};
			context.Customers.AddRange(customers);
			context.SaveChanges();

			// ─── ORDERS + ORDER ITEMS + SHIPPING DETAILS ─────────────────────
			var orders = new List<Order>
			{
                // Order 1 – Rahul buys electronics
                new Order
				{
					CustomerId  = customers[0].CustomerId,
					OrderDate   = DateTime.Now.AddDays(-15),
					Status      = OrderStatus.Delivered,
					TotalAmount = products[0].Price * 1 + products[2].Price * 2,
					OrderItems  = new List<OrderItem>
					{
						new OrderItem { ProductId = products[0].ProductId, Quantity = 1, UnitPrice = products[0].Price },
						new OrderItem { ProductId = products[2].ProductId, Quantity = 2, UnitPrice = products[2].Price },
					},
					ShippingDetail = new ShippingDetail
					{
						ShippingAddress = customers[0].Address,
						ShippingStatus  = "Delivered",
						TrackingNumber  = "TRK-001-RAH",
						ShippedDate     = DateTime.Now.AddDays(-13),
						DeliveryDate    = DateTime.Now.AddDays(-10),
					}
				},

                // Order 2 – Priya buys clothes
                new Order
				{
					CustomerId  = customers[1].CustomerId,
					OrderDate   = DateTime.Now.AddDays(-10),
					Status      = OrderStatus.Shipped,
					TotalAmount = products[6].Price * 1 + products[9].Price * 2,
					OrderItems  = new List<OrderItem>
					{
						new OrderItem { ProductId = products[6].ProductId, Quantity = 1, UnitPrice = products[6].Price },
						new OrderItem { ProductId = products[9].ProductId, Quantity = 2, UnitPrice = products[9].Price },
					},
					ShippingDetail = new ShippingDetail
					{
						ShippingAddress = customers[1].Address,
						ShippingStatus  = "Shipped",
						TrackingNumber  = "TRK-002-PRI",
						ShippedDate     = DateTime.Now.AddDays(-8),
					}
				},

                // Order 3 – Amit buys books
                new Order
				{
					CustomerId  = customers[2].CustomerId,
					OrderDate   = DateTime.Now.AddDays(-7),
					Status      = OrderStatus.Processing,
					TotalAmount = products[15].Price * 2 + products[17].Price * 1 + products[19].Price * 1,
					OrderItems  = new List<OrderItem>
					{
						new OrderItem { ProductId = products[15].ProductId, Quantity = 2, UnitPrice = products[15].Price },
						new OrderItem { ProductId = products[17].ProductId, Quantity = 1, UnitPrice = products[17].Price },
						new OrderItem { ProductId = products[19].ProductId, Quantity = 1, UnitPrice = products[19].Price },
					},
					ShippingDetail = new ShippingDetail
					{
						ShippingAddress = customers[2].Address,
						ShippingStatus  = "Processing",
						TrackingNumber  = "TRK-003-AMI",
					}
				},

                // Order 4 – Sneha buys home & kitchen
                new Order
				{
					CustomerId  = customers[3].CustomerId,
					OrderDate   = DateTime.Now.AddDays(-5),
					Status      = OrderStatus.Pending,
					TotalAmount = products[10].Price * 1 + products[11].Price * 1,
					OrderItems  = new List<OrderItem>
					{
						new OrderItem { ProductId = products[10].ProductId, Quantity = 1, UnitPrice = products[10].Price },
						new OrderItem { ProductId = products[11].ProductId, Quantity = 1, UnitPrice = products[11].Price },
					},
					ShippingDetail = new ShippingDetail
					{
						ShippingAddress = customers[3].Address,
						ShippingStatus  = "Pending",
					}
				},

                // Order 5 – Karan buys fitness
                new Order
				{
					CustomerId  = customers[4].CustomerId,
					OrderDate   = DateTime.Now.AddDays(-3),
					Status      = OrderStatus.Pending,
					TotalAmount = products[20].Price * 1 + products[23].Price * 2,
					OrderItems  = new List<OrderItem>
					{
						new OrderItem { ProductId = products[20].ProductId, Quantity = 1, UnitPrice = products[20].Price },
						new OrderItem { ProductId = products[23].ProductId, Quantity = 2, UnitPrice = products[23].Price },
					},
					ShippingDetail = new ShippingDetail
					{
						ShippingAddress = customers[4].Address,
						ShippingStatus  = "Pending",
					}
				},

                // Order 6 – Divya buys electronics + books
                new Order
				{
					CustomerId  = customers[5].CustomerId,
					OrderDate   = DateTime.Now.AddDays(-2),
					Status      = OrderStatus.Pending,
					TotalAmount = products[4].Price * 1 + products[16].Price * 1,
					OrderItems  = new List<OrderItem>
					{
						new OrderItem { ProductId = products[4].ProductId,  Quantity = 1, UnitPrice = products[4].Price },
						new OrderItem { ProductId = products[16].ProductId, Quantity = 1, UnitPrice = products[16].Price },
					},
					ShippingDetail = new ShippingDetail
					{
						ShippingAddress = customers[5].Address,
						ShippingStatus  = "Pending",
					}
				},

                // Order 7 – Rohan buys laptop + headphones
                new Order
				{
					CustomerId  = customers[6].CustomerId,
					OrderDate   = DateTime.Now.AddDays(-1),
					Status      = OrderStatus.Pending,
					TotalAmount = products[1].Price * 1 + products[2].Price * 1,
					OrderItems  = new List<OrderItem>
					{
						new OrderItem { ProductId = products[1].ProductId, Quantity = 1, UnitPrice = products[1].Price },
						new OrderItem { ProductId = products[2].ProductId, Quantity = 1, UnitPrice = products[2].Price },
					},
					ShippingDetail = new ShippingDetail
					{
						ShippingAddress = customers[6].Address,
						ShippingStatus  = "Pending",
					}
				},

                // Order 8 – Rahul second order (clothing)
                new Order
				{
					CustomerId  = customers[0].CustomerId,
					OrderDate   = DateTime.Now.AddDays(-1),
					Status      = OrderStatus.Pending,
					TotalAmount = products[5].Price * 2 + products[8].Price * 1,
					OrderItems  = new List<OrderItem>
					{
						new OrderItem { ProductId = products[5].ProductId, Quantity = 2, UnitPrice = products[5].Price },
						new OrderItem { ProductId = products[8].ProductId, Quantity = 1, UnitPrice = products[8].Price },
					},
					ShippingDetail = new ShippingDetail
					{
						ShippingAddress = customers[0].Address,
						ShippingStatus  = "Pending",
					}
				},
			};

			context.Orders.AddRange(orders);
			context.SaveChanges();
		}
	}
}