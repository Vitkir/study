namespace WorkWithFile
{
	class Program
	{
		static void Main(string[] args)
		{
			FileManager manager = new FileManager();
			if (args[0] == "y")
			{
				manager.ObservationMode = true;
			}
			manager.WatchDirectory();
		}
	}
}
