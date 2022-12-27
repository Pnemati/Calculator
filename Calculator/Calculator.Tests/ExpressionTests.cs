using Calculator.Maths;

namespace Calculator.Tests
{
    public class ExpressionTests
    {
        [Fact]
        public void SimpleAdditionTest()
        {
            string expression = "1 + 2";
            Assert.Equal(3, Evaluator.EvaluateExpression(expression));
        }
        [Fact]
        public void SimpleSubtractionTest()
        {
            string expression = "1 - 2";
            Assert.Equal(-1, Evaluator.EvaluateExpression(expression));
        }

        [Theory]
        [InlineData("1 - 2", -1d)]
        [InlineData("1 + 2", 3d)]
        [InlineData("1 * 2", 2d)]
        [InlineData("1 / 2", 0.5d)]
        public void MultipleExpressionsTest(string expression, double expectedValue)
        {
            Assert.Equal(expectedValue, Evaluator.EvaluateExpression(expression));
        }
    }
}