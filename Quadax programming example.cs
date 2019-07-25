using System;
using System.Collections.Generic;

namespace Quadax_programming_example
{
	class Program {
		static void Main(string[] args) {
			const int MAX_TRIES = 10;
			List<int> answer = new List<int>();
			List<int> attemptedAnswer = new List<int>();
			List<string> reportedAnswer = new List<string>();
			int numOfKeysEntered = 0;
			ConsoleKeyInfo chr;
			string[] resultStrings = new string[] { "+", "-", string.Empty};
			Random random = new Random();
			int tries = 0;
			bool lost = true;

			for (int i = 0; i < 4; i++) {
				answer.Add(random.Next(1, 6));
			}
			do {
				attemptedAnswer.Clear();
				reportedAnswer.Clear();
				Console.WriteLine("Guess the correct number, you have up to " + MAX_TRIES.ToString() + " tries");
				Console.WriteLine("This is try number: " + (++tries).ToString());
				Console.WriteLine("Enter 4 digits, each digit must be from 1 to 6");
				numOfKeysEntered = 0;
				do {
					chr = Console.ReadKey();
					Char keyChar = chr.KeyChar;
					if (Char.IsDigit(keyChar)) {
						attemptedAnswer.Add( int.Parse(keyChar .ToString()));
					}
					else {
						attemptedAnswer.Add(0);
					}				
				} while ( ++ numOfKeysEntered < 4);
				Console.WriteLine(Environment.NewLine);
				lost = true;
				for (int index = 0;  index < attemptedAnswer.Count; index++) {
					int digit = attemptedAnswer[index];
					if ( digit < 1 || digit >6 || !answer.Contains(digit))  {
						reportedAnswer.Add(resultStrings[2]);
						lost = true;
					}
					else if (digit == answer[index]) {
						reportedAnswer.Add(resultStrings[0]);
						if (index == 0 || !lost) {
							lost = false;
						}
					}
					else {
						reportedAnswer.Add(resultStrings[1]);
						lost = true;
					}
							
				}
				if (!lost) {
					Console.WriteLine("Congragulations, you guessed correctly");
					Console.WriteLine("Press any key to exit");
				}
				else {
					Console.WriteLine("You guessed incorrectly");
					Console.WriteLine("Results of your try are(per position), ");


					for (int index = 0; index < 4; index++) {
						Console.Write(string.Format("\t{0}", (index+1).ToString() + ":" + reportedAnswer[index].ToString()));
					}
					Console.WriteLine(Environment.NewLine);
					Console.WriteLine(" a ‘+’ indicates correct digit was guessed for that position, a ‘- indicates correct digit but in wrong position, nothing indicates an incorrect digit");

				}
			}while (tries < MAX_TRIES && lost);
			if (lost) {
				Console.WriteLine("You exceeded the maximum number of tries");
			}
			Console.WriteLine("Press any key to exit");
			Console.ReadKey(false);


		}
	}				
}
