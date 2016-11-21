﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Parser;

/* 
   Author  : Kent vejrup Madsen
  
   Place   : Rybners Gymnasium - Højere Tekniske Gymnasium (HTX)

   Project : Studieretnings Project
             Specialised Study Project

   Subject : Tekst Klassificering, 
             Text Classifying
   
   Note    : Rewritten 
 */

// Naive Insert Document
namespace Studieretningsproject
{

    class Program
    {
        static Orders.Commands Command;
        
        static void Main( string[] Arguments )
        { 

            // Initialise Command
            Initialise( );
            
            // Run chosen command
            Run();

            // Clean Exit
            Clean();

        } // End Main

        static void Initialise( )
        {
            Command.Initialise();
        } // End Initialise()

        //
        static void Run()
        {
            Command.Run();
        } // End Run()

        //
        static void Clean()
        {
            Command.Clean();
        } // End Clean()
        
    } // End Class Program

} // End namespace
