// Phase 2
// An implementation of MovieCollection ADT
// 2022


using System;

//A class that models a node of a binary search tree
//An instance of this class is a node in a binary search tree 
public class BTreeNode
{
	private IMovie movie; // movie
	private BTreeNode lchild; // reference to its left child 
	private BTreeNode rchild; // reference to its right child

	public BTreeNode(IMovie movie)
	{
		this.movie = movie;
		lchild = null;
		rchild = null;
	}

	public IMovie Movie
	{
		get { return movie; }
		set { movie = value; }
	}

	public BTreeNode LChild
	{
		get { return lchild; }
		set { lchild = value; }
	}

	public BTreeNode RChild
	{
		get { return rchild; }
		set { rchild = value; }
	}
}

// invariant: no duplicates in this movie collection
public class MovieCollection : IMovieCollection
{
	private BTreeNode root; // movies are stored in a binary search tree and the root of the binary search tree is 'root' 
	private int count; // the number of (different) movies currently stored in this movie collection 



	// get the number of movies in this movie colllection 
	// pre-condition: nil
	// post-condition: return the number of movies in this movie collection and this movie collection remains unchanged
	public int Number { get { return count; } }

	// constructor - create an object of MovieCollection object
	public MovieCollection()
	{
		root = null;
		count = 0;
	}



	// Check if this movie collection is empty
	// Pre-condition: nil
	// Post-condition: return true if this movie collection is empty; otherwise, return false.
	public bool IsEmpty()
	{
		//To be completed
		if (root == null)
		{
			return true;
		}
		else
			return false;

	}



	// Insert a movie into this movie collection
	// Pre-condition: nil
	// Post-condition: the movie has been added into this movie collection and return true, if the movie is not in this movie collection; otherwise, the movie has not been added into this movie collection and return false.
	//Highly inspired by the provided Week 5 Tutor Code 

	public bool Insert(IMovie movie)
	{
		//to be completed
		if (root == null)
		{
			root = new BTreeNode(movie);  //If root is empty, just add new movie return new node
		}
		else
			Insert(movie, root); //Using Private Void add movie to root
		count++; //Increment the number of movies
		return true;
	}


	private void Insert(IMovie movie, BTreeNode ptr)
	{
		//Recurring down the tree
		if (movie.CompareTo(ptr.Movie) < 0)
		{
			if (ptr.LChild == null)
				ptr.LChild = new BTreeNode(movie); //Less than root, recursively call left subtree 

			else
				Insert(movie, ptr.LChild);

		}
		else
		{
			if (ptr.RChild == null)
				ptr.RChild = new BTreeNode(movie); //Else recurisvely call right subtree 
			else
				Insert(movie, ptr.RChild);
		}
	}




