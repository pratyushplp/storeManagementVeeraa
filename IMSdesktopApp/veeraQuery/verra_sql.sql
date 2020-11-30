Use Veera
select * from TransactionTable
select * from TransactionDetail

select * from creditCustomer


select * from creditCustomer where customer_name='pratyush pradhan'
select * from ProductTable

Select product_code,product_type,remaining_unit,total_cost_per_unit,selling_price FROM ProductTable

-- Drop table productTable
-- drop table TransactionTable
-- drop table TransactionDetail
-- Drop table BankInfo


-- truncate table productTable
-- truncate table TransactionTable
-- truncate table TransactionDetail


select * from AdminUser
--CREATE TABLE AdminUser (
--    UserName varchar(255),
--    EncryptPassword varchar(255),

--);

--insert into AdminUser Values('pop','vnrjdNsldbEHelGBrnuhkDgfVxWLI7gL4nKvmrdu7hs=')

select * from productTable where product_code='KS101'

CREATE TABLE [dbo].[ProductTable]
(
	[Id] INT NOT NULL Identity(1,1) , 
    [product_type] VARCHAR(255) NOT NULL, 
    [brand_code] VARCHAR(50)  NULL, 
    [product_code] VARCHAR(50) NOT NULL, 
    [delivery_agent] VARCHAR(255) NULL, 
    [vendor] VARCHAR(255) NULL, 
    [unit_price_INR] FLOAT NULL, 
    [unit_price_NPR] FLOAT NULL, 
    [total_unit_in] FLOAT NULL,
    [remaining_unit]  FLOAT NULL,
    [carrier_charge_unit] FLOAT NULL, 
    [total_cost_per_unit] FLOAT NULL, 
    [selling_price] FLOAT NULL,
	[added_date] DateTime,
    PRIMARY KEY ([Id])
)


drop table productTable

select * from TransactionDetail

select * from TransactionTable


select * from BankInfo

--drop table TransactionTable


