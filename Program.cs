using System;
using System.IO;

namespace Closure {
	class Program {
		static void Main(string[] args) {

			// Fields
			string path = "ClosureBatch.bat";
			string command = "SHUTDOWN -s -t ";
			string abortCommand = "SHUTDOWN -a";
			int delay;
			int minuteMultiplier = 60;
			int hourMultiplier = 3600;
			
			// Initialize console
			Init();

			// Aborts any active shutdowns
			File.WriteAllText(path, abortCommand);

			// Runs file
			System.Diagnostics.Process.Start(path);

			// Writes info
			Console.WriteLine("\n-Enter shutdown delay-\n<Input> = delay in seconds\n<Input>m = delay in minutes\n<Input>h = delay in hours\n");
			Console.WriteLine("<> shalt be left out");

			// Gets and converts input
			int multiplier = 1;
			string input = Console.ReadLine();
			if (input.Length > 1 && Char.IsLetter(input[input.Length - 1])) {
				multiplier = input[input.Length - 1] == 'm' ? minuteMultiplier : hourMultiplier;
				delay = Convert.ToInt32(input.Remove(input.Length - 1)) * multiplier;
			} else {
				delay = Convert.ToInt32(input);
			}

			// Prints to file
			File.WriteAllText(path, command + delay);

			// Runs file
			System.Diagnostics.Process.Start(path);
		}

		// Method for console initialization
		static void Init() {
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Title = "Closure";
			Console.Clear();
		}
	}
}
