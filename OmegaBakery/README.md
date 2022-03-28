*this report must contain:*
- Description of the system
- Objectives of the design patterns
- UML structure for classes

# OmegaBakery
OmegaBakery is a console application which acts as the front for a store where customers view and buy products from. 
At the initial stages, the application is programmed to work for a fictional Bakery business, which sells baked goods made in-house as well as items manufactured by other companies.
It is designed in such a way that it can be easily extended to other businesses with minimal code changes.

The application aims to provide basic functionalities like view items available, add to order, apply discounts, and checkout order.

## Products
![](img/Product.png)
There are two types of products that are supported by the application: in-house products which are produced inside the store and outside products which are purchased from other manufacturers and sold in store.
This necessitates the need for an **Abstract Factory pattern**, so that the app can be extended to more product lines apart from the Bakery.
A product stock manager manages the available count of product stock during operation. The stock manager is implemented as a singleton since multiple objects deducing stock count need to be avoided.

## Discounts
![](img/IDiscount.png)
Discounts represent a reduction in cost on specific purchases based on product types and quantities. A discount will only apply to ILineItem objects that meet pass a **Predicate** passed into the discount on instantiation. The **Strategy** design pattern is used for the discount subtotal calculation allowing us to use several types of discounts:
- **FlatDiscountStrategy**: Removes a flat dollar amount from the subtotal
- **PercentDiscountStrategy**: Removes a percentage of the subtotal
- **BogoDiscount**: Removes the cost of 1 item for every 2 items purchased

Discounts can be easily extended in the future to accommodate different discount conditions.

Discounts are applied to **ILineItem**s through the **DiscountedLineItem** class, which is an extension of **CompositeLineItem**. When an **ILineItem** is updated such that a discount is no longer applicable, the **DiscountedLineItem** class behaves the same as a **CompositeLineItem**. 

Discounts require flexibility for how they are applied to line items. For example, the same discount could apply in these three orders:

- A single line item of 12 plain bagels
- 3 line items, each containing 4 bagels of a unique flavour
- A line item that has already been discounted for clearance
****

## Line Items
![](img/ILineItem.png)
Line Items use the **composite** design pattern, which allows us to apply *IDiscount*s to either a single line item or multiple line items

## Orders
An **Order** represents the current state of a user's cart. It contains the logic for adding items to a purchase, updating item count, and applying discounts.

To simplify the process of applying discounts, line items are automatically grouped into CompositeLineItems of the same ProductType.

## Administration
Administration provides the following features:
- Ability for administrator to login using a username and password which presently saved in the appsettings
- Ability to change the username and password for the administrator login
- Ability to change the path and names of the data files from which data is retrieved, which are now saved in the appsettings

appsettings.json is a json file which stores app related information and is accessed using the AppService class, which utilises the Newtonsoft Json package.

## Data
DataService is follows a **Facade** pattern wherein it interacts with all data related subsystems instead of the client directly accessing these subsystems.
In this light, it is also implemented as a **singleton** because multiple data access at the same time needs to be avoided.
At present it provides functionality to retrieve product data from the csv files through the CsvService Subsystem, but can be easily extended with other data fetching subsystems.

The CsvService uses the package CsvHelper to read and write to the csv file whose name and location are stored in the appsettings.