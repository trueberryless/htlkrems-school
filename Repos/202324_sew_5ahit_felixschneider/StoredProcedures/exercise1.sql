# Task 1

delimiter //

drop procedure if exists p_count_order_by_status;

create procedure p_count_order_by_status()
begin
    select o.status, count(*) as orderCount
    from orders o
    group by o.status;
end //

delimiter ;

call p_count_order_by_status();

# Task 2

drop procedure if exists p_count_order_by_status_in_parameter;

create procedure p_count_order_by_status_in_parameter(
    in pStatus varchar(255)
)
begin
    select pStatus, count(*) as orderCount
    from orders o
    where status = pStatus;
end;

call p_count_order_by_status_in_parameter('On Hold');

# Task 3

drop procedure if exists p_count_order_by_status_out_parameter;

create procedure p_count_order_by_status_out_parameter(
    in pStatus varchar(255),
    out pTotalCount int
)
begin
    select count(*) as orderCount
    into pTotalCount
    from orders o
    where status = pStatus;
end;

call p_count_order_by_status_out_parameter('In Process', @count);

select @count;

# Task 4

drop procedure if exists p_create_report;

create procedure p_create_report()
begin
    create table if not exists report
    (
        reportDate  datetime default current_timestamp,
        salesRep    varchar(255),
        customer    varchar(255),
        countOrders int,
        totalSales  decimal(10, 2)
    );

    insert into report (salesRep, customer, countOrders, totalSales)
    select concat(e.firstName, ' ', e.lastName)   as salesRep,
           c.customerName                         as customer,
           count(distinct o.orderNumber)          as countOrders,
           sum(od.priceEach * od.quantityOrdered) as totalCost
    from orders o
             inner join orderdetails od on o.orderNumber = od.orderNumber
             inner join customers as c on o.customerNumber = c.customerNumber
             inner join employees e on c.salesRepEmployeeNumber = e.employeeNumber
    group by salesRep, customer;
end;

call p_create_report();

select *
from report;

# Task 5

drop procedure if exists p_create_customer;

create procedure p_create_customer(
    in pCustomerName varchar(255),
    in pContactFirstName varchar(255),
    in pContactLastName varchar(255),
    in pEmployeeNumber int
)
begin
    declare maxCustomerNumber int;

    select max(customerNumber) into maxCustomerNumber from customers;

    insert into customers (customerNumber, customerName, contactLastName, contactFirstName, phone, addressLine1,
                           addressLine2, city, state, postalCode, country, salesRepEmployeeNumber, creditLimit)
        value (maxCustomerNumber + 1, pCustomerName, pContactFirstName, pContactLastName, '40.32.2555',
               '54, rue Royale', NULL, 'Nantes', NULL, '44000', 'France', pEmployeeNumber, '21000.00');
end;

drop trigger if exists tr_create_customer_after_insert_on_employee;

create trigger tr_create_customer_after_insert_on_employee
    after insert
    on employees
    for each row
begin
    call p_create_customer(concat(new.firstName, ' ', new.lastName), new.firstName, new.lastName, new.employeeNumber);
end;

insert into employees (employeeNumber, lastName, firstName, extension, email, officeCode, reportsTo, jobTitle)
values (10001, 'Doe_trigger', 'John', 'x4611', 'abc@mybusiness.at', '1', null, 'Sales Rep');