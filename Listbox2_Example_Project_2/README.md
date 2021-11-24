# Listbox Project 2

The tutorials are a series of Microsoft Visual Studio projects. In general:

1. Download each project ZIP file.
1. Expand it in your favorite location on your computer.
1. Double click the solution file (\*.sln).
1. From the Visual Studio main menu, select Start.
1. Follow the screen or project notes to operate the application.
Notes are provided in the individual project's README file. Comments may be inlined in the code.

## Running the Application
The application has four buttons:

- **Automatically add values**. Each time selecting this adds 30,000 values (displayed as zero through 29,999) to the existing list. 
- **Order by ascending**. Selecting this reorders the list in ascending order. Because the values are strings, they are sorted in alphabetic order, not numeric order.
- **Order by descending**. Selecting this reorders the list in descending order. Because the values are strings, they are sorted in alphabetic order, not numeric order.
- **Set to original order**. Selecting this sets the list to the original, or unsorted order.
- **Find with the number**. Selecting this filters to the list to show only values with the number specified in the text box below.
- **Clear Listbox**. Selecting this deletes the entire list and allows starting from a clean list.
You can examine the project's code to see how this is all done.

In the first tutorial, the basic approach is that items are added to the list through the line:

`listBox1.Items.Add(i);`

However, using `listBox1.Items.Add` is a slow and awkward way to add more than just a couple of items. If, for example, your application displays an employee database of perhaps a few hundred, listing the names, the loading processing will have a noticeable delay. If you're using it from a scientific application, loading thousands or perhaps literally billions of list items, the delay will be unacceptably long.

Listbox2_Example improves on this in two ways.

First, the source information is kept in a collection, specifically a List<string>. Collections are very efficient ways to store a lot of information in an application. The most basic of these collections is the array. .NET provides additional and specialized collections. The advantage is that they can managed quickly and convenientially. Management operations include adding, deleting, and sorting. The list is defined globally as `List<string> gStringsSource = new List<string>`
  
It's created artifically here. In a real application, the information source would likely be a file or real time input. The information is added to the list, rather than the listbox directly. As far as generating 30,000 entries, this is an effecient and quick way to collect information.
  
```
  long length = 30000;
  for (long i = 0; i < length; i++)
  {
    string theItem = string.Format("This is item: {0}", i);
    gStringsSource.Add(theItem);

    Application.DoEvents();
  }
```
More importantly here, they also allow filtering. That is, you can specify search criteria and using LINQ, Microsoft's query language, you can extract exactly the items you're looking for. That operation is quick. It also returns a new list object, leaving the original intact. Two LINQ commands used here:
```
  var descendingOrderList = myStringList.OrderByDescending(x => x).ToList();
  var numberList = gStringsSource.Where(s => s.Contains(theNumber.ToString())).ToList();
```
The first one reorders the existing list in descending order, alphabetic in this case because it's a string collection. The second command finds all instances with the selected number. In both cases, a second list is created. This leaves the original list intact so it can be used again.                                             
                              
Second, the data is added to the listbox through the DataSource property. Rather than adding listbox items one by one, as the  Listbox2_Example does, the entire list collection is added at one time. This is an extremely quick way of adding information. For example, Listbox2_Example creates a listbox of 30,000 items, as compared to the Listbox1_Example's four items. There is no noticable delay in adding populating the list. One note is that you can change the number of items to create. There will be an increasing delay as the value gets larger. That delay does not reflect on the speed to populate the listbox. Instead, that delay is the from the slowness of creating the sheer number of items. If you want to see that, set the value from 30,000 to one million. Start the application and step away to get coffee.
    
Finally, the actual assigng of the information to the list box:
```
listBox1.DataSource = null;
listBox1.DataSource = theList;
```
The first line clears the listbox of the previous information. The second line assigns the new information. The listbox knows about the collection's data format, and so can quickly populate the listbox.
  
The speed of populating the listbox is seen more in the **Order by** buttons. These do not create any new items, they just rearrange existing ones. With these, notice the small, if any, delay. In the same way, the **Find with the number** option is equally fast. This operation filters at least 30,000 items for a specific match, and then populates the list box. Again, with only the smallest of delays.

## Tutorial Examples
There are three example projects. Each project is standalone and you don't need previous projects to run another project. You don't even need to go through them sequentially, although if you're new to ListBoxes, consider going through each one in turn.

The topics are:

**Basic operations**. This (Listbox1_Example) is a good starting place and introduces the basics of ListBoxes.
**Using DataSource for speed and convenience**. This (Listbox2_Example) introduces using the Listbox DataSource property allows for extremely quick loading and convenience from an array or list.
**Using Objects in a ListBox**. This (Listbox3_Example) introduces using objects for listbox items. The listbox items represent an object with multiple fields, such as a person with a first name, last name, and employee Id. This example showcases how to add an item's display, and how to select information from the selected item.
Tutorials will be added overtime, so if your example project is not available, please try back later.
