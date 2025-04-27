using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace OldPhonePad.Test
{
    public class ProgramTest
    {
        [Fact]
        public void OldPhonePad_ShouldReturnCorrectMessage()
        {
            // Arrange
            var input = "33#";
            var expectedOutput = "E";

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
        public void OldPhonePad_ShouldHandleSpaceCorrectly()
        {
            // Arrange
            var input = "4433555 555666#";
            var expectedOutput = "HELLO";

            // Act
            var actualOutput = Program.OldPhonePad(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void OldPhonePad_ShouldHandlBackSpaceCorrectly()
        {
            // Arrange
            var input = "227*#";
            var expectedOutput = "B";

            // Act
            var actualOutput = Program.OldPhonePad(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void OldPhonePad_ShouldHandleCorrectly()
        {
            // Arrange
            var input = "8 88777444666*664#";
            var expectedOutput = "TURING";

            // Act
            var actualOutput = Program.OldPhonePad(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
