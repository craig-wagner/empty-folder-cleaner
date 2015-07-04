using CLAP;

namespace EmptyFolderCleaner
{
    class Program
    {
        static void Main( string[] args )
        {
            TheCleaner theCleaner = new TheCleaner();

            Parser.Run( args, theCleaner );
        }
    }
}
