using System;
using System.Collections.Generic;
namespace AdventureGame
{
    public class Item
    {
        public KeyValuePair<string, string> item = new KeyValuePair<string, string>();
        public Boolean hasFunction;
        int location;
        public Item(KeyValuePair<string, string> item, bool hasFunction, int location)
        {
            this.item = item;
            this.hasFunction = hasFunction;
            this.location = location;
        }
    }
}