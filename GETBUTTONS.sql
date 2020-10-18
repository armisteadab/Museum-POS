CREATE PROCEDURE [dbo].[GetButtons]
AS
SELECT A.ButtonNumber, A.ButtonText, A.ButtonUPC, B.InvUPC, B.InvPrice, B.InvName, B.TaxRate FROM Buttons A INNER JOIN InventoryItems B ON b.InvUPC = A.ButtonUPC ORDER BY ButtonNumber
RETURN 0
