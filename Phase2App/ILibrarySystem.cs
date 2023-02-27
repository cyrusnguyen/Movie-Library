//CAB301 project - Phase 2 
//The specification of MovieCollection ADT
//2022

using System;

// invariant: no duplicates in this movie collection
public interface ILibrarySystem
{
   public void PrintMainMenu();

    public void ProcessMainMenu();

    public void ProcessMemberMenu();

    public void PrintMemberMenu();

    public void PrintStaffMenu();

    public void ProcessStaffMenu();

}

