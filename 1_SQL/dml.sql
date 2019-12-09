use AdventureWorks2017;
go 

select 1 + 1;

select * 
from Person.Person;

select firstname, lastname, middlename 
from Person.Person

select firstname, lastname, middlename
from Person.Person 
where firstname = 'robert';

select firstname, lastname, middlename
from Person.Person 
where firstname = 'robert' or firstname = 'john';

select firstname, lastname, middlename
from Person.Person 
where firstname <> 'robert' and firstname <> 'john';

select firstname, lastname, middlename
from Person.Person 
where firstname like '%robert%' or firstname like 'robert_' or firstname like 'r[aeiou]%';





--mode of execution
/*
FROM
WHERE
GROUP BY
HAVING 
SELECT
ORDER BY
*/


--update 

update Person.Person
set firstname = 'john'
where firstname = 'robert';

--find anybody with lastname of jones and replace it with rober (like it was a different table)
update pp
set firstname = 'robert'
from Person.Person as pp
where pp.LastName = 'jones' 

-- delete 
delete 
from Person.Person 
where MiddleName is null and FirstName = 'xavier';

--inner join 
select pp.firstname, pp.lastname, pa.addressline1, pa.city, pa.postalcode
from Person.Person as pp 
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityID = pp.BusinessEntityID
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
where pp.firstname = 'jimmy';

--inner join to find product that jimmy bnought 
select pp.firstname, pp.lastname,ppt.Name, ssoh.OrderDate
from Person.Person as pp 
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityID = pp.BusinessEntityID
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pp.BusinessEntityID
inner join Sales.SalesOrderHeader as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssod.SalesOrderID = ssoh.SalesOrderId
inner join Production.product as ppt on ppt.ProductID = ssod.ProductID
where pp.firstname = 'jimmy' and datepart(month, ssoh.OrderDate) = 6 and month(ssoh.OrderDate) = 6

--inner join to find the tires that jimmy bought (need a like operators)
select pp.firstname, pp.lastname,ppt.Name, ssoh.OrderDate
from Person.Person as pp 
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityID = pp.BusinessEntityID
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pp.BusinessEntityID
inner join Sales.SalesOrderHeader as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssod.SalesOrderID = ssoh.SalesOrderId
inner join Production.product as ppt on ppt.ProductID = ssod.ProductID
where pp.firstname = 'jimmy' and datepart(month, ssoh.OrderDate) = 6 and ppt.Name like '%tire%';


--subqueries 
select pp.firstname, pp.lastname,ppt.Name, ssoh.OrderDate
from Person.Person as pp 
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityID = pp.BusinessEntityID
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pp.BusinessEntityID
inner join 
(
    select salesorderid, customerid, OrderDate
    from Sales.SalesOrderHeader
    where datepart(month, OrderDate) = 7
) as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssod.SalesOrderID = ssoh.SalesOrderId
inner join 
(
    select productid, name 
    from Production.Product
    where name like '%tire%'
) as ppt on ppt.ProductID = ssod.ProductID
where pp.firstname = 'jimmy';

--common table expression 

with OrderHeader as 
(
    select salesorderid, customerid, OrderDate
    from Sales.SalesOrderHeader
    where datepart(month, OrderDate) = 7
),
Product as 
(
    select productid, name 
    from Production.Product
    where name like '%tire%'
)
select pp.firstname, pp.lastname,ppt.Name, ssoh.OrderDate
from Person.Person as pp 
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityID = pp.BusinessEntityID
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pp.BusinessEntityID
inner join Sales.SalesOrderHeader as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssod.SalesOrderID = ssoh.SalesOrderId
inner join Product as ppt on ppt.ProductID = ssod.ProductID
where pp.firstname = 'jimmy'

--union 

select distinct pp1.firstname, pp2.lastname 
from Person.Person as pp1
inner join Person.Person as pp2 on pp2.lastname = pp1.FirstName;

select firstname 
from Person.Person 
intersect
select lastname 
from Person.Person 

