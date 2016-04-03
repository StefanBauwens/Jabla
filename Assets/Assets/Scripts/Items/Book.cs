using UnityEngine;
using System.Collections;
using UnityEngine.UI; //add to access things in UI in Unity 5


public class Book : BaseItem {
    //book in which you can read after pressing button
	public GameObject playerObject;
	public GameObject bookObject;
    protected Text bookPage1;
	protected Text bookPage2;
	public string[] bookPages; //each element of this array is a page

	protected Button nextButton;
	protected Button prevButton;
	protected Button closeButton;

	public GameObject bookObjectCopy;

	protected int pageNumber = 0;

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
		bookObjectCopy = Instantiate (bookObject);
		bookObject.SetActive (false);//
		bookObjectCopy.SetActive(false);//hides the bookobjects
		foreach (var item in bookObjectCopy.GetComponentsInChildren<Button>()) { //gets the buttons from the bookObjectcopy
			if (item.tag == "nextPage") {
				nextButton = item;
			}
			if (item.tag == "prevPage") {
				prevButton = item;
			}
			if (item.tag == "closeButton") {
				closeButton = item;
			}
		}
		foreach (var item in bookObjectCopy.GetComponentsInChildren<Text>()) { //gets the text from the bookObjectcopy
			if (item.tag=="pageOne") {
				bookPage1 = item;
			}
			if (item.tag=="pageTwo") {
				bookPage2 = item;
			}
		}

		//add listeners for buttons	== telling the buttons which function they need to call
		nextButton.onClick.AddListener(() => PressButtonNext());
		prevButton.onClick.AddListener(() => PressButtonPrev());
		closeButton.onClick.AddListener(() => PressButtonClose());

		DrawPage ();
	}

	void Update() {
		if (this.gameObject == playerObject) {
			if (playerObject.GetComponent<Inventory2>()._InventoryActive && Input.GetKeyDown(KeyCode.R)) {
				bookObjectCopy.SetActive (true);
			}
		}
	}

	void PressButtonNext() {
		if (pageNumber + 2 < bookPages.Length) {
			pageNumber += 2; //2?
			DrawPage ();
		}
	}

	void PressButtonPrev(){
		if (pageNumber >= 2) {
			pageNumber -= 2;
			DrawPage ();
		}
	}

	void PressButtonClose(){
		bookObjectCopy.SetActive (false);
	}

	void DrawPage() { //"draws" the text when you go to next page
		if (pageNumber == 0) {
			prevButton.interactable = false;
		} else {
			prevButton.interactable = true;
		}

		if (pageNumber+2 == bookPages.Length) {
			nextButton.interactable = false;
		} else {
			nextButton.interactable = true;
		}
			
		bookPage1.text = bookPages[pageNumber];
		bookPage2.text = bookPages [pageNumber + 1];
	}

   
}
