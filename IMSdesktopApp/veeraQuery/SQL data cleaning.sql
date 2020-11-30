use VEERA 

select * from ProductTable

select * from TransactionTable
select * into #temp from [dbo].[1shipment]
--drop table fourth_shipment
--drop table  #temp

select total_unit_inward  from #temp

--select * into #temp from fourth_shipment

-- NOTE: script to remove all the commas from the UNIT_PRICE_INR,UNIT_PRICE_NPR,CARRIER_CHARGE_PER_UNIT,TOTAL_DIRECT_COST_PER_UNIT_NPR,SELLING_PRICE column

select UNIT_PRICE_INR,UNIT_PRICE_NPR,CARRIER_CHARGE_PER_UNIT,TOTAL_DIRECT_COST_PER_UNIT_NPR,SELLING_PRICE from #temp
update #temp set UNIT_PRICE_INR=REPLACE(UNIT_PRICE_INR,',',''), UNIT_PRICE_NPR=REPLACE(UNIT_PRICE_NPR,',',''), CARRIER_CHARGE_PER_UNIT=REPLACE(CARRIER_CHARGE_PER_UNIT,',',''), TOTAL_DIRECT_COST_PER_UNIT_NPR= REPLACE(TOTAL_DIRECT_COST_PER_UNIT_NPR,',',''), SELLING_PRICE= REPLACE(SELLING_PRICE,',','')


-- NOTE: the casting worked because all the commas were removed
select  CAST(UNIT_PRICE_INR AS FLOAT) from #temp

-- NOTE:-the scripts dump the cleaned and transformed value from temp 1 to temp 2
SELECT PRODUCT_TYPE,BRAND_CODE,CODE,DELIVERY_AGENT,VENDOR,CAST(UNIT_PRICE_INR AS FLOAT) as a,CAST(UNIT_PRICE_NPR AS FLOAT) as b,CAST(total_unit_inward AS FLOAT) as c , CAST(total_unit_inward AS FLOAT) as d ,CAST(CARRIER_CHARGE_PER_UNIT AS FLOAT) as e,CAST(TOTAL_DIRECT_COST_PER_UNIT_NPR AS FLOAT) as f,CAST(SELLING_PRICE AS FLOAT) as g INTO #temp2 FROM #temp

-- SHORTCUTS: alt + F1 to get all the columns and there information , does not work for temp table

-- delete values with product code null
-- DELETE from #temp2 where code is null 

select * from ProductTable
select  PRODUCT_TYPE,BRAND_CODE,CODE,DELIVERY_AGENT,VENDOR,a,b,c,d,e,f,g,SYSDATETIME() from #temp2

7
-- main query to insert data from temp to product table
-- insert into ProductTable
(product_type,
brand_code,
product_code,
delivery_agent,
vendor,
unit_price_INR,
unit_price_NPR,
total_unit_in,
remaining_unit,
carrier_charge_unit,
total_cost_per_unit,
selling_price,
added_date)
select  PRODUCT_TYPE,BRAND_CODE,CODE,DELIVERY_AGENT,VENDOR,a,b,c,d,e,f,g,SYSDATETIME()
from #temp2



select  PRODUCT_TYPE,BRAND_CODE,CODE,DELIVERY_AGENT,VENDOR,a,b,c,d,e,f,g,SYSDATETIME()
from #temp2



select top 5 * from #temp
select PRODUCT_TYPE,* from fourth_shipment
select  * from ProductTable

select CAST(UNIT_PRICE_INR AS FLOAT) as unit_price_inr,CAST(UNIT_PRICE_NPR AS FLOAT) as unit_price_npr from #temp
select * from fourth_shipment
select  CAST(UNIT_PRICE_INR AS FLOAT) from fourth_shipment


SELECT PRODUCT_TYPE,BRAND_CODE,CODE,DELIVERY_AGENT,VENDOR,CAST(UNIT_PRICE_INR AS FLOAT),CAST(UNIT_PRICE_NPR AS FLOAT),CAST(TOTAL_UNIT_IN AS FLOAT),MODEL_NO ,CAST(CARRIER_CHARGE_PER_UNIT AS FLOAT),CAST(TOTAL_DIRECT_COST_PER_UNIT_NPR AS FLOAT),CAST(SELLING_PRICE AS FLOAT) INTO #TEMP2 FROM FOURTH_SHIPMENT

 UNIT_PRICE_INR 
220
250
180
200
220