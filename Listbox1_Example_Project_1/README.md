# Listbox Project 1

The tutorials are a series of Microsoft Visual Studio projects. In general:

1. Download each project ZIP file.
1. Expand it in your favorite location on your computer.
1. Double click the solution file (*.sln).
1. From the Visual Studio main menu, select Start.
1. Follow the screen or project notes to operate the application.

Notes are provided in the individual project's README file. Comments may be inlined in the code.

## Running the Application
The application has four buttons:
- **Automatically add values**. Selecting this adds four values (displayed as zero through three) to the existing list.
Selecting this multiple times displays multiple sets of zero through three.
- **Add from textbox**. Selecting this adds the text in the textbox to the list. You can change the text each time.
Selecting this multiple times displays add the current text to the end of the list.
- **Delete selected value**. Selecting this removes the currently selected item in the list.
If no item is selected, nothing is deleted.
- **Clear Listbox**. Selecting this deletes the entire list and allows starting from a clean list.

You can examine the project's code to see how this is all done. Beware, most of the code has nothing to do with the list directly, but rather relates to the clean operation of an application.

The basic approach is that items are added to the list through the line:<br><br>
```listBox1.Items.Add(i);```<br><br>
The first way, **Automatically add values**, is actually unrealistic. There aren’t may times when you’d want to display items from a mathematical source.

The second way, **Add from textbox**, is more realistic. It is reasonable that you’d want to add items from a textbox that users can change. This case also represents adding items from a data source. You can read information from perhaps a file. You’d just have to add code that opens a file, reads from it, and finally adds items after that. You’d have to make sure that the information is properly formatted before adding it. A common example of that is comma separated file (CSV), such as from a spreadsheet source, or a formatted text or Word document.

However, using `listBox1.Items.Add` is a slow and awkward way to add more than just a couple of items. If, for example, your application displays an employee database of perhaps a few hundred, listing the names, the loading processing will have a noticeable delay. If you're using it from a scientific application, loading thousands or perhaps literally billions of list items, the delay will be unacceptably long.

In those cases, another way to load the values is needed. For that case, see **Listbox2_Example**.

## Tutorial Examples
There are three example projects. 
Each project is standalone and you don't need previous projects to run another project.
You don't even need to go through them sequentially, although if you're new to ListBoxes, consider going through each one in turn.

The topics are:
- **Basic operations**. This (**Listbox1_Example**) is a good starting place and introduces the basics of ListBoxes.
- **Using DataSource for speed and convenience**. This (**Listbox2_Example**) introduces using the Listbox DataSource property allows for extremely quick loading and convenience from an array or list.
- **Using Objects in a ListBox**. This (**Listbox3_Example**) introduces using objects for listbox items. The listbox items represent an object with multiple fields, such as a person with a first name, last name, and employee Id. This example showcases how to add an item's display, and how to select information from the selected item.

Tutorials will be added overtime, so if your example project is not available, please try back later.
