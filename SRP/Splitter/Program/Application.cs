﻿using System;

using System.Collections.Generic;

using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

namespace Splitter
{

    class Application
    {
        private Boolean Continue = true;

        public void initialise( String[] Arguments )
        {


        }

        public void start()
        {
            TextSplitter splitter = new TextSplitter( @"C:\Users\Fract\Desktop\Workspace\Reuters" );

            splitter.Initialise();

            splitter.ReadFiles();

            Database.Tokens Register = new Database.Tokens( "./Base.accdb" );
            
            foreach( String s in splitter.TokensList )
            {
                Register.InsertWord( s );
            }

            while( Continue )
            {

            }

        }

        // Last minute actions
        public void end()
        {

        }

        // clear memory, etc.
        public void clear()
        {

        }
        
    }

}
