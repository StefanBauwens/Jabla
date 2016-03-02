using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour {
    //book in which you can read after pressing button

    /*public TextAsset bookContent;

    //constructors
    public Book(string name, string description): base(name, description)
    {

    }
    */

    protected BaseItem newBook;

    //methods
    protected void CreateBook()
    {
        newBook = new BaseItem();
        newBook.itemName = "Book";
        newBook.itemDescription = "Most evil book on earth.";
    }
}
