using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace OldPhonePad.Test
{
    public class ProgramTest
    {
        [Fact]
        public void OldPhonePad_ShouldReturnCorrectMessage_ForValidInput()
        {
            // Arrange
            var input = "222#";
            var expectedOutput = "C";

            // Act
            var actualOutput = Program.OldPhonePad(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void OldPhonePad_ShouldReturnErrorMessage_ForEmptyInput()
        {
            // Arrange
            var input = "";
            var expectedOutput = "Please enter a message to send";

            // Act
            var actualOutput = Program.OldPhonePad(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void OldPhonePad_ShouldHandleBackspaceCorrectly()
        {
            // Arrange
            var input = "22*2#";
            var expectedOutput = "A";

            // Act
            var actualOutput = Program.OldPhonePad(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void OldPhonePad_ShouldHandleSpaceCorrectly()
        {
            // Arrange
            var input = "2202#";
            var expectedOutput = "B A";

            // Act
            var actualOutput = Program.OldPhonePad(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
