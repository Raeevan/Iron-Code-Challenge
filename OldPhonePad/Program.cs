using System.Text;

namespace OldPhonePad
{
    public class Program
    {
        #region -- Dictionary --
        private static readonly Dictionary<char, string> KeypadMapping = new()
        {
            ['0'] = " ",
            ['1'] = "&'()*,-./1",
            ['2'] = "ABC2",
            ['3'] = "DEF3",
            ['4'] = "GHI4",
            ['5'] = "JKL5",
            ['6'] = "MNO6",
            ['7'] = "PQRS7",
            ['8'] = "TUV8",
            ['9'] = "WXYZ9"
        };
        #endregion
        #region -- OldPhonePad --
        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please enter a message to send";

            if (!input.EndsWith("#"))
                return "Please end your message with a \"#\" to send";

            var result = new StringBuilder();
            char lastDigit = '\0';
            int consecutivePresses = 0;

            foreach (var currentInput in input[..^1]) // Exclude the final '#'
            {
                switch (currentInput)
                {
                    case '*': // Handle backspace
                        if (result.Length > 0)
                            result.Remove(result.Length - 1, 1);
                        ResetState(ref lastDigit, ref consecutivePresses);
                        break;

                    case ' ': // Handle space (pause)
                        ResetState(ref lastDigit, ref consecutivePresses);
                        break;

                    default:
                        if (!KeypadMapping.ContainsKey(currentInput))
                            continue;

                        if (currentInput != lastDigit)
                        {
                            lastDigit = currentInput;
                            consecutivePresses = 1;
                        }
                        else
                        {
                            consecutivePresses++;
                        }

                        var possibleChars = KeypadMapping[currentInput];
                        if (consecutivePresses > 1)
                            result.Remove(result.Length - 1, 1); // Remove previous output

                        var charIndex = (consecutivePresses - 1) % possibleChars.Length;
                        result.Append(possibleChars[charIndex]);
                        break;
                }
            }

            return result.ToString();
        }
        
        private static void ResetState(ref char lastDigit, ref int consecutivePresses)
        {
            lastDigit = '\0';
            consecutivePresses = 0;
        }
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            string userInput = Console.ReadLine();
            Console.WriteLine(OldPhonePad(userInput));
        }
    }
}