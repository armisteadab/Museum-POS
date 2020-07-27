SELECT cardtype, ABS(SUM(Paid)) as sumcard FROM Receipt WHERE ReceiptDate = '7/25/2020' AND PayType = 'CARD' GROUP BY CardType
