# Iron-Code-Challenge - Old Phone Pad Text Converter

A C# implementation that simulates typing on an old phone keypad with multi-tap functionality, including backspace and send operations.

## Features

- Converts numeric input to text using traditional phone keypad mapping
- Supports multi-tap input (e.g., "22" → "B")
- Handles backspace operations with the '*' key
- Processes spaces as pauses between same-button presses
- Requires '#' to terminate input (send button)
- Includes digits as final options in their character sets (e.g., "2222" → "2")

## Keypad Mapping

| Key | Characters      |
|-----|-----------------|
| 0   | (space)         |
| 1   | &'()*,-./1      |
| 2   | ABC2            |
| 3   | DEF3            |
| 4   | GHI4            |
| 5   | JKL5            |
| 6   | MNO6            |
| 7   | PQRS7           |
| 8   | TUV8            |
| 9   | WXYZ9           |
| *   | Backspace       |
| #   | Send/End        |

## Usage

1. Clone the repository
2. Run the program
3. Enter your numeric input (the program will automatically append '#' for you)
4. View the converted text output

### Example Inputs:

| Input                  | Output  |
|------------------------|---------|
| `33#`                  | "E"     |
| `227*#`                | "B"     |
| `4433555 555666#`      | "HELLO" |
| `8 88777444666*664#`   | "TURING"|

## How It Works

The program:
1. Validates input ends with '#'
2. Processes each character sequentially
3. Tracks consecutive button presses
4. Uses modulo arithmetic to cycle through available characters
5. Handles backspaces by removing the last character
6. Treats spaces as pauses between same-button presses

## Requirements

- .NET Core 3.1 or later
