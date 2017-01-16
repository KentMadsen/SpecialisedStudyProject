﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dictionary.Parser;

namespace Dictionary.Parser.Characters
{
    public class Allow
    {
        public enum ObjectType
        {
            Range,
            Individual,
            None
        }

        private List< StructureTypes.Ranges > iCharacterRanges = new List< StructureTypes.Ranges >();
        private List< StructureTypes.Individuals > iCharacterIndividuals = new List< StructureTypes.Individuals >();

        // Accessor
        public int LengthOfRanges
        {
            get
            {
                return iCharacterRanges.Count;
            }
        }

        public int LengthOfIndividuals
        {
            get
            {
                return iCharacterIndividuals.Count;
            }
        }

        public int LengthOfQueries
        {
            get
            {
                return ( LengthOfIndividuals + LengthOfRanges );
            }
        }

        // Wrappers
            // Add
                // Individuals
        public void Add( StructureTypes.Individuals Individual )
        {
            AddIndividuals( Individual );
        }

        public void Add( char Individual, 
                         bool Case_Sensative )
        {
            AddIndividuals( Individual, 
                            Case_Sensative );
        }
                // Range
        public void Add( StructureTypes.Ranges Range )
        {
            AddRanges( Range );
        }

        public void Add( char Begin, char End, 
                         bool Case_Sensative )
        {
            AddRanges( Begin, End, 
                       Case_Sensative );
        }
        
            // Remove
        public void Remove( StructureTypes.Ranges Range )
        {
            RemoveRanges( Range );
        }

        public void Remove( StructureTypes.Individuals Individual )
        {
            RemoveIndividuals( Individual );
        }

        public void Remove( int x, ObjectType type )
        {
            switch( type )
            {
                case ObjectType.Individual:
                        RemoveIndividuals( x );
                    break;

                case ObjectType.Range:
                        RemoveRanges( x );
                    break;

                default:
                        // None
                    break;
            }
        }

        // Functions
            // Ranges
        public void AddRanges( StructureTypes.Ranges Range )
        {
            iCharacterRanges.Add( Range );
        }

        public void AddRanges( char Begin, char End, 
                               bool Case_Sensative )
        {
            StructureTypes.Ranges Range = new StructureTypes.Ranges();

            Range.Init( Begin, End, 
                        Case_Sensative );

            AddRanges( Range );
        }
        
        public void RemoveRanges( StructureTypes.Ranges Range )
        {
            iCharacterRanges.Remove( Range );
        }

        public void RemoveRanges( int x )
        {

        }

            // Individuals
        public void AddIndividuals( char Individual, 
                                    bool CaseSensative )
        {
            StructureTypes.Individuals Ivl = new StructureTypes.Individuals();

            Ivl.Init( Individual, 
                      CaseSensative );

            AddIndividuals( Ivl );

        }

        public void AddIndividuals( StructureTypes.Individuals Individual )
        {
            iCharacterIndividuals.Add( Individual );
        }

        public void RemoveIndividuals( StructureTypes.Individuals Individual )
        {
            iCharacterIndividuals.Remove( Individual );
        }

        public void RemoveIndividuals( int x )
        {

        }


            // Primary Functions
        public bool isAllowed( char Character )
        {
            if ( isInsideRanges( Character ) )
                return true;

            if ( isInsideIndividuals( Character ) )
                return true;

            return false;
        }

        public bool isInsideRanges( char Character )
        {

            foreach( StructureTypes.Ranges Range in iCharacterRanges )
            {

                if( Range.CaseSensative )
                {
                    // Sensative
                    // Checks if it's inside the range
                    if( isInsideRange( Range.Begin, 
                                       Range.End, 
                                       Character ) )
                    {
                        return true;
                    }

                }
                else
                {
                    // Turn characters to lower (if possible)
                    char Begin, 
                         End, 
                         LowerCharacter;

                    Begin = char.ToLower( Range.Begin );
                    End   = char.ToLower( Range.End );

                    LowerCharacter = char.ToLower( Character );

                    // Checks if it's inside the range
                    if ( isInsideRange( Begin, 
                                        End, 
                                        LowerCharacter ) )
                    {
                        return true;
                    }

                }

            }

            return false;
        }

        public bool isInsideIndividuals( char Character )
        {

            foreach( StructureTypes.Individuals Individual in iCharacterIndividuals )
            {
                if( Individual.CaseSensative )
                {
                    if ( isEqualsTo( Individual.Character, 
                                     Character ) )
                        return true;
                }
                else
                {
                    char LowerChar, 
                         lowerIndividual;

                    LowerChar = char.ToLower( Character );
                    lowerIndividual = char.ToLower( Individual.Character );

                    if ( isEqualsTo( lowerIndividual, 
                                     LowerChar ) )
                        return true;
                }
            }

            return false;
        }


            // Routines
                //
        private bool isEqualsTo( char A, 
                                 char B )
        {
            if ( A == B )
                return true;

            return false;
        }

                //
        private bool isInsideRange( char A, char B, 
                                    char C )
        {
            if ( A <= C || C >= B )
                return true;

            return false;
        }

    }

}
