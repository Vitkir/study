namespace WorkWithFile
{
	class Program
	{
		static void Main(string[] args)
		{
			FileManager manager = new FileManager();
			manager.WatchDirectory();
		}
	}
}
