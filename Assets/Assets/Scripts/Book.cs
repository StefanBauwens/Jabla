using UnityEngine;
using System.Collections;

public class Book : Items {
    //book in which you can read after pressing button
    public TextAsset bookContent;

    //constructors
    public Book(string name, string description): base(name, description)
    {

    }


}
