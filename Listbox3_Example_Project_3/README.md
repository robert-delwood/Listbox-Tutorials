# Introduction
The last two tutorial projects always used a single string for each listbox item display. 
In many cases this is adequate. That is, it’s good if all you need is a list of names to select from, or to display each item of a larger set. 
However, a more practical use case is that each listbox item is actually an object representing a more complete item. 
For example, if the list displays an employee database, you’d want the item to display to a name. 
To get to more information about the employee, you’d want to simply double click the name and see all the additional information, such as their full name, employee number, and so on.

There are three concepts for this:
1. Create a string to display.
1. A collection of objects.
1. The ability to directly access the employees’ information.

## Create a string to display
Since the information will likely be kept in distinct fields, such as one for first name and second one for last name, simply displaying a field isn’t going to be helpful. 
For example, just showing Smith isn’t useful enough, even less so if it’s just the first name, like John. 
The display will need to be a combination of both the first and last name, like John Smith, maybe even the employee number, too. 
Showing how to display a value that is a composite of individual fields was covered in the Listbox2_Example_Project_2 example using the listBox1.DisplayMember property, such as listBox1.DisplayMember = "NameLast";
A common problem is when an object is assigned to listbox, the display shows the object type, rather than individual fields, as many expect. 

For example:
 
In this case, the line `listBox1.DisplayMember = "NameLast";` is mandatory in order to show a more useful display. 
This can be either a property, like` listBox1.DisplayMember = "NameLast";`, or a method `listBox1.DisplayMember = "GetUserDetails";` for creating a composite display. 
The DisplayMember must be a public property within the class. 
A property is like a variable but with either a `get` or `set` operator.

## A collection of objects
A collection is a .NET defined set of objects that group and manage information. 
The most basic collection is the array, where you can keep a group of information accessed by an index value. 
.NET collections are a larger, more specialized, and more versatile groupings. 
The collection for this project is a `List<t>`, with the `<t>` notion being shorthand for the type of object being used. 
If this were a collection of strings, it’d be noted as `List<string>`. The object in this project is based on a class named Person, so the collection will be `List<Person>`.
The sample project creates five instances to represent the employee database. 

A quick way to create an object directly to a collection is with:
`gPersonList.Add(new Person("Andy", "Anselman", 29, 1));`
  
## The ability to directly access the employees’ information
The ability to directly access the employees’ information after double clicking the listbox display line. 
This includes getting the currently selected listbox rows. 

Rather than just getting the index of the selected row, that is, an ordinal value for the row, such as the first one or the 5th one, instead, the listbox returns the object that is selected.
That means, when you get the entire object. It’s convenient. For instance, when you use LINQ to filter your database, represented by the original List<t> collection, the objects are still included in that new list.
How ever the collection is filtered, you can always get to the object directly.
A common way of getting this information is with the listbox even `MouseDoubleClick()`. 
The event is fired anytime a doubleclick is detected within the listbox. Using the method SelectedItem gets the actual highlighted item.

## Bonus Tip
The iif statement. C# has a great operator that can be called an iif statement. It’s a shorthand if…else statement. It looks like this: 
`someBool ? "true" : "false";`
Given an expression that evaluates to true or false, it returns either the first statement after the question mark if true, and the second statement if false. 
In use it might look like:
```
bool isRepublican = true;
string messageString = “My state is : ”;
string stateColor = isRepublican ? “Red” : “Blue”;
messageString += stateColor;
```
Or combined:
```
bool isRepublican = true;
string messageString = "My state is : " + (isRepublican ? "Red" : "Blue");
```


