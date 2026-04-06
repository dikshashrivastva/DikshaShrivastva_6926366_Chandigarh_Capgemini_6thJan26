SELECT TOP (1000) [Id]
      ,[Title]
      ,[Description]
      ,[Date]
      ,[Location]
      ,[TotalSeats]
      ,[AvailableSeats]
      ,[TicketPrice]
      ,[Category]
      ,[ImageUrl]
      ,[IsActive]
  FROM [EventBookingDB].[dbo].[Events]

  USE EventBookingDB;

  INSERT INTO Events (Title, Description, Date, Location, TotalSeats, AvailableSeats, TicketPrice, Category, ImageUrl, IsActive)
VALUES 

('React & Next.js Workshop', 'Full day hands-on workshop on modern frontend development with React and Next.js.', '2025-05-20 10:00:00', 'Bangalore, Karnataka', 100, 100, 799, 'Tech', '', 1),

('Comedy Night with Zakir Khan', 'A hilarious stand-up comedy night with Zakir Khan and special guests.', '2025-05-10 19:30:00', 'Delhi, NCR', 300, 300, 1299, 'Art', '', 1),

('Yoga & Wellness Retreat', 'A full day yoga, meditation and wellness retreat in the hills.', '2025-06-01 07:00:00', 'Rishikesh, Uttarakhand', 80, 80, 1999, 'Art', '', 1);

SELECT * FROM Events;

USE EventBookingDB;

UPDATE Events SET ImageUrl = 'https://images.unsplash.com/photo-1501386761578-eac5c94b800a?w=600'
WHERE Category = 'Music';

UPDATE Events SET ImageUrl = 'https://images.unsplash.com/photo-1540575467063-178a50c2df87?w=600'
WHERE Category = 'Tech';

UPDATE Events SET ImageUrl = 'https://images.unsplash.com/photo-1527529482837-4698179dc6ce?w=600'
WHERE Category = 'Art';

UPDATE Events SET ImageUrl = 'https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?w=600'
WHERE Category = 'Food';

UPDATE Events SET ImageUrl = 'https://images.unsplash.com/photo-1461896836934-ffe607ba8211?w=600'
WHERE Category = 'Sports';