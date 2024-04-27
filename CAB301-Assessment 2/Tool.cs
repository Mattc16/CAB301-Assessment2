//CAB301 - Assignment 2 
//Tool ADT implementation


using System;
using System.Text;


//Invariants: Name=!null and Number >=1

partial class Tool : ITool
{
    private string name;
    private int number;
    private string[] borrowerList;

    //constructor 
    public Tool(string name, int number = 0)
    {
        if (name == null)
            throw new ArgumentNullException("Name is null");
        else
        { 
            this.name = name;
            this.number = number;
            borrowerList = new string[0];
        }
    }

    //get the name of this tool
    public string Name 
    {
        get { return name; }   // get method
    }

    //get the number of this tool currently available in the tool library
    public int Number 
    {
        get { return number; }   // get method
    }

    //check if a person is in the borrower list of this tool (is holding this tool)
    //Pre-condition: nil
    //Post-condition: return true if the person is in the borrower list; return false otherwise. The information about this tool remains unchanged.
    public bool IsInBorrowerList(string personName)
    {
        foreach (string borrower in borrowerList)
        {
            if (borrower == personName)
                return true;
        }
        return false;
    }


    //add a person to the borrower list
    //Pre-condition: the borrower is not in the borrower list and Number > 0
    //Post-condition: the borrower is added to the borrower list and new Number = old Number - 1
    public bool AddBorrower(string personName)
    {
        if (!IsInBorrowerList(personName) && number > 0)
        {
            Array.Resize(ref borrowerList, borrowerList.Length + 1);
            borrowerList[borrowerList.Length - 1] = personName;
            number--;
            return true;
        }
        else
            return false;
    }


    //remove a borrower from the borrower list
    //Pre-condition: the borrower is in the borrower list
    //Post-condition: the borrower is removed from the borrower list and new Number = old Number + 1
    public bool RemoveBorrower(string personName)
    {
        for (int i = 0; i < borrowerList.Length; i++)
        {
            if (borrowerList[i] == personName)
            {
                borrowerList[i] = borrowerList[borrowerList.Length - 1];
                Array.Resize(ref borrowerList, borrowerList.Length - 1);
                number++;
                return true;
            }
        }
        return false;
    }


    //Compare this tool's name to another tool's name 
    //Pre-condition: anotherTool =! null
    //Post-condition:  return -1, if this tool's name is less than another tool's name by alphabetical order
    //                 return 0, if this tool's name equals to another tool's name by alphabetical order
    //                 return +1, if this tool's name is greater than another tool's name by alphabetical order

    public int CompareTo(ITool? anotherTool)
    {
        if (anotherTool == null)
            throw new ArgumentNullException("Another tool is null");
        else
            return name.CompareTo(anotherTool.Name);
    }


    //Return a string containing the name and the number of this tool currently in the tool library 
    //Pre-condition: nil
    //Post-condition: A string containing the name and number of this tool is returned

    public override string ToString()
    {
        return $"{Name}: {Number}";
    }
}
