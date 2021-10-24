using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// One or more methods within this class were determined to contain logic errors. If any of the methods that contain logic errors call other methods of the class then I will debug those methods using breakpoints. If the submethod is determined not to be the source of the error, then I will place breakpoints in the outer method and debug it in the same way

namespace Activity10
{
    class Set
    {
        private List<int> elements;


        public Set()
        {
            elements = new List<int>();
        }

        // This method was determined to contain logic errors. This method was intended to add elements to the object only if that element is not already present within the object, ensuring that the object does not contain duplicates. The method lacks this functionality
        // A method called within this method, the containsElement metohd, was determined to be the cause of the logic errors within this method. Debugging the containsElement method resolved all errors within both methods
        public bool addElement(int val)
        {
            if (containsElement(val)) return false; // A method of the class is called here
            else
            {
                elements.Add(val);
                return true;
            }
        }
        
        // This method is called within a method that was determined to contain logic errors. This method was intended to determine whether or not a given element is present within the object
        private bool containsElement(int val)
        {
            for (int i = 0; i < elements.Count; i++)
            { // This for-loop contains a logic error. The iterator variable, i, never rises above zero, its starting value. This means that some error within the loop is causing it not to loop properly
                if (val == elements[i])
                    return true;
                //else // This else statement prevents the for-loop from iterating over every element in the elements list. With the else statement present, the loop code in the loop will examine only the first element in the list. If the element is equal to the parameter, a value of true is returned, causing loop to end. This is ideal. However, with the else statement in place, if the element is not equal to the paramaeter another return statement is reached, causing the loop to end prematurely instad of moving on to the next element. Removing the else statement should solve the error
                    //return false;
            }
            return false;
        }

        public override string ToString()
        {
            string str = "";
            foreach (int i in elements)
            {
                str += i + " ";
            }
            return str;
        }

        public void clearSet()
        {
            elements.Clear();
        }

        // As I understand it, this block of code is intended to take another Set object as a parameter and return a Set object that contains the elements in both the parameter and the Set that calls the method without any duplicates, leaving the parameter and the set calling the method unchanged. This method does not live up to that purpose. Instead, it adds all the elements of the parameter to the Set itself and then returns the parameter this is mistaken
        /*public Set union(Set rhs)
        {
            Set result = new Set(); // Creates and initializes a new Set object that will eventually be returned

            for (int i = 0; i < this.elements.Count; i++)
            {
                result.addElement(this.elements[i]);
            }

            for (int i = 0; i < rhs.elements.Count; i++)
            {
                //this.addElement(rhs.elements[i]);
                result.addElement(rhs.elements[i]);
            }
            //return rhs;
            return result;
        }*/

        // This method was determined to contain logic errors. This method was intended to take a Set object as a parameter and return a Set object that contains the elements present within both Sets without any duplicates, leaving the original Sets unchanged. Instead this method adds all elements of the parameter to the object calling the method, thus changing one of the original sets, and then returns the parameter instead of a new or modified Set object. A major rewrite of this method is necessary
        public Set union(Set rhs)
        {

            Set result = new Set(); // Creates and initializes a new Set object that will eventually be returned

            for(int i = 0; i < this.elements.Count; i++) // This loop uses the class's addElement method to add every element of the object calling the method to the result object
            {
                result.addElement(this.elements[i]);
            }

            for (int i = 0; i < rhs.elements.Count; i++) // This loop has been modified to use the class's addElement method to add every element of the parameter to the result object instead of adding the elements to the the object calling the method
            {
                //this.addElement(rhs.elements[i]); This line used the class's addElement method to add elements from the parameter to the object calling the method, which changed the value of the object. Removing this line will leave the calling object unchanged
                result.addElement(rhs.elements[i]);
            }
            //return rhs; This line returned the parameter instead of a new Set object. Removing it will allow a new object to be returned instead
            return result; // The result object is returned
        }

    }

}

// References:
// Microsoft. (August 5, 2021). Use breakpoints in the Visual Studio debugger. https://docs.microsoft.com/en-us/visualstudio/debugger/using-breakpoints?view=vs-2019#:~:text=To%20set%20a%20breakpoint%20in%20source%20code%2C%20click,as%20a%20red%20dot%20in%20the%20left%20margin.