USE [Veera]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--CREATE TABLE [dbo].[TransactionTable](
--	[Id] INT NOT NULL Identity(1,1) , 
--	[customer_type] [varchar](50) NULL,
--	[customer_name] [varchar](255) NULL,
--	[customer_id] [varchar](50)  NULL,
--	[bill_number] [int] NOT NULL,
--	[transaction_date] [datetime] NULL,
--	[total_amount] [float] NULL,
--	[discount] [float] NULL,
--	[VAT] [float] NULL,
--	[payment_method][varchar](50) NULL,
--	[bank_name][varchar](50) NULL,
--  [total_qty][float] NULL

-- CONSTRAINT [PK_TransactionTable] PRIMARY KEY CLUSTERED 
--(
--	[bill_number] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]

--GO



--/****** Object:  Table [dbo].[Transaction_Detail]    Script Date: 11/4/2019 2:14:48 AM ******/

--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TABLE [dbo].[TransactionDetail](
--	[Id] INT NOT NULL Identity(1,1) , 
--	[product_code] [varchar](50) NOT NULL,
--	[product_type] [varchar](250)  NULL,
--	[unit_selling_price] [float] NULL,
--	[quantity] [float] NULL,
--	[total_selling_price] [float] NULL,
--	[bill_number] [int] NOT NULL,
-- CONSTRAINT [PK_TransactionDetail] PRIMARY KEY CLUSTERED 
--(
--	[Id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]

--GO


-- TABLE BANK INFO

--CREATE TABLE [dbo].[BankInfo](
--	[Id] INT NOT NULL Identity(1,1) , 
--	[bank_name] [varchar](50) NULL,
--	[balance] [float] NULL)

--insert into BankInfo values('Siddhartha Bank','0')
-- insert into BankInfo values('Kumari Bank','0')

	select * from BankInfo



	-----***********************---------------------------------------*************************************-----------------------------********************************------------------------*****************

	--insert into INSERT INTO TransactionTable ([customer_type],[customer_name],[customer_id],[bill_number],[transaction_date],[total_amount],[discount],[tax],[VAT] )
 --                   VALUES ('','',)

 
 
 -- query to create datatable for the required report


--with a as
--(
--	select cast(transaction_date as date) as 'Date',  sum(total_amount) as sum_total_amt, sum(total_qty) as sum_total_qty
--	from TransactionTable
--	where payment_method = 'Cash'
--	group by cast(transaction_date as date) 
--),b as 
--(
--	select cast(transaction_date as date) as "Date",  sum(total_amount) as sum_total_amt, sum(total_qty) as sum_total_qty
--	from TransactionTable
--	where payment_method = 'Credit Card'
--	group by  cast(transaction_date as date)
--)
--select distinct a.Date, a.sum_total_amt as "Cash_Payment", b.sum_total_amt as "Credit_Payment", (a.sum_total_amt + b.sum_total_amt) as "Total_amt", (a.sum_total_qty + b.sum_total_qty) as "Total_Qty"
--from  a
--join  b
--on a.Date = b.Date


-- in code for generic sales data

--right query
							 --with a as
        --                    (
	       --                  select cast(transaction_date as date) as 'trans_date',  sum(total_amount) as cash,0 as sid_credit_card,0 as laxmi_credit_card, sum(total_qty) as sum_total_qty
	       --                  from TransactionTable
	       --                  where payment_method = 'Cash'
	       --                  group by cast(transaction_date as date) 
							 --UNION
							 --select cast(transaction_date as date) as 'trans_date',  0 as cash,sum(total_amount) as sid_credit_card,0 as laxmi_credit_card, sum(total_qty) as sum_total_qty
	       --                  from TransactionTable
        --                     where payment_method = 'Credit Card' and bank_name = 'Siddhartha Bank'
	       --                  group by cast(transaction_date as date)							 
							 --UNION
							 --select cast(transaction_date as date) as 'trans_date',0 as cash,0 as sid_credit_card,sum(total_amount) as laxmi_credit_card, sum(total_qty) as sum_total_qty
	       --                  from TransactionTable
        --                     where payment_method = 'Credit Card' and bank_name ='Laxmi Bank'
	       --                  group by cast(transaction_date as date)							  
        --                     )
							 --select trans_date,sum(cash) as cash_amt,sum(sid_credit_card)as sid_credit_card_amt,sum(laxmi_credit_card) as laxmi_credit_card_amt,(sum(cash)+sum(sid_credit_card)+sum(laxmi_credit_card)) as total_amt, sum(sum_total_qty) as total_qty from a
							 --where trans_date BETWEEN CAST('11/17/2019 12:00:00 AM' as date) AND CAST( '11/18/2019 12:00:00 AM' as date)
							 --group by trans_date



-- before query this below query doesnt work as expected

                         --   with a as
                         --   (
	                        -- select cast(transaction_date as date) as 'trans_date',  sum(total_amount) as sum_total_amt, sum(total_qty) as sum_total_qty
	                        -- from TransactionTable
	                        -- where payment_method = 'Cash'
	                        -- group by cast(transaction_date as date) 
                         --    ),b as 
                         --   (
	                        --select cast(transaction_date as date) as 'trans_date',  sum(total_amount) as sum_total_amt, sum(total_qty) as sum_total_qty
                         --   from TransactionTable
                         --   where payment_method = 'Credit Card'
                         --   group by cast(transaction_date as date)
                         --   )
                         --   select distinct a.trans_date, a.sum_total_amt as 'cash_amt', b.sum_total_amt as 'credit_card_amt', (a.sum_total_amt + b.sum_total_amt) as 'total_amt', (a.sum_total_qty + b.sum_total_qty) as 'total_qty'
                         --   from a
                         --   join b
                         --   on a.trans_date = b.trans_date
                         --   WHERE a.trans_date BETWEEN CAST('11/17/2019 12:00:00 AM' as date) AND CAST('11/17/2019 12:00:00 AM' as date)


-- for detailed sales data (see updated query below this)

							--with a as
							--(
							--select  product_code, unit_selling_price,sum(quantity) as sum_qty
							--from transactionDetail
							--where bill_number in (select bill_number from transactionTable where CAST(transaction_date as date) BETWEEN CAST(@beginningDate as date) AND CAST(@endingDate as date))
							--group by product_code,unit_selling_price
							--),b as
							--(
							--select distinct total_cost_per_unit as cost_per_unit,product_code 
							--from  ProductTable
							--) 
							--select distinct a.product_code,a.unit_selling_price as selling_price_per_unit,b.cost_per_unit,a.sum_qty
							--from a
							--left join b
							--on a.product_code =b.product_code


-- for detailed sales data (see updated query )
--with a as
--(
--select  product_code, unit_selling_price,sum(quantity) as sum_qty
--from transactionDetail
--where bill_number in (select bill_number from transactionTable where CAST(transaction_date as date) BETWEEN CAST(@beginningDate as date) AND CAST(@endingDate as date))
--group by product_code,unit_selling_price
--),b as
--(
--select MAX(total_cost_per_unit) as cost_per_unit,product_code
--from  ProductTable
--where total_unit_in <> remaining_unit --i.e only sold products
--group by product_code
--) 

--select distinct a.product_code,a.unit_selling_price as selling_price_per_unit,b.cost_per_unit,a.sum_qty
--from a
--left join b
--on a.product_code =b.product_code 


-- bill tab

--select td.bill_number,td.product_code,td.product_type, td.quantity ,td.unit_selling_price , td.total_selling_price, tt.transaction_date,tt.discount as total_discount,tt.payment_method, tt.total_amount as total_bill_amount
--from TransactionTable tt
--inner join TransactionDetail td
--on tt.bill_number = td.bill_number
--order by td.bill_number


--select td.bill_number,td.product_code,td.product_type, td.quantity ,td.unit_selling_price , td.total_selling_price, tt.transaction_date,tt.discount as total_discount,tt.payment_method, tt.total_amount as total_bill_amount
--from TransactionTable tt
--inner join TransactionDetail td
--on tt.bill_number = td.bill_number
--where td.bill_number in (1)
--order by td.bill_number