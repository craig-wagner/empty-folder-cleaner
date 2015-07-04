using System;
using System.IO;
using System.Linq;
using CLAP;

namespace EmptyFolderCleaner
{
    internal class TheCleaner : ConsoleBase
    {
        [Verb( IsDefault = true )]
        public void Report( [Parameter( Required = true, Description = "Folder where The Cleaner should start looking for empty folders." )] string rootFolder )
        {
            RecurseFolders( rootFolder, false );
        }

        [Verb]
        public void Clean( [Parameter( Required = true, Description = "Folder where The Cleaner should start looking for empty folders." )] string rootFolder )
        {
            RecurseFolders( rootFolder, true );
        }

        private void RecurseFolders( string rootFolder, bool deleteEmptyFolders )
        {
            if( String.IsNullOrEmpty( rootFolder ) )
            {
                throw new ArgumentException(
                    "Starting directory is a null reference or an empty string",
                    "rootFolder" );
            }

            try
            {
                foreach( var folder in Directory.EnumerateDirectories( rootFolder ) )
                {
                    RecurseFolders( folder, deleteEmptyFolders );
                }

                var entries = Directory.EnumerateFileSystemEntries( rootFolder );

                if( !entries.Any() )
                {
                    if( !deleteEmptyFolders )
                    {
                        Console.WriteLine( "{0} is empty.", rootFolder );
                    }
                    else
                    {
                        try
                        {
                            Directory.Delete( rootFolder );
                            Console.WriteLine( "{0} has been deleted.", rootFolder );
                        }
                        catch( UnauthorizedAccessException ) { }
                        catch( DirectoryNotFoundException ) { }
                    }
                }
            }
            catch( UnauthorizedAccessException ) { }
        }
    }
}
