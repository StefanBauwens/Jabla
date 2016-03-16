using UnityEngine;
using System.Collections;

public class Book : BaseItem {
    //book in which you can read after pressing button

    public TextAsset bookContent;
    public string itemName;
    public string itemDescription;

    //constructors
    public Book()
    {
        itemName = "Stupid book.";
        itemDescription = "Just a stupid book";
    }
    public Book(string name, string description): base(name, description)
    {
        itemName = name;
        itemDescription = description;
    }
   
   
}
