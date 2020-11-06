select a.UPC, a.paid,a.ReceiptDate, b.InvUPC, b.InvName, B.Id from receipt AS a LEFT OUTER JOIN InventoryItems AS b ON a.UPC = b.InvUPC
where a.Paid > 0 ORDER BY b.InvUPC  
