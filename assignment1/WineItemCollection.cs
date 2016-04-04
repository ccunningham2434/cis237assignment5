//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class WineItemCollection : IWineCollection
    {
        // >
        BeverageCCunninghamEntities beverageCCunninghamEntities;


        //Constuctor. Must pass the size of the collection.
        public WineItemCollection()
        {
            // >Make a new instance of the beverages collection.
            beverageCCunninghamEntities = new BeverageCCunninghamEntities();
        }

        //Add a new item to the collection
        public void AddNewItem(string id, string description, string pack)
        {
            // >Create a new beverage.
            Beverage newBeverage = new Beverage();

            // >Assign the properties.
            newBeverage.id = id;
            newBeverage.name = description;
            newBeverage.pack = pack;

            // >Add the beverage to the collection.
            beverageCCunninghamEntities.Beverages.Add(newBeverage);

            // >Persist changes to the database.
            beverageCCunninghamEntities.SaveChanges();
        }
        
        //Get The Print String Array For All Items
        public string[] GetPrintStringsForAllItems()
        {
            
            //Create and array to hold all of the printed strings
            string[] allItemStrings = new string[beverageCCunninghamEntities.Beverages.Count()];
            //set a counter to be used
            int counter = 0;

            //If the wineItemsLength is greater than 0, create the array of strings
            if (beverageCCunninghamEntities.Beverages.Count() > 0)
            {
                //For each item in the collection
                foreach (Beverage beverage in beverageCCunninghamEntities.Beverages)
                {
                    //if the current item is not null.
                    if (beverage != null)
                    {
                        //Add the results of calling ToString on the item to the string array.
                        allItemStrings[counter] = beverage.id.Trim() + " " + beverage.active + " " + beverage.name.Trim() + " " + beverage.pack.Trim() + " " + beverage.price;
                        counter++;
                    }
                }
            }
            //Return the array of item strings
            return allItemStrings;
        }

        ////Find an item by it's Id
        public string FindById(string id)
        {
            //Declare return string for the possible found item
            string returnString = null;

            //For each WineItem in wineItems
            foreach (Beverage beverage in beverageCCunninghamEntities.Beverages)
            {
                //If the beverage is not null
                if (beverage != null)
                {
                    //if the beverage Id is the same as the search id
                    if (beverage.id == id)
                    {
                        //Set the return string
                        returnString = beverage.id.Trim() + " " + beverage.active + " " + beverage.name.Trim() + " " + beverage.pack.Trim() + " " + beverage.price;
                    }
                }
            }
            //Return the returnString
            return returnString;
        }

        // >Update an Item.
        public void UpdateItem(string id, string description, string pack)
        {
            // >Get the beverage from the collection.
            Beverage bevargeToUpdate = beverageCCunninghamEntities.Beverages.Find(id);

            // >Assign the properties.
            //bevargeToUpdate.id = id;
            bevargeToUpdate.name = description;
            bevargeToUpdate.pack = pack;

            // >Persist changes to the database.
            beverageCCunninghamEntities.SaveChanges();
        }

        // >Delete an item.
        public void DeleteItem(string id)
        {
            // >Get the beverage.
            Beverage beverageToDelete = beverageCCunninghamEntities.Beverages.Find(id);

            // >Remove the beverage from the collection.
            beverageCCunninghamEntities.Beverages.Remove(beverageToDelete);

            // >Persist changes to the database.
            beverageCCunninghamEntities.SaveChanges();
        }


    }
}
