using WPF16KR.Model;

namespace Tests.Model
{
    public class DataFunctionTests
    {
        [Fact]
        public void Property_NullChekA()
        {
            // Arrange
            DataFunction data = new()
            {
                A = 1
            };
            object? actual;

            // Act
            actual = data.A;

            // Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void Property_NullChekY()
        {
            // Arrange
            DataFunction data = new()
            {
                Y = 1
            };
            object? actual;

            // Act
            actual = data.Y;

            // Assert
            Assert.NotNull(actual);
        }
    }
}
