using System.Text;

namespace OldPhonePad
{
    public class Program
    {
        public static string OldPhonePad(string input)
        {
            // Check if input is valid
            if (input == null || input == "")
                return "Please enter a message to send";
            if (!input.EndsWith("#"))
            {
                return "Please end your message with a \"#\" to send";
            }

            // I create a dictionary for the keypad mapping
            var keys = new Dictionary<char, string>
        {
            {'0', " "},
            {'1', "&'()*,-./1"},
            {'2', "ABC2"},
            {'3', "DEF3"},
            {'4', "GHI4"},
            {'5', "JKL5"},
            {'6', "MNO6"},
            {'7', "PQRS7"},
            {'8', "TUV8"},
            {'9', "WXYZ9"}
        };

            var result = new StringBuilder();
            char lastDigit = '\0';
            int consecutivePresses = 0;

            // Process each character in the input, excluding the final '#'
            for (int i = 0; i < input.Length - 1; i++)
            {
                char currentInput = input[i];

                // Handle backspace
                if (currentInput == '*')
                {
                    if (result.Length > 0)
                    {
                        result.Remove(result.Length - 1, 1);
                    }
                    lastDigit = '\0';
                    consecutivePresses = 0;
                    continue;
                }

                // Handle space (pause) - reset consecutive press counter
                if (currentInput == ' ')
                {
                    lastDigit = '\0';
                    consecutivePresses = 0;
                    continue;
                }

                // Reset counter if we're pressing a different digit
                if (currentInput != lastDigit)
                {
                    lastDigit = currentInput;
                    consecutivePresses = 1;
                }
                else
                {
                    consecutivePresses++;
                }

                // Skip if not a valid keypad digit
                if (!keys.ContainsKey(currentInput))
                {
                    continue;
                }

                string possibleChars = keys[currentInput];

                // If this is a consecutive press of the same digit, remove the previous output
                if (consecutivePresses > 1 && lastDigit == currentInput)
                {
                    result.Remove(result.Length - 1, 1);
                }

                // Calculate which character to output
                int charIndex = (consecutivePresses - 1) % possibleChars.Length;
                result.Append(possibleChars[charIndex]);
            }

            return result.ToString();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("enter a number");
            string userInput = Console.ReadLine();

            Console.WriteLine(OldPhonePad(userInput));
        }
    }
}
