use Veera

-- add credit customer
-- remove a credit customer
-- if credit customer has money to give back dont actually delete set active = 0

-- drop table [CreditCustomer]
SET QUOTED_IDENTIFIER ON
GO
-- drop table CreditCustomer
--CREATE TABLE [dbo].[CreditCustomer](
	[customer_id]  [int] IDENTITY NOT NULL ,
	[customer_name] [varchar](100) NOT NULL,
	[phone_number][varchar](100)  NULL,
	[credit_amount] [float] NULL,
	[added_date] [DateTime],
	[active][int],
 CONSTRAINT [PK_CreditCustomer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

select * from CreditCustomer

            cmd.Parameters.AddWithValue("@billNumber", billNo);
            cmd.Parameters.AddWithValue("@Id", Int32.Parse(id));
            cmd.Parameters.AddWithValue("@returnQty", returnQty);
            cmd.Parameters.AddWithValue("@creditAmount", creditAmount);

		
		SET QUOTED_IDENTIFIER ON
GO

-- drop table [HistReturnItem]
	CREATE TABLE [dbo].[HistReturnItem](
	[id]  [int] IDENTITY NOT NULL ,
	[bill_number] [int] NOT NULL,
	[product_code][varchar](50) NOT NULL,
	[return_quantity] [float] NULL,
	[return_amount] [float] NULL,
	[return_date] [DateTime],
 CONSTRAINT [PK_HistReturnItem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

select * from [HistReturnItem]
-- truncate table [HistReturnItem]
select * from ProductTable
select * from TransactionDetail where bill_number='1'
select * from TransactionTable where bill_number='1'
select * from [HistReturnItem]


select* from creditCustomer

select customer_id as 'Id', customer_name ,credit_amount,phone_number,added_date as 'joined_date'  from creditCustomer where 
                           active = '1'

select * from TransactionTable
select * from TransactionDetail

select * from BankInfo