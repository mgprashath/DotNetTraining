CREATE TABLE BillingData(
	CustomerNumber INT, 
	ReceiptAmount DECIMAL(10,2), 
	receiptDate Date, 
	ReceiptId INT, 
	Discount DECIMAL(10,2), 
	NetAmount DECIMAL(10,2),
	isDiscountCalc BIT

)

CREATE TABLE Points(
	point INT, 
	amount DECIMAL(10,2)
)

INSERT INTO BillingData values(1234,2000,GETDATE(),890,0,2000,1)


ALTER PROCEDURE InsertPaymentDetails(
	@CustomerNumber INT,
	@ReceiptAmount DECIMAL(10,2),
	@ReceiptId INT,
	@needDiscount BIT
)
AS
BEGIN

IF(@needDiscount=0)
	BEGIN
		INSERT INTO BillingData values(@CustomerNumber,@ReceiptAmount,GETDATE(),@ReceiptId,0,@ReceiptAmount,0)
	END
ELSE
	BEGIN
		DECLARE @Discount DECIMAL(10,2)
		SELECT @Discount = dbo.fn_CalculateDiscount(@CustomerNumber);
		print(@Discount)
		UPDATE BillingData SET isDiscountCalc=1 where CustomerNumber=@CustomerNumber
		INSERT INTO BillingData values(@CustomerNumber,@ReceiptAmount,GETDATE(),@ReceiptId,0,@ReceiptAmount - @Discount,0)
	END
END




ALTER FUNCTION fn_CalculateDiscount(
	@CustomerNumber INT
)
RETURNS DECIMAL(10,2)
AS
BEGIN
	DECLARE @TotalSpent DECIMAL(10,2);
	SELECT @TotalSpent= SUM(ReceiptAmount) FROM BillingData WHERE CustomerNumber=@CustomerNumber AND isDiscountCalc=0
	DECLARE @Discount DECIMAL(10,2)
	DECLARE @Points INT
	DECLARE @Amount DECIMAL(10,2)
	SELECT @Points=point, @Amount=amount FROM Points
	SET @Discount= @TotalSpent * @Points / @Amount;

	RETURN @Discount
END


EXEC dbo.InsertPaymentDetails 1234,2000,955,1

select dbo.fn_CalculateDiscount(1234)


SELECT SUM(ReceiptAmount) FROM BillingData WHERE CustomerNumber=1234 AND isDiscountCalc=0