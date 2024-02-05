//create table product_manufacturers(
//    manufacturer_id int,
//    manufacturer_name varchar(255)
//)

//create table product_suppliers(
//    supplier_id int,
//    supplier_name varchar(255)
//)

//create table product_titles(
//    product_title_id int,
//    product_title varchar(255),
//    product_category_id int
//)
//create table product_categories(
//    category_id int,
//    category_name varchar(255)
//)
//create table shop_products(
//    product_id int,
//    product_title_id int,
//    product_manufacturer_id int,
//    product_supplier_id int,
//    unit_price money,
//    comment text
//)
//create table customer_orders(
//    customer_order_id int,
//    operation_time timestamp,
//    supermarket_location_id int,
//    customer_id int
//)

//create table customer_order_details(
//    customer_order_detail_id int,
//    customer_order_id int,
//    product_id int,
//    price money,
//    price_with_discount decimal,
//    product_amount int
//)



//create table person_contacts(
//    person_contact_id int,
//    person_id int,
//    contact_type_id int,
//    contact_value varchar(255)
//)

//create table persons(
//    person_id int,
//    person_first_name varchar(255),
//    person_last_name varchar(255),
//    person_birth_date date
//)
//create table customers(
//    customer_id int,
//    card_number char(16),
//    discount int
//)
//create table contact_types(
//    contact_type_id int,
//    contact_type_name varchar(255)
//)

//create table supermarket_locations(
//    supermarket_location_id  int,
//    supermarket_id int,
//    location_id int
//)

//create table locations(
//    location_id int,
//    location_address varchar(255),
//    location_city_id int
//)

//create table loction_city(
//    city_id int,
//    city varchar(255),
//    country varchar(255)
//)
//create table supermarkets(
//    supermarket_id int,
//    supermarket_name varchar(255)
//)


//using System.Diagnostics.Metrics;
//ALTER TABLE ONLY public.contact_types
//    ADD CONSTRAINT contact_types_pkey PRIMARY KEY (contact_type_id);

//ALTER TABLE ONLY public.customer_order_details
//    ADD CONSTRAINT customer_order_details_pkey PRIMARY KEY (customer_order_detail_id);

//ALTER TABLE ONLY public.customer_orders
//    ADD CONSTRAINT customer_orders_pkey PRIMARY KEY (customer_order_id);

//ALTER TABLE ONLY public.location_city
//    ADD CONSTRAINT location_city_pkey PRIMARY KEY (city_id);

//ALTER TABLE ONLY public.locations
//    ADD CONSTRAINT locations_pkey PRIMARY KEY (location_id);

//ALTER TABLE ONLY public.person_contacts
//    ADD CONSTRAINT person_contacts_pkey PRIMARY KEY (person_contact_id);

//ALTER TABLE ONLY public.persons
//    ADD CONSTRAINT persons_pkey PRIMARY KEY (person_id);

//ALTER TABLE ONLY public.customers
//    ADD CONSTRAINT pk_customer PRIMARY KEY (customer_id);

//ALTER TABLE ONLY public.product_categories
//    ADD CONSTRAINT product_categories_category_name_key UNIQUE (category_name);

//ALTER TABLE ONLY public.product_categories
//    ADD CONSTRAINT product_categories_pkey PRIMARY KEY (category_id);

//ALTER TABLE ONLY public.product_manufacturers
//    ADD CONSTRAINT product_manufacturers_manufacturer_name_key UNIQUE (manufacturer_name);

//ALTER TABLE ONLY public.product_manufacturers
//    ADD CONSTRAINT product_manufacturers_pkey PRIMARY KEY (manufacturer_id);

//ALTER TABLE ONLY public.product_suppliers
//    ADD CONSTRAINT product_suppliers_pkey PRIMARY KEY (supplier_id);

//ALTER TABLE ONLY public.product_suppliers
//    ADD CONSTRAINT product_suppliers_supplier_name_key UNIQUE (supplier_name);

//ALTER TABLE ONLY public.product_titles
//    ADD CONSTRAINT product_titles_pkey PRIMARY KEY (product_title_id);

//ALTER TABLE ONLY public.product_titles
//    ADD CONSTRAINT product_titles_product_title_key UNIQUE (product_title);

//ALTER TABLE ONLY public.shop_products
//    ADD CONSTRAINT shop_products_pkey PRIMARY KEY (product_id);

//ALTER TABLE ONLY public.supermarket_locations
//    ADD CONSTRAINT supermarket_locations_pkey PRIMARY KEY (supermarket_location_id);

//ALTER TABLE ONLY public.supermarkets
//    ADD CONSTRAINT supermarkets_pkey PRIMARY KEY (supermarket_id);


//ALTER TABLE ONLY public.customer_order_details
//    ADD CONSTRAINT customer_order_details_customer_order_id_fkey FOREIGN KEY (customer_order_id) REFERENCES public.customer_orders(customer_order_id);