	// Delete a movie from this movie collection
	// Pre-condition: nil
	// Post-condition: the movie is removed out of this movie collection and return true, if it is in this movie collection; return false, if it is not in this movie collection
	//Highly Inspired from Provided Week 5 Tutor Code 
	public bool Delete(IMovie movie)
	{
		//To be completed
		// search for item and its parent
		BTreeNode ptr = root; // search reference
		BTreeNode parent = null; // parent of ptr
		while ((ptr != null) && (movie.CompareTo(ptr.Movie) != 0))
		{
			parent = ptr;
			if (movie.CompareTo(ptr.Movie) < 0) // move to the left child of ptr
				ptr = ptr.LChild;

			else
				ptr = ptr.RChild;
		}

		if (ptr != null) // if the search was successful
		{
			// case 3: item has two children
			if ((ptr.LChild != null) && (ptr.RChild != null))
			{
				// find the right-most node in left subtree of ptr
				if (ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
				{
					ptr.Movie = ptr.LChild.Movie;
					ptr.LChild = ptr.LChild.LChild;
				}
				else
				{
					BTreeNode p = ptr.LChild;
					BTreeNode pp = ptr; // parent of p
					while (p.RChild != null)
					{
						pp = p;
						p = p.RChild;
					}
					// copy the item at p to ptr
					ptr.Movie = p.Movie;
					pp.RChild = p.LChild;
				}
			}
			else // cases 1 & 2: item has no or only one child
			{
				BTreeNode c;
				if (ptr.LChild != null)
					c = ptr.LChild;
				else
					c = ptr.RChild;

				// remove node ptr
				if (ptr == root) //need to change root
					root = c;

				else
				{
					if (ptr == parent.LChild)
						parent.LChild = c;
					else
						parent.RChild = c;
				}
			}
			count--; //Decrement count once deleted 
			return true;

		}
		//Else return false
		else
			return false;
	}




	//// Search for a movie in this movie collection
	//// pre: nil
	//// post: return true if the movie is in this movie collection;
	////	     otherwise, return false.
	///Highly inspired by Week 5 Tutor code 
	public bool Search(IMovie movie)
	{
		return Search(movie, root);
	}

	private bool Search(IMovie movie, BTreeNode r)
	{
		if (r != null)
		{
			if (movie.CompareTo(r.Movie) == 0)
				return true; //If movie is found 
			else
				if (movie.CompareTo(r.Movie) < 0)
				return Search(movie, r.LChild); //Search the left subtree 
			else
				return Search(movie, r.RChild); //Search the right subtree 
		}
		else
			return false;
	}



	//// Search for a movie by its title in this movie collection  
	//// pre: nil
	//// post: return the reference of the movie object if the movie is in this movie collection;
	////	     otherwise, return null.
	///Highly inspired by week 5 tutor code 
	public IMovie Search(string movietitle)
	{
		//To be completed
		//return Search(movietitle, root);
		return Search(movietitle, root);
	}

	private IMovie Search(string movietitle, BTreeNode r)
	{
		if (r != null)
		{
			if (movietitle.CompareTo(r.Movie.Title) == 0) //If Movietitle is found
				return r.Movie;
			else
				if (movietitle.CompareTo(r.Movie.Title) < 0)
				return Search(movietitle, r.LChild); //Search the left subtree
			else
				return Search(movietitle, r.RChild); //Search the right subtree
		}
		else
			return null;
	}




	//// Store all the movies in this movie collection in an array in the dictionary order by their titles
	//// Pre-condition: nil
	//// Post-condition: return an array of movies that are stored in dictionary order by their titles
	///
	int i_ToArray = 0; //Initialise Integer i_ToArray to 0 

	public IMovie[] ToArray()
	{
		//To be completed
		i_ToArray = 0;
		IMovie[] array = new IMovie[Number]; //Create a new IMovie Array 
		InOrderTraverse(root, array, i_ToArray);
		return array;
	}

	private void InOrderTraverse(BTreeNode root, IMovie[] array, int i)
	{
		if (root != null)
		{
			InOrderTraverse(root.LChild, array, i_ToArray); //Traverse the left subtree
			array[i_ToArray] = root.Movie;
			i_ToArray++; //Increment i_ToArray
			InOrderTraverse(root.RChild, array, i_ToArray); //Traverse the right subtree 
		}
	}

	//To unit test
	//Create a for loop 
	//IMovie[] array = collectionTree.ToArray();

	//       for (int i = 0; i<array.Length; i++)
	//       {
	//           Console.WriteLine(array[i].ToString());
	//       }



	// Clear this movie collection
	// Pre-condotion: nil
	// Post-condition: all the movies have been removed from this movie collection 
	public void Clear()
	{
		//To be completed
		root = null; //Clear 
	}

	public void AddDVD() {

		Console.WriteLine("Movie Title:");
		string movieTitle = Console.ReadLine();
		IMovie movie = Search(movieTitle);

		if (movie != null)
		{
			Console.Clear();
			Console.WriteLine("How many copies would you like to add?");
			int copies = Int32.Parse(Console.ReadLine());
			movie.AvailableCopies +=  copies;
			Console.WriteLine(movie.ToString());
		}
		else {
			Console.Clear();
			string movieGenreString = "\n" + new string('=', 25) + "Movie genre" + new string('=', 25) + "\n" + "\n" +
				"1. Action\n" +
				"2. Comedy\n" +
				"3. History\n" +
				"4. Drama\n" +
				"5. Western\n" +
				"Enter your choice ==> (1,2,3,4,5)";
			Console.WriteLine(movieGenreString);
			string movieGenre = Console.ReadLine();
			if (movieGenre == null) {
				movieGenre = "1";
			}
			int movieGenreEnum = Int32.Parse(movieGenre);
			Console.Clear();
			string movieClassificationString = "\n" + new string('=', 25) + "Movie Classification" + new string('=', 25) + "\n" + "\n" +
				"1. G\n" +
				"2. PG\n" +
				"3. M\n" +
				"4. M15+\n" +
				"Enter your choice ==> (1,2,3,4)";
			Console.WriteLine(movieClassificationString);
			string movieClassification = Console.ReadLine();
			if (movieClassification == null)
			{
				movieClassification = "1";
			}
			int movieClassificationEnum = Int32.Parse(movieClassification);

			Console.Clear();
			Console.WriteLine("Movie Duration (in minutes):");

			int movieDuration = Int32.Parse(Console.ReadLine());


			Console.Clear();
			Console.WriteLine("Movie Copies");
			int movieCopies = Int32.Parse(Console.ReadLine());

			Movie movieName = new Movie(movieTitle, (MovieGenre)movieGenreEnum, (MovieClassification)movieClassificationEnum, movieDuration, movieCopies);
			Insert(movieName);
			Console.WriteLine(movieName.ToString());
		}

	}
	public void RemoveDVD()
	{
		Console.WriteLine("Movie Title:");
		string movieTitle = Console.ReadLine();
		IMovie movie = Search(movieTitle);

		if (movie != null)
		{
			Console.Clear();
			Console.WriteLine("How many copies would you like to remove?");
			int copies = Int32.Parse(Console.ReadLine());
			if (movie.AvailableCopies >= copies) {
				movie.AvailableCopies -= copies;
			}
			else {
				Console.WriteLine("Not enough DVDs");
				Console.WriteLine("Would you like to remove another movie? (y/n)");
				string inputReturn = Console.ReadLine();
				switch (inputReturn)
				{
					case "y":
						RemoveDVD();
						break;
					case "n":
						break;
				}
			}
			Console.WriteLine(movie.ToString());
		}
		else {
			Console.WriteLine("This movie does not exist, would you like to remove another movie? (y/n)");
			string inputReturn = Console.ReadLine();
			switch (inputReturn)
			{
				case "y":
					RemoveDVD();
					break;
				case "n":
					break;
			}
		}

	}
}





