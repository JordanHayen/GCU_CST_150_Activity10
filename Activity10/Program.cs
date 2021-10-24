using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In order to debug this program, I will place breakpoints at each line of code wherein a method of the Set class is called. Comparing the values of the Set objects at these points to the expected values should help to determine which method or methods are respondible for the logic errors

namespace Activity10
{
    class Program
    {
        static void Main(string[] args)
        {
            //make some sets
            Set A = new Set();
            Set B = new Set();

            //put some stuff in the sets
            Random r = new Random(); // The above lines call the constructor method of the Set class. The values of the Set objects at this point do not appear to be incorrect. Each object contains an empty list as expected. Therefore, the constructor method is correctly written
            for (int i = 0; i < 10; i++)
            {
                A.addElement(r.Next(4));
                B.addElement(r.Next(12));
            }

            //display each set and the union
            Console.WriteLine("A: " + A); // The above lines call the addElement metohd of the Set class. At this point, the Set objects should each contain a list of integers that contain no duplicates. This is not the case. Therefore, the addElement method is incorrectly written
            Console.WriteLine("B: " + B);
            Console.WriteLine("A union B: " + A.union(B));

            //display original sets (should be unchanged)
            Console.WriteLine("After union operation"); // The above lines call the union method of the Set class. The result should be a Set object that contains the elements in the Set object used to call the method as well as the one used as a parameter with no duplicates. This is not the case. The Set object returned does not contain elements from the object calling the method, only the paramaeter. Therefore, the union method is incorrectly written
            Console.WriteLine("A: " + A);
            Console.WriteLine("B: " + B);

        } // The program now functions as intended
    }
}
