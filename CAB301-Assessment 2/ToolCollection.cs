// CAB301 - Assignment 2
// ToolCollection ADT implementation


using System;
using System.Collections.Generic;
//A class that models a node of Binary Tree
public class BTreeNode
{
    public ITool tool; 
    public BTreeNode? lchild; // reference to its left child 
    public BTreeNode? rchild; // reference to its right child

    public BTreeNode(ITool tool)
    {
        this.tool = tool;
        this.lchild = null;
        this.rchild = null;
    }
}

// Invariants: no duplicate tools in this tool collection (all the tools in this tool collection have different names) and the number of tools in this tool collection is greater than equals to 0


partial class ToolCollection : IToolCollection
{
	private BTreeNode? root; // tools are stored in a binary search tree and the root of the binary search tree is 'root' 
	private int count; // the number of different tools currently stored in this tools collection 


    // constructor - create an object of ToolCollection object
    public ToolCollection()
    {
        root = null;
        count = 0;
    }

    // get the number of tools in this movie colllection 
    public int Number { get { return count; } }



    // Check if this tool collection is empty
    // Pre-condition: nil
    // Post-condition: return true if this tool collection is empty; otherwise, return false. This tool collection remains unchanged and new Number = old Number
    public bool IsEmpty()
	{
        return root == null;
    }


    // Insert a new tool into this tool collection
    // Pre-condition: the new tool is not in this tool collection
    // Post-condition: the new tool is added into this tool collection, new Number = old Number + 1 and return true; otherwise, the new tool is not added into this tool collection, new Number = old Number and return false.

    public bool Insert(ITool tool)
	{
        if (Search(tool.Name) != null)
            return false;

        root = InsertHelper(root, tool);
        count++;
        return true;
    }


    private BTreeNode InsertHelper(BTreeNode? node, ITool tool)
    {
        if (node == null)
            return new BTreeNode(tool);
        
        int cmp = tool.Name.CompareTo(node.tool.Name);
        if (cmp < 0)
            node.lchild = InsertHelper(node.lchild, tool);
        else
            node.rchild = InsertHelper(node.rchild, tool);

        return node;
    }


    // Delete a tool from this tool collection
    // Pre-condition: nil
    // Post-condition: the tool is removed out of this tool collection, new Number = old Number - 1 and return true, if the tool is present in this tool collection; 
    // otherwise, this tool collection remains unchanged, and new Number = old Number, and return false, if the tool is not present in this tool collection.

    public bool Delete(ITool tool)
    {
        int initialNumber = count;
        root = DeleteHelper(root, tool.Name);
        return count < initialNumber;
    }


    private BTreeNode? DeleteHelper(BTreeNode? node, string toolName)
    {
        if (node == null)
            return null;

        int cmp = toolName.CompareTo(node.tool.Name);
        if (cmp < 0)
            node.lchild = DeleteHelper(node.lchild, toolName);
        else if (cmp > 0)
            node.rchild = DeleteHelper(node.rchild, toolName);
        else
        {
            if (node.lchild == null)
                return node.rchild;
            else if (node.rchild == null)
                return node.lchild;
            else
            {
                BTreeNode? temp = MinValueNode(node.rchild);
                node.tool = temp.tool;
                node.rchild = DeleteHelper(node.rchild, temp.tool.Name);
            }
        }
        return node;
    }


    private BTreeNode MinValueNode(BTreeNode node)
    {
        BTreeNode current = node;
        while (current.lchild != null)
            current = current.lchild;
        return current;
    }


    // Search for a tool by its name in this tool collection  
    // pre: nil
    // post: return the reference of the tool object if the tool is in this tool collection;
    //	     otherwise, return null. New Number = old Number.
    public ITool? Search(string toolName)
	{
        BTreeNode? result = SearchHelper(root, toolName);
        return result == null ? null : result.tool;
    }


    private BTreeNode? SearchHelper(BTreeNode? node, string toolName)
    {
    if (node == null)
        return null;

    int cmp = toolName.CompareTo(node.tool.Name);
    if (cmp == 0)
        return node;
    else if (cmp < 0)
        return SearchHelper(node.lchild, toolName);
    else
        return SearchHelper(node.rchild, toolName);
    }


    // Return an array that contains all the tools in this tool collection and the tools in the array are sorted in the dictionary order by their names
    // Pre-condition: nil
    // Post-condition: return an array that contains all the tools in this tool collection and the tools in the array are sorted in alphabetical order by their names and new Number = old Number.
    public ITool[] ToArray()
	{
        List<ITool> sortedToolList = new List<ITool>();
        InOrderTraversal(root, sortedToolList);
        return sortedToolList.ToArray();
    }


    private void InOrderTraversal(BTreeNode? node, List<ITool> sortedToolsList)
    {
        if (node != null)
        {
            InOrderTraversal(node.lchild, sortedToolsList);
            sortedToolsList.Add(node.tool);
            InOrderTraversal(node.rchild, sortedToolsList);
        }
    } 


    // Clear this tool collection
    // Pre-condition: nil
    // Post-condition: all the tools in this tool collection are removed from this tool collection and Number = 0. 
    public void Clear()
	{
        root = null;
		count = 0;
	}
}