USE TransactionAppDB;

INSERT INTO Transactions (Amount, Date, Type, UserId)
VALUES 
(5000.00, '2026-01-15', 'Credit', 1),
(1200.00, '2026-01-18', 'Debit', 1),
(3000.00, '2026-02-01', 'Credit', 1),
(800.00,  '2026-02-10', 'Debit', 1),
(7500.00, '2026-03-05', 'Credit', 1);

SELECT * FROM Users;
SELECT * FROM Transactions;

INSERT INTO Transactions (Amount, Date, Type, UserId)
VALUES 
(8000.00, '2024-01-10', 'Credit', 2),
(2500.00, '2024-01-20', 'Debit', 2),
(5000.00, '2024-02-05', 'Credit', 2),
(1500.00, '2024-02-15', 'Debit', 2),
(9000.00, '2024-03-01', 'Credit', 2);

USE TransactionAppDB;
SELECT t.*, u.Username 
FROM Transactions t
JOIN Users u ON t.UserId = u.Id;