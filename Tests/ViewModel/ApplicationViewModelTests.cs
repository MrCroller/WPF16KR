using WPF16KR.ViewModel;
using WPF16KR.Model;

namespace Tests.ViewModel
{
    public class ApplicationViewModelTests
    {
        [Fact]
        public void DataActionChek()
        {
            // Arrange
            ApplicationViewModel avm = new();
            avm.DataMap = new List<DataFunction>()
            {
                new DataFunction()
                {
                    A = 1,
                    B = 2,
                    C = 3,
                    X = 4,
                    Y = 5,
                }
            };

            // Act
            avm.A = "52";

            // Assert
            Assert.NotNull(avm.DataMap.First());
        }
    }
}
