use VEERA 
select * from TransactionTable
select * into #temp from fourth_shipment 
--drop table fourth_shipment
--drop table  #temp

select total_unit_inward  from #temp

--select * into #temp from fourth_shipment

-- NOTE: script to remove all the commas from the UNIT_PRICE_INR,UNIT_PRICE_NPR,CARRIER_CHARGE_PER_UNIT,TOTAL_DIRECT_COST_PER_UNIT_NPR,SELLING_PRICE column

select UNIT_PRICE_INR,UNIT_PRICE_NPR,CARRIER_CHARGE_PER_UNIT,TOTAL_DIRECT_COST_PER_UNIT_NPR,SELLING_PRICE from #temp
update #temp set UNIT_PRICE_INR=REPLACE(UNIT_PRICE_INR,',',''), UNIT_PRICE_NPR=REPLACE(UNIT_PRICE_NPR,',',''),TOTAL_UNIT_IN = , CARRIER_CHARGE_PER_UNIT=REPLACE(CARRIER_CHARGE_PER_UNIT,',',''), TOTAL_DIRECT_COST_PER_UNIT_NPR= REPLACE(TOTAL_DIRECT_COST_PER_UNIT_NPR,',',''), SELLING_PRICE= REPLACE(SELLING_PRICE,',','')


-- NOTE: the casting worked because all the commas were removed
select  CAST(UNIT_PRICE_INR AS FLOAT) from #temp

-- NOTE:-the scripts dump the cleaned and transformed value from temp 1 to temp 2
SELECT PRODUCT_TYPE,BRAND_CODE,CODE,DELIVERY_AGENT,VENDOR,CAST(UNIT_PRICE_INR AS FLOAT) as a,CAST(UNIT_PRICE_NPR AS FLOAT) as b,CAST(total_unit_inward AS FLOAT) as c,MODEL_NO as d ,CAST(CARRIER_CHARGE_PER_UNIT AS FLOAT) as e,CAST(TOTAL_DIRECT_COST_PER_UNIT_NPR AS FLOAT) as f,CAST(SELLING_PRICE AS FLOAT) as g INTO #temp2 FROM #temp

-- SHORTCUTS: alt + F1 to get all the columns and there information , does not work for temp table

select * from #temp2






select top 5 * from #temp
select PRODUCT_TYPE,* from fourth_shipment
select * product_type,brand_code,code,delivery_agent from ProductTable

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