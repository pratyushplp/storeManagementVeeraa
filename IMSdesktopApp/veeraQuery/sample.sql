

/* Create a table called data */
CREATE TABLE data(
date_transaction date,
payment_method varchar(200),
bank_name varchar(200),
total_amt float,
total_qty int
);

/* Create few records in this table */
INSERT INTO data 
VALUES
('2019-11-01','Cash', '', 5000, 5),
('2019-11-01','Credit Card', 'Laxmi', 4000, 2),
('2019-11-01','Cash', '', 200, 1),
('2019-12-01','Credit Card', 'NIBL', 1200, 1),
('2019-12-01','Cash', '', 600, 1),
('2019-10-01','Credit Card', 'HBL', 400, 1),
('2019-10-01','Cash', '', 2000, 1);


/* Display all the records from the table */
SELECT * FROM data;

use VEERA

select CAST(transaction_date as date) ,total_amount
from TransactionTable
 where payment_method='cash'

payment_method
Cash
Cash

with a as
(
	select cast(transaction_date as date) as 'Date',  sum(total_amount) as sum_total_amt, sum(total_qty) as sum_total_qty
	from TransactionTable
	where payment_method = 'Cash'
	group by cast(transaction_date as date) 
),b as 
(
	select cast(transaction_date as date) as "Date",  sum(total_amount) as sum_total_amt, sum(total_qty) as sum_total_qty
	from TransactionTable
	where payment_method = 'Credit Card'
	group by  cast(transaction_date as date)
)
select distinct a.Date, a.sum_total_amt as "Cash_Payment", b.sum_total_amt as "Credit_Payment", (a.sum_total_amt + b.sum_total_amt) as "Total_amt", (a.sum_total_qty + b.sum_total_qty) as "Total_Qty"
from  a
join  b
on a.Date = b.Date




                            with a as
                            (
	                         select cast(transaction_date as date) as 'trans_date',  sum(total_amount) as sum_total_amt, sum(total_qty) as sum_total_qty
	                         from TransactionTable
	                         where payment_method = 'Cash'
	                         group by cast(transaction_date as date) 
                             ),b as 
                            (
	                        select cast(transaction_date as date) as 'trans_date',  sum(total_amount) as sum_total_amt, sum(total_qty) as sum_total_qty
                            from TransactionTable
                            where payment_method = 'Credit Card'
                            group by cast(transaction_date as date)
                            )
                            select distinct a.trans_date, a.sum_total_amt as 'cash_amt', b.sum_total_amt as 'credit_card_amt', (a.sum_total_amt + b.sum_total_amt) as 'total_amt', (a.sum_total_qty + b.sum_total_qty) as 'total_qty'
                            from a
                            join b
                            on a.trans_date = b.trans_date
                            WHERE a.trans_date BETWEEN CAST('11/17/2019 12:00:00 AM' as date) AND CAST('11/17/2019 12:00:00 AM' as date)




							select from transactionTable
							select sum(quantity),product_code,product_type,unit_selling_price from transactionDetail
							group by product_code,product_type,unit_selling_price

							
							with a as
							(
							select  product_code, product_type, unit_selling_price,sum(quantity) as sumQty
							from transactionDetail
							where bill_number in (select bill_number from transactionTable where transaction_date between '2019-11-17' AND '2019-11-18')
							group by product_code,product_type,unit_selling_price
							),b as
							(
							select distinct total_cost_per_unit as cost_per_unit,product_code 
							from  ProductTable
							) 
							select distinct a.product_code, b.product_type,



							  select @@version




