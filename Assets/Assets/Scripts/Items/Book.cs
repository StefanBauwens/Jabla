using UnityEngine;
using System.Collections;

public class Book : BaseItem {
    //book in which you can read after pressing button

    public TextAsset bookContent;
	public string[] bookPages; //each element of this array is a page

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
   
	void Start() {
	}
   
}
