using System;

namespace Assignment_Phase2
{
    class LibrarySystem : ILibrarySystem
    {
        static MovieCollection movieCollection = new MovieCollection();
        static MemberCollection memberCollection = new MemberCollection(100);
        static IMember currentMember;
        string inputReturn = "n";
        private bool validStaff = false;
        private bool validMember = false;

        public void add(Movie aMovie, int noBorrowings = 0, int quantity = 0, Member aMember = null)
        {
            
            aMovie.AvailableCopies += quantity;
            aMovie.NoBorrowings += noBorrowings;
            if (aMember != null)
            {
                aMovie.Borrowers.Add(aMember);
            }
            movieCollection.Insert(aMovie);
        }
        public void add(Member aMember)
        {
            memberCollection.Add(aMember);
        }



        public void PrintMainMenu()
        {
            
            Console.Clear();
            string mainMenuString = new string('=', 60) + "\n" +
                "  Welcome to Community Library Movie DVD Management System\n" +
                new string('=', 60) + "\n" +
                "\n" + new string('=', 25) + "Main Menu" + new string('=', 25) + "\n" + "\n" +
                "1.Staff Login\n" +
                "2.Member Login\n" +
                "0.Exit\n" + "\n" +
                "Enter your choice ==> (1/2/0)";


            Console.WriteLine(mainMenuString);
           
            
        }
        public void ProcessMainMenu()
        {

            PrintMainMenu();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":

                    ProcessStaffMenu();
                    break;
                case "2":
                    ProcessMemberMenu();
                    break;
                case "0":
                    break;
            }

        }
        public void PrintStaffMenu()
        {
            Console.Clear();
            string staffMenuString = "\n" + new string('=', 25) + "Staff Menu" + new string('=', 25) + "\n" + "\n" +
                "1. Add new DVDs of a new movie to the sytem\n" +
                "2. Remove DVDs of a movie from the system\n" +
                "3. Register a new member with the system\n" +
                "4. Remove a register member from the system\n" +
                "5. Display a member's contact phone number, given the member's name\n" +
                "6. Display all members who are currently renting a particular movie\n" +
                "0. Return to the main menu\n\n" +
                "Enter your choice ==> (1,2,3,4,5,6,0)";
            Console.WriteLine(staffMenuString);
        }
        public void ProcessStaffMenu()
        {
            if (CheckValidStaff())
            {
                PrintStaffMenu();
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        addDVD();
                        ProcessStaffMenu();
                        break;
                    case "2":
                        removeDVD();
                        ProcessStaffMenu();
                        break;
                    case "3":
                        addMember();
                        ProcessStaffMenu();
                        break;
                    case "4":
                        removeMember();
                        ProcessStaffMenu();
                        break;
                    case "5":
                        displayPhoneNumber();
                        break;
                    case "6":
                        displayMemberRentingMovie();
                        break;
                    case "0":
                        ProcessMainMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wrong username or password. Do you want to try again?(y/n)");
                if (Console.ReadLine() != "y")
                {
                    ProcessMainMenu();
                }
                ProcessStaffMenu();
            }

        }
        public void PrintMemberMenu()
        {
            Console.Clear();
            string memberMenuString = "\n" + new string('=', 25) + "Member Menu" + new string('=', 25) + "\n" + "\n" +
                "1. Browse all the movies\n" +
                "2. Display all the information about the movie, given the title of the movie\n" +
                "3. Borrow a movie DVD\n" +
                "4. Return a movie DVD\n" +
                "5. List current borrowing movies\n" +
                "6. Display the top three (3) most frequently borrowed movies\n" +
                "0. Return to the main menu\n\n" +
                "Enter your choice ==> (1,2,3,4,5,6,0)";
            Console.WriteLine(memberMenuString);

        }
        public void ProcessMemberMenu()
        {
            if (isCurrentMember())
            {
                PrintMemberMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        displayAllMovies();
                        break;
                    case "2":
                        displayMovieInformation();
                        break;
                    case "3":
                        borrowDVD();
                        break;
                    case "4":
                        returnDVD();
                        break;
                    case "5":
                        listCurrentMovies();
                        break;
                    case "6":
                        displayTopThreeMovies();
                        break;
                    case "0":
                        ProcessMainMenu();
                        break;
                }
            }


        }
        
        

        private String CheckInput()
        {
            return "";
        }
        private bool IsValidStaff(string username, string password)
        {
            if (username == "staff" && password == "today123")
            {
                return true;
            }
            return false;
        }
        private bool CheckValidStaff()
        {
            if (validStaff) {
                return true;
            }
            Console.WriteLine("Please enter staff username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter staff password:");
            string password = Console.ReadLine();
            if (!IsValidStaff(username, password))
            {
                Console.WriteLine("Wrong username or password");
                return false;
            }
            else
            {
                validStaff = true;
                return true;
            }

        }
        
        private void displayAllMovies()
        {
            foreach(IMovie movie in movieCollection.ToArray())
            {
                Console.WriteLine(movie.ToString() + "Total number of available copies: " + movie.AvailableCopies);
            }
            Console.WriteLine("Return to Member Menu (y/n)");
            if (Console.ReadLine() == "y")
            {
                ProcessMemberMenu();
            }


        }
        private void displayMovieInformation()
        {
            Console.WriteLine("Please enter movie title: ");
            string input = Console.ReadLine();

            IMovie movie = movieCollection.Search(input);

            if(movie != null)
            {
                Console.WriteLine(movie.ToString());
            }
            else
            {
                Console.WriteLine("The movie doesn't exist");
            }
            Console.WriteLine("Return to Member Menu? (y/n)");
            if (Console.ReadLine() == "y")
            {
                ProcessMemberMenu();
            }
        }
        private bool isCurrentMember()
        {
            if (validMember)
            {
                return true;
            }
            if (!memberCollection.IsEmpty())
            {
                Console.Clear();
                Console.WriteLine("Please enter first name:\n");
                string firstName = Console.ReadLine();
                Console.WriteLine("Please enter last name:\n");
                string lastName = Console.ReadLine();
                Console.WriteLine("Please enter pin:\n");
                string pin = Console.ReadLine();

                currentMember = memberCollection.Find(new Member(firstName, lastName));
                if (currentMember != null)
                {
                    if (currentMember.Pin == pin)
                    {
                        validMember = true;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Pin is wrong. Do you want to try again?(y/n)");
                        if (Console.ReadLine() == "y")
                        {
                            isCurrentMember();
                        }
                        else
                        {
                            ProcessMemberMenu();
                        }

                    }
                }
                else
                {
                    Console.WriteLine("There is no registed member with this name. Please contact staff to register.");
                    Console.WriteLine("Return to Main Menu (y/n)");
                    if (Console.ReadLine() == "y")
                    {
                        ProcessMainMenu();
                    }
                }
            }
            else
            {
                Console.WriteLine("There's no member in the library. Please contact staff to register.");
                Console.WriteLine("Return to Main Menu (y/n)");
                if (Console.ReadLine() == "y")
                {
                    Console.Clear();
                    ProcessMainMenu();
                }
            }
            

            return false;
        }
        private void borrowDVD()
        {
            Console.WriteLine("Please enter the movie title: ");
            string input = Console.ReadLine();
            IMovie movie = movieCollection.Search(input);

            if (movie != null)
            {
                movie.AddBorrower(currentMember);
                Console.WriteLine(movie.ToString());
            }
            else
            {
                Console.WriteLine("The movie doesn't exist");
            }

            Console.WriteLine("Return to Member Menu? (y/n)");
            if (Console.ReadLine() == "y")
            {
                ProcessMemberMenu();
            }
        }
        private void returnDVD()
        {
            Console.WriteLine("Please enter the movie title: ");
            string input = Console.ReadLine();
            IMovie movie = movieCollection.Search(input);

            if (movie != null)
            {
                bool isReturned = movie.RemoveBorrower(currentMember);
                if (!isReturned)
                {
                    Console.WriteLine("You haven't borrowed this movie");
                }
                else
                {
                    Console.WriteLine("You have returned " + movie.Title);
                }
                
            }
            else
            {
                Console.WriteLine("The movie doesn't exist");
            }

            Console.WriteLine("Return to Member Menu? (y/n)");
            if (Console.ReadLine() == "y")
            {
                ProcessMemberMenu();
            }
        }
        private void listCurrentMovies()
        {
            
            for (int i = 0; i < movieCollection.ToArray().Length; i++)
            {
                IMovie movie = movieCollection.ToArray()[i];
                if (movie.Borrowers.Search(currentMember)){
                    Console.WriteLine(movie.Title);
                }
            }


            Console.WriteLine("Return to Member Menu? (y/n)");
            if (Console.ReadLine() == "y")
            {
                ProcessMemberMenu();
            }

        }
        private void displayTopThreeMovies()
       {
            try
            {
                // Modified from CAB301 Tutorial Week 6
                // convert a complete binary tree into a heap
                static void HeapBottomUp(IMovie[] movies)
                {
                    int n = movies.Length;
                    for (int i = (n - 1) / 2; i >= 0; i--)
                    {
                        int k = i;
                        IMovie v = movies[i];
                        bool heap = false;
                        while ((!heap) && ((2 * k + 1) <= (n - 1)))
                        {
                            int j = 2 * k + 1;  //the left child of k
                            if (j < (n - 1))   //k has two children
                                if (movies[j].NoBorrowings < movies[j + 1].NoBorrowings)
                                    j = j + 1;  //j is the larger child of k
                            if (v.NoBorrowings >= movies[j].NoBorrowings)
                                heap = true;
                            else
                            {
                                movies[k] = movies[j];
                                k = j;
                            }
                        }
                        movies[k] = v;
                    }
                }

                    // sort the elements in an array 
                static void HeapSort(IMovie[] movies)
                {

                    //Use the HeapBottomUp procedure to convert the array, data, into a heap
                    HeapBottomUp(movies);


                    //repeatly remove the maximum key from the heap and then rebuild the heap
                    for (int i = 0; i <= movies.Length - 2; i++)
                    {
                        MaxKeyDelete(movies, movies.Length - i);
                    }
                }

                //delete the maximum key and rebuild the heap
                static void MaxKeyDelete(IMovie[] movies, int size)
                {
                    //1. Exchange the root’s key with the last key K of the heap;
                    IMovie temp = movies[0];
                    movies[0] = movies[size - 1];
                    movies[size - 1] = temp;

                    //2. Decrease the heap’s size by 1;
                    int n = size - 1;

                    //3. “Heapify” the complete binary tree.
                    bool heap = false;
                    int k = 0;
                    IMovie v = movies[0];
                    while ((!heap) && ((2 * k + 1) <= (n - 1)))
                    {
                        int j = 2 * k + 1; //the left child of k
                        if (j < (n - 1))   //k has two children
                            if (movies[j].NoBorrowings < movies[j + 1].NoBorrowings)
                                j = j + 1;  //j is the larger child of k
                        if (v.NoBorrowings >= movies[j].NoBorrowings)
                            heap = true;
                        else
                        {
                            movies[k] = movies[j];
                            k = j;
                        }
                    }
                    movies[k] = v;
                }

                IMovie[] moviesList = movieCollection.ToArray();
                HeapSort(moviesList);

                Console.WriteLine("Top 1: " + moviesList[moviesList.Length - 1].Title + ". Number of Borrowings: " + moviesList[moviesList.Length - 1].NoBorrowings);
                Console.WriteLine("Top 2: " + moviesList[moviesList.Length - 2].Title + ". Number of Borrowings: " + moviesList[moviesList.Length - 2].NoBorrowings);
                Console.WriteLine("Top 3: " + moviesList[moviesList.Length - 3].Title + ". Number of Borrowings: " + moviesList[moviesList.Length - 3].NoBorrowings);

                Console.WriteLine("Return to Member Menu (y/n)");
                if (Console.ReadLine() == "y")
                {
                    ProcessMemberMenu();
                }


            }
            catch (Exception)
            {
                Console.WriteLine("There's not enough movies in the library (at least 3).");
                Console.WriteLine("Return to Member Menu? (y/n)");
                if (Console.ReadLine() == "y")
                {
                    ProcessMemberMenu();
                }
            }
}
            
        
        
        private void addMember() {
            Console.WriteLine("Please Fill Out The Member Details");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Mobile Number: ");
            string phoneNumber = Console.ReadLine();
            while (true)
            {
                if (!IMember.IsValidContactNumber(phoneNumber))
                {
                    Console.WriteLine("Mobile Number: ");
                    phoneNumber = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Console.Write("Pin: ");
            string pin = Console.ReadLine();
            while (true)
            {
                if (!IMember.IsValidPin(pin))
                {
                    Console.WriteLine("Pin Number: ");
                    pin = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Member member = new Member(firstName, lastName, phoneNumber, pin);
            memberCollection.Add(member);
            //member.ToString();
        }
        private void removeMember()
        {
            Console.WriteLine("Please Fill Out The Member Details");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Mobile Number: ");
            string phoneNumber = Console.ReadLine();
            while (true)
            {
                if (!IMember.IsValidContactNumber(phoneNumber))
                {
                    Console.WriteLine("Mobile Number: ");
                    phoneNumber = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Console.Write("Pin: ");
            string pin = Console.ReadLine();
            while (true)
            {
                if (!IMember.IsValidPin(pin))
                {
                    Console.WriteLine("Pin Number: ");
                    pin = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Member member = new Member(firstName, lastName, phoneNumber, pin);
            bool flag = false; 
            foreach(IMovie i in movieCollection.ToArray())
            {
                if (i.Borrowers.Search(member)) {
                    flag = true;
                }
            }
            if (!flag)
            {
                memberCollection.Delete(member);
            }
        }
        private void addDVD() 
        {
            movieCollection.AddDVD();
            Console.WriteLine("Do you want to return to Staff menu? (y/n)");
            inputReturn = Console.ReadLine();
            switch (inputReturn)
            {
                case "y":
                    ProcessStaffMenu();
                    break;
            }
        }
        private void removeDVD()
        {

            movieCollection.RemoveDVD();
            Console.WriteLine("Do you want to return to Staff menu? (y/n)");
            inputReturn = Console.ReadLine();
            switch (inputReturn)
            {
                case "y":
                    ProcessStaffMenu();
                    break;
            }

        }
        private void displayPhoneNumber() 
        {
            Console.WriteLine("Please Fill Out The Member Details");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Member member = new Member(firstName, lastName);
            if(memberCollection.Find(member) != null)
            {
                Console.WriteLine(memberCollection.Find(member).ContactNumber);
            }
            else
            {
                Console.WriteLine("The member doesn't exist");
            }
            
            Console.WriteLine("Return to Staff Menu (y/n)");
            if(Console.ReadLine() == "y")
            {
                ProcessStaffMenu();
            }

        }
        private void displayMemberRentingMovie()
        {
            Console.Write("Please enter the movie title: ");
            string movieTitle = Console.ReadLine();
            IMovie movie = new Movie(movieTitle);
            if (movie != null)
            {
                if (movie.Borrowers != null)
                {
                    Console.WriteLine(movie.Borrowers.ToString());
                }
                else
                {
                    Console.WriteLine("This movie has not been borrowed by anyone");
                }
                
            }
            else
            {
                Console.WriteLine("The movie doesn't exist");
            }
            
            Console.WriteLine("Return to Staff Menu (y/n)");
            if (Console.ReadLine() == "y")
            {
                ProcessStaffMenu();
            }
        }
        

    }
}
