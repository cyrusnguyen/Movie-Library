//CAB301 assessment 1 - 2022
//The implementation of MemberCollection ADT
using System;
using System.Linq;


class MemberCollection : IMemberCollection
{
    // Fields
    private int capacity;
    private int count;
    private Member[] members; //make sure members are sorted in dictionary order

    // Properties

    // get the capacity of this member colllection 
    // pre-condition: nil
    // post-condition: return the capacity of this member collection and this member collection remains unchanged
    public int Capacity { get { return capacity; } }

    // get the number of members in this member colllection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }

   


    // Constructor - to create an object of member collection 
    // Pre-condition: capacity > 0
    // Post-condition: an object of this member collection class is created

    public MemberCollection(int capacity)
    {
        if (capacity > 0)
        {
            this.capacity = capacity;
            members = new Member[capacity];
            count = 0;
        }
    }

    // check if this member collection is full
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is full; otherwise return false.
    public bool IsFull()
    {
        return count == capacity;
    }

    // check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is empty; otherwise return false.
    public bool IsEmpty()
    {
        return count == 0;
    }






    // Add a new member to this member collection
    // Pre-condition: this member collection is not full
    // Post-condition: a new member is added to the member collection and the members are sorted in ascending order by their full names;
    // No duplicate will be added into this the member collection

    //Inspired by Week 3 Insertion Sort TutorCode
    //Insertion Sort Algorithm
    public void Add(IMember member)
    {
        //Check if count is 0, we do not need to worry about sort
        if (IsEmpty())
        {
            //Cast the Member Object
            members[count] = (Member)member;
            count++; //count + 1
        }
        else if (!IsFull())
        { 
            members[count] = (Member)member;
            count++;
            //For loop through array
            for (int i = 1; i <= (count - 1); i++)
            {
                //Member Object is the array key
                Member v = members[i];
                int j = i - 1; 
                //When elements are greater than V, where the compare to result is 1 
                //Move the array elements from 0 to i-1 to a forward position
                while (j >= 0 && members[j].CompareTo(v) == 1)
                {
                    members[j + 1] = members[j]; //Shifts to a forward position
                    j = j - 1;
                }
                members[j + 1] = v;
            }
        }
    }

    //To unit test
    //Please cast a MemberCollection object declaring capacity
    //E.g. MemberCollection aCollection = new MemberCollection(50);
    //To add a member type
    //Member member1  = new Member("John", "Smith")
    //Afterwards
    //aCollection.Add(member1)




    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member has been removed from this member collection, if the given meber was in the member collection


    //Inspired by Week 4 CustomerCollectionApp Delete Method
    //Sequential Search
    public void Delete(IMember aMember)
    {
        //Typecast Search key as Member Object
        Member k = (Member)aMember;
        //Initialise i as 0
        int i = 0;
        //While the total array length is greater than 0 and element is not equal the key
        while ((i < count) && (members[i].CompareTo(k) != 0))
            i++; //i = i+1 Shifts to the next part of search
        if (i == count) //If there is no element
            Console.WriteLine("This member does not exist!");
        else
        {
            //If search key is found
            for (int j = i + 1; j < count; j++) 
                members[j - 1] = members[j]; //Removes the element from array 
           count--; //Decreases count by 1
        }
    }

    //To unit test
    //Please cast a MemberCollection object declaring capacity
    //E.g. MemberCollection aCollection = new MemberCollection(50);
    //First add a member using steps in the first method
    //Afterwards
    //aCollection.Delete(member1)








    // Search a given member in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if this memeber is in the member collection; return false otherwise; member collection remains unchanged

    //Inspired by Lecture 3 Pseudocode Example Provided 
    //Binary Search 
    public bool Search(IMember member)
    {
        //Type Cast the Member object
        //K is the search key 
        Member k = (Member)member; 
        int left = 0; //Declare an integer to represent the left most index (firstpoint)
        int right = count - 1; //Declare an integer 

        //Whilst starting point 0 is smaller or equal to the endpoint 
        while (left <= right)
        {
            //Midpoint is the middle index (will be rounded down if even) 
            int mid = (left + right) / 2;
            //Declare an integer result where it will compare midpoint with search key
            //0 if match, 1 if elsewhere and -1 if does not exist
            int result = members[mid].CompareTo(k);
            
            //If search key k is present at the midpoint
            if (k == members[mid]) //Or if Result = 0
                return true;

            //If member is at a lower alphabetical position than the midpoint element
            //It can only be present in the left subarray
            if (result == 1) //Value from CompareTo method 
            {
                right = mid - 1;
            }
            //Else, member must be in the right subarray 
            else left = mid + 1;
        }
        //When element is not present
        return false;
    }

    //To unit test
    //Please cast a MemberCollection object declaring capacity
    //E.g. MemberCollection aCollection = new MemberCollection(50);
    //First add a member using steps in the first add method
    //Afterwards
    //Console.WriteLine(aCollection.Delete(member1))
    //Will print true if member exists in array or false otherwise





    // Remove all the members in this member collection
    // Pre-condition: nil
    // Post-condition: no member in this member collection 
    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            this.members[i] = null;
        }
        count = 0;
    }

    // Return a string containing the information about all the members in this member collection.
    // The information includes last name, first name and contact number in this order
    // Pre-condition: nil
    // Post-condition: a string containing the information about all the members in this member collection is returned
    public string ToString()
    {
        string s = "";
        for (int i = 0; i < count; i++)
            s = s + members[i].ToString() + "\n";
        return s;
    }

    public IMember Find(IMember member)
    {
        foreach (IMember i in members)
        {
            if (i.CompareTo(member) == 0)
            {
                return i;
            }
        }
        return null;
    }
}

