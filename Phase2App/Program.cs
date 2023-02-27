using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Phase2
{
    class Program
    {
        static void Main(string[] args)
        {
            LibrarySystem system = new LibrarySystem();
            
            Member y1 = new Member("y", "y", "0400000000", "0000");
            Member x1 = new Member("x", "x", "0400000000", "0000");
            Member a1 = new Member("a", "a", "0400000000", "0000");
            Member b1 = new Member("b", "b", "0400000000", "0000");
            Member c1 = new Member("c", "c", "0400000000", "0000");
            Movie movie1 = new Movie("Doctor1", MovieGenre.Action, MovieClassification.G, 1, 20);
            Movie movie2 = new Movie("Doctor2", MovieGenre.Action, MovieClassification.G, 1, 30);
            Movie movie3 = new Movie("Doctor3", MovieGenre.Action, MovieClassification.G, 1, 40);

            system.add(x1);
            system.add(y1);
            system.add(a1);
            system.add(b1);
            system.add(c1);

            system.add(movie1, noBorrowings: 20, aMember: y1);
            system.add(movie2, noBorrowings: 60, aMember: a1);
            system.add(movie3, noBorrowings: 30, aMember: b1);

            system.ProcessMainMenu();
        }
    }

}
