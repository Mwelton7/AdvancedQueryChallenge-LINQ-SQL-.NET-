/* Matt Welton

 */


using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

class LINQQueryExpressions
{
    //constructors for Item class
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string serialNumber { get; set; }
        public int cost { get; set; }
        public int salePrice { get; set; }
        public string salesPerson { get; set; }
    }

    public static void Main(string[] args)
    {
   
            // Create a List of Item Objects called soldItems
            List<Item> soldItems = new List<Item>()
        {
            new Item {id = 1,name = "Rock Salt",serialNumber = "RS1",cost = 10,salePrice = 50,salesPerson = "Andy Ghadban"},
            new Item {id = 2,name = "Planter's Nuts",serialNumber = "XO28-V",cost = 4,salePrice = 23,salesPerson = "Reginald VelJohnson" },
            new Item {id = 3,name = "Bulk Pack SuperWash Fire Hoses",serialNumber = "BPSW-FH3",cost = 122,salePrice = 122,salesPerson = "Harry Lewis" },
            new Item {id = 4,name = "BlackBOX carnival sticks",serialNumber = "BBOX4",cost = 215,salePrice = 460,salesPerson = "Jean-Luc Picard"},
            new Item {id = 5,name = "ARMY surplus Canned Beef",serialNumber = "5-ARMYCB",cost = 34,salePrice = 513,salesPerson = "Jean-Luc Picard"},
            new Item {id = 6,name = "Compressed Air",serialNumber = "CA6",cost = 80,salePrice = 900,salesPerson = "Frank Castle"},
            new Item {id = 7,name = "Rock Salt",serialNumber = "RS1",cost = 10,salePrice = 2,salesPerson = "Reginald VelJohnson"},
            new Item {id = 8,name = "Werther's Original",serialNumber = "WO-8",cost = 12,salePrice = 75,salesPerson = "Andy Ghadban"},
            new Item {id = 9,name = "tonka truck passenger door",serialNumber = "TT-PD-9",cost = 336,salePrice = 275,salesPerson = "Jean-Luc Picard"},
            new Item {id = 10,name = "ARMY surplus Canned Beef",serialNumber = "5-ARMYCB",cost = 12,salePrice = 6000,salesPerson = "Frank Castle"},
            new Item {id = 11,name = "SwashBuckler's Buckled Swashes",serialNumber = "SBBS11",cost = 122,salePrice = 160,salesPerson = "Harry Lewis"},
        };
            /*Query the data structure List<Items> soldItems group by salesPerson into a new collection of anonymous objects 
            *salesPerson will be the key and totalSales will be the total sum of the difference of salePrice and cost(profits) for each respective salesPerson*/
                 var mostProfitable = from item in soldItems
                                     group item by item.salesPerson into salesPersonGroup
                                     select new
                                 {
                                     salesPerson = salesPersonGroup.Key,
                                     totalSales = salesPersonGroup.Sum(x => x.salePrice - x.cost)
                                 };
        /*Execute OrderByDescending on mostProfitable to sort elements of the collection by totalSales with respect to the Key (salesPerson)
        *The resulting collection is sorted in descending order of the overall most profitable salespeople 
        *This collection will be used when executing the final query*/
                mostProfitable = mostProfitable.OrderByDescending(x => x.totalSales);

        /*Creates a new list with only the items that were sold more than once
        *Call Except on soldItems to find the difference of the Grouping of soldItems by name and select only the first time a name was found
        *Any product names that were found to be duplicates are removed from soldItems and stored in duplicateItems as a List()*/
               var duplicateItems = soldItems.Except(soldItems.GroupBy(a => a.name)
               .Select(b => b.FirstOrDefault())).ToList();

        /*Remove duplicate items found from the original list soldItems that were discovered in the last GroupBy / Select
        *This is to ensure products after query were sold EXACTLY once*/

              soldItems.RemoveAll(x => duplicateItems.Any(y => y.name == x.name));

        /*After soldItems has been filtered to represent Items sold exactly once I perform a query on soldItems
        *"Where" salePrice - cost = true which filters for only profitable items
        *And "Where" Compare the Concatination of Uppercase characters found in each soldItem name with each soldItem ID converted to a string
        *with each soldItem serialNumber by using the CompareOptions System.Globalization function to ignore case and symbols is true
        *select the items that pass both "where" conditions and their fields*/

             var queryFinal = from item in soldItems
                             where item.salePrice - item.cost > 0
                             && String.Compare(String.Concat(item.name.Where(x => Char.IsUpper(x))
                             .Concat(item.id.ToString())), item.serialNumber, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0
                             select (item.id, item.name, item.serialNumber, item.cost, item.salePrice, item.salesPerson);

        /*Execute the query in a nested foreach loop
        *Outerloop is the anonymous collection of objects created from the first query performed (mostProftiable) that has been sorted in descending order 
        *of most overall profitable salespersons
        *Innerloop checks for the most profitable salesperson found both in mostProfitable salespeople and queryFinal using String.Equals
        *The data pull results in each item being displayed in descending order of the overall most profitable salespeople */

        Console.WriteLine("Query Execution: ");
            foreach (var person in mostProfitable)
            {
                foreach (var item in queryFinal)
                {
                    if (String.Equals(person.salesPerson, item.salesPerson))
                    {
                        Console.WriteLine("ID: " + item.id + " Name: " + item.name + " Serial: " + item.serialNumber + " Cost: " + item.cost + " SalePrice: " + item.salePrice + " SalesPerson: " + item.salesPerson);

                    }
                }
            }
        Console.WriteLine("Press enter to close...");
        Console.ReadLine();

        /*Output:
            Query Execution:
            ID: 6 Name: Compressed Air Serial: CA6 Cost: 80 SalePrice: 900 SalesPerson: Frank Castle
            ID: 4 Name: BlackBOX carnival sticks Serial: BBOX4 Cost: 215 SalePrice: 460 SalesPerson: Jean-Luc Picard
            ID: 8 Name: Werther's Original Serial: WO-8 Cost: 12 SalePrice: 75 SalesPerson: Andy Ghadban
            ID: 11 Name: SwashBuckler's Buckled Swashes Serial: SBBS11 Cost: 122 SalePrice: 160 SalesPerson: Harry Lewis

        Time and Space efficiency are both O(n) linear with respect to the number of Item objects in the data structure*/




    }
}