//ALTER TABLE ONLY public.customer_order_details
//    ADD CONSTRAINT customer_order_details_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.shop_products(product_id);

//ALTER TABLE ONLY public.customer_orders
//    ADD CONSTRAINT customer_orders_customer_id_fkey FOREIGN KEY (customer_id) REFERENCES public.customers(customer_id);

//ALTER TABLE ONLY public.customer_orders
//    ADD CONSTRAINT customer_orders_supermarket_location_id_fkey FOREIGN KEY (supermarket_location_id) REFERENCES public.supermarket_locations(supermarket_location_id);

//ALTER TABLE ONLY public.customers
//    ADD CONSTRAINT customers_customer_id_fkey FOREIGN KEY (customer_id) REFERENCES public.persons(person_id);

//ALTER TABLE ONLY public.locations
//    ADD CONSTRAINT locations_location_city_id_fkey FOREIGN KEY (location_city_id) REFERENCES public.location_city(city_id);

//ALTER TABLE ONLY public.person_contacts
//    ADD CONSTRAINT person_contacts_contact_type_id_fkey FOREIGN KEY (contact_type_id) REFERENCES public.contact_types(contact_type_id);

//ALTER TABLE ONLY public.person_contacts
//    ADD CONSTRAINT person_contacts_person_id_fkey FOREIGN KEY (person_id) REFERENCES public.persons(person_id);

//ALTER TABLE ONLY public.product_titles
//    ADD CONSTRAINT product_titles_product_category_id_fkey FOREIGN KEY (product_category_id) REFERENCES public.product_categories(category_id);

//ALTER TABLE ONLY public.shop_products
//    ADD CONSTRAINT shop_products_product_manufacturer_id_fkey FOREIGN KEY (product_manufacturer_id) REFERENCES public.product_manufacturers(manufacturer_id);

//ALTER TABLE ONLY public.shop_products
//    ADD CONSTRAINT shop_products_product_supplier_id_fkey FOREIGN KEY (product_supplier_id) REFERENCES public.product_suppliers(supplier_id);

//ALTER TABLE ONLY public.shop_products
//    ADD CONSTRAINT shop_products_product_title_id_fkey FOREIGN KEY (product_title_id) REFERENCES public.product_titles(product_title_id);

//ALTER TABLE ONLY public.supermarket_locations
//    ADD CONSTRAINT supermarket_locations_location_id_fkey FOREIGN KEY (location_id) REFERENCES public.locations(location_id);

//ALTER TABLE ONLY public.supermarket_locations
//    ADD CONSTRAINT supermarket_locations_supermarket_id_fkey FOREIGN KEY (supermarket_id) REFERENCES public.supermarkets(supermarket_id);



////13--
//UPDATE shop_products
//SET unit_price = unit_price+((unit_price / 100)*10)
//where product_title_id  in (select product_title_id from product_titles inner join 
//product_categories as pc on product_category_id=category_id  where pc.category_name = 'grocery') 
//and product_manufacturer_id = (select manufacturer_id from product_manufacturers where manufacturer_name = 'Orbit')


//15--
//select persons.person_first_name, persons.person_last_name, product_titles.product_title from customer_order_details
//inner join customer_orders  using (customer_order_id)
//    inner join product_titles on product_id=product_title_id
//inner join customers on customer_orders.customer_order_id=customers.customer_id
//inner join persons on customers.customer_id=persons.person_id
//where  persons.person_birth_date between '01-01-2000' and '01-01-2005'


//14--
//select person_first_name || '   ' || person_last_name as fullname, avg((price_with_discount::decimal)*product_amount) as avg_sum from customer_order_details
//inner join customer_orders using (customer_order_id)
//    inner join customers using (customer_id)
//    inner join persons on customers.customer_id=persons.person_id
//group by person_id
//having avg((price_with_discount::decimal)*product_amount)>200000
//order by avg((price_with_discount::decimal)*product_amount) desc, fullname asc


//20-savol
//CREATE or replace FUNCTION GETPRODUCTLISTBYOPERATIONDATE11(OPERATIONDATE date) RETURNS TABLE (P VARCHAR(255)) LANGUAGE PlpgSql AS $$
//begin
//return query select product_titles.product_title from customer_order_details
//inner join customer_orders using (customer_order_id)
//    inner join product_titles on product_titles.product_title_id= customer_order_details.product_id
//where DATE(operation_time)=operationDate;
//end; $$;

//select* from GETPRODUCTLISTBYOPERATIONDATE11('2011-03-24');


//25--
//create view Customer_details as
//select person_first_name|| ' ' || person_last_name as Full_name,
//person_birth_date, cu.card_number
//from persons inner join customers as cu on person_id=customer_id
