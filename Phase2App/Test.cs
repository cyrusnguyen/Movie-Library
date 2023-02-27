using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Test   
{
    static void TestMain(string[] args)
    {
        ///////IsValidPhone Testing 
        /////test
        //IMember.IsValidContactNumber("0408004748");
        //IMember.IsValidContactNumber("04 0800 4748");
        //IMember.IsValidContactNumber("04 08004748");
        //IMember.IsValidContactNumber("0408 004 748");
        //IMember.IsValidContactNumber("04 0800 47 4 8");
        //IMember.IsValidContactNumber("04 0800 47 48");
        //IMember.IsValidContactNumber("0408 0 0 47 4 8");
        //Console.WriteLine("fROM HERE IT IS INCORRECT");
        //IMember.IsValidContactNumber("04 0800 47 4 a");
        //IMember.IsValidContactNumber("04 0800 47484");
        //IMember.IsValidContactNumber("14 0800 474");
        //IMember.IsValidContactNumber("AB 0800 4748");
        //IMember.IsValidContactNumber("3000000000");
        //IMember.IsValidContactNumber("333333333333");
        //IMember.IsValidContactNumber("040800474");
        //IMember.IsValidContactNumber("04abcdefgh");


        /////This IsValid Testing 
        //IMember.IsValidPin("4 1  4 2");
        //IMember.IsValidPin("4 154 2");
        //IMember.IsValidPin("555555");
        //IMember.IsValidPin("4422 2");
        //IMember.IsValidPin("0000");

        //IMember.IsValidPin("abcd");
        //IMember.IsValidPin("4 1  4 233333");
        //IMember.IsValidPin("42a3");
        //IMember.IsValidPin("4222222");
        //IMember.IsValidPin("3 1   4");

        //////Adding Testing
        ///
        //MemberCollection aCollection = new MemberCollection(50);
        Member member1 = new Member("Jason", "Shin");
        Member member2 = new Member("Abby", "Harold");
        Member member3 = new Member("Nam", "Phoung");
        Member member4 = new Member("Jake", "Johnson");
        Member member5 = new Member("Scott", "Morrison");
        Member member6 = new Member("Richard", "Johnson");
        Member member7 = new Member("David", "Zohnson");
        Member member8 = new Member("William", "Smith");
        Member member9 = new Member("Jake", "Mitchels");


        //aCollection.Add(member1);
        // aCollection.Add(member2);
        // aCollection.Add(member3);
        // aCollection.Add(member4);
        // aCollection.Add(member5);
        // aCollection.Add(member6);
        // aCollection.Add(member7);
        // aCollection.Add(member8);
        // Console.WriteLine(aCollection.ToString());


        // //Unit testing for Search Algorithm (will not come up because member 7 was added)
        // //Console.WriteLine(aCollection.Search(member3));
        // //Console.WriteLine(aCollection.Search(member9));
        // Console.WriteLine("");
        // aCollection.Delete(member1);
        // aCollection.Delete(member2);
        // Console.WriteLine(aCollection.ToString());



        //    aCollection.Search(member3);
        //    if ()

        //    {

        //        int[] arr = { 2, 3, 4, 10, 40 };
        //        int n = arr.Length;
        //        int x = 10;

        //        int result = binarySearch(arr, 0, n - 1, x);

        //        if (result == -1)
        //            Console.WriteLine("Element not present");
        //        else
        //            Console.WriteLine("Element found at index "
        //                              + result);
        //    }
        //}

        MovieCollection collectionTree = new MovieCollection();
        Console.WriteLine("New Created");

        Movie movie_1 = new Movie("Aliens", MovieGenre.Action, MovieClassification.M, 12, 4);
        Movie movie_2 = new Movie("Bake Sully", MovieGenre.Comedy, MovieClassification.G, 10, 5);
        Movie movie_3 = new Movie("Custard Tally", MovieGenre.Comedy, MovieClassification.G, 10, 5);
        Movie movie_4 = new Movie("Dead 4", MovieGenre.Western, MovieClassification.G, 20, 20);
        Movie movie_5 = new Movie("Dirty Harold", MovieGenre.Western, MovieClassification.G, 50, 50);
        Movie movie_6 = new Movie("Z for Rossiya", MovieGenre.Action, MovieClassification.M, 1, 2);
        Movie movie_7 = new Movie("Xi Jinping", MovieGenre.Action, MovieClassification.M, 1, 2);
        Movie movie_8 = new Movie("Avatar 4", MovieGenre.Action, MovieClassification.M, 1, 2);
        Movie movie_9 = new Movie("Jason's Cake", MovieGenre.Action, MovieClassification.M, 1, 2);
        Movie movie_10 = new Movie("12345", MovieGenre.Action, MovieClassification.M, 1, 2);
        Movie movie_11= new Movie("Tianshang", MovieGenre.Action, MovieClassification.M, 1, 2);

        Movie movie_59 = new Movie("Avatar 2", MovieGenre.Comedy, MovieClassification.PG, 20, 9);

        //MovieCollection collectionList = new MovieCollection();
        Console.WriteLine("Adding Aliens");
        //collectionTree.Insert(movie_4);
        Console.WriteLine("Adding Jake Sully");
        collectionTree.Insert(movie_2);
        Console.WriteLine("printing list");
        Console.WriteLine(collectionTree);
        collectionTree.Insert(movie_1);
        //collectionTree.Insert(movie_3);
        collectionTree.Insert(movie_5);
        collectionTree.Insert(movie_6);
        collectionTree.Insert(movie_7);
        collectionTree.Insert(movie_8);
        collectionTree.Insert(movie_9);
        collectionTree.Insert(movie_10);
        collectionTree.Insert(movie_11);
        collectionTree.Delete(movie_6);


        Console.WriteLine("Now we search to confirm if there is the actual movie title");
        Console.WriteLine(collectionTree.Search(movie_6));
        Console.WriteLine(collectionTree.Search(movie_2));
        Console.WriteLine(collectionTree.Search(movie_3));
        Console.WriteLine(collectionTree.Search(movie_4));
        Console.WriteLine("Now we will try and remove some movies");
        //Console.WriteLine(collectionTree.Delete(movie_6));
        //Console.WriteLine(collectionTree.Delete(movie_4));
        Console.WriteLine("Now we will search to see if the movie is there");
        Console.WriteLine("");

        //collectionTree.Clear();
        Console.WriteLine(collectionTree.Search(movie_1));
        Console.WriteLine(collectionTree.Search(movie_2));
        Console.WriteLine(collectionTree.Search(movie_3));
        Console.WriteLine(collectionTree.Search(movie_4));

        Console.WriteLine("Now we return the movie reference");
        //Console.WriteLine(collectionTree.Search("Avatar 4").ToString());
        //Console.WriteLine(collectionTree.Search("Avatar 3").ToString());

        IMovie[] array = collectionTree.ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i].ToString());
        }

        Console.WriteLine("");
        Console.WriteLine("Movie without borrower having to stringed");
        Console.WriteLine(movie_1.ToString());
        Console.WriteLine("The number of borrowings is equal to " + movie_1.NoBorrowings);
        Console.WriteLine("The number of avaliable copies is " + movie_1.AvailableCopies);
        Console.WriteLine("Now we test the borrowing function stuff");
        movie_1.AddBorrower(member1);
        Console.WriteLine("Now someone has borrowed this movie!");
        Console.WriteLine(movie_1.ToString());
        Console.WriteLine("The number of borrowings is equal to " + movie_1.NoBorrowings);
        Console.WriteLine("The number of avaliable copies is " + movie_1.AvailableCopies);
        movie_1.RemoveBorrower(member1);
        Console.WriteLine("Now someone has returned this movie!");
        Console.WriteLine(movie_1.ToString());
        Console.WriteLine("The number of borrowings is equal to " + movie_1.NoBorrowings);
        Console.WriteLine("The number of avaliable copies is " + movie_1.AvailableCopies);

    }
}
