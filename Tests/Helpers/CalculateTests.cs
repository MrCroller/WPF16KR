using WPF16KR.Enum;

namespace Tests.Helpers
{
    public class CalculateTests
    {
        [Fact]
        public void FuncN_LinearFuncPositiveParams()
        {
            // Arrange
            double a = 2, b = 3, c = 1;
            double x = 4, y = 2;

            FuncType func = FuncType.Linear;

            double expected = 12;

            // Act
            double actual = Calculate.FuncN(func, a, b, c, x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FuncN_TresFuncPositiveParams()
        {
            // Arrange
            double a = 7, b = 5, c = 200;
            double x = 3, y = 12;

            FuncType func = FuncType.Tres;

            double expected = 1109;

            // Act
            double actual = Calculate.FuncN(func, a, b, c, x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FuncN_LinearFuncNegativeParams()
        {
            // Arrange
            double a = -1, b = 3, c = 5;
            double x = 4, y = -2;

            FuncType func = FuncType.Linear;

            double expected = 4;

            // Act
            double actual = Calculate.FuncN(func, a, b, c, x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FuncN_TresFuncNegativeParams()
        {
            // Arrange
            double a = 15, b = -43, c = 500;
            double x = -2, y = 20;

            FuncType func = FuncType.Tres;

            double expected = -16820;

            // Act
            double actual = Calculate.FuncN(func, a, b, c, x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FuncN_AnyFuncandZeroParams_0return()
        {
            // Arrange
            double a = 0, b = 0, c = 0;
            double x = 0, y = 0;

            var allFunc = Enum.GetValues(typeof(FuncType)).OfType<FuncType>().ToArray();
            double[] results = new double[allFunc.Length];

            double expected = 0;

            // Act
            for (int i = 0; i < allFunc.Length; i++)
            {
                results[i] = Calculate.FuncN(allFunc[i], a, b, c, x, y);
            }

            // Assert
            Assert.All(results, item => Assert.Equal(expected, item));
        }

        [Fact]
        public void ParseEnum_AnyFunc_IntReturn()
        {
            // Arrange
            var allFunc = Enum.GetValues(typeof(FuncType)).OfType<FuncType>().ToArray();
            object?[] results = new object[allFunc.Length];

            Type expected = typeof(int);

            // Act
            for (int i = 0; i < allFunc.Length; i++)
            {
                results[i] = Calculate.ParseEnum(allFunc[i]);
            }

            // Assert
            Assert.All(results, item => Assert.IsType(expected, item));
        }
    }
}