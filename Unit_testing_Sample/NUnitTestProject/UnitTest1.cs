using Unit_testing_Sample;

namespace NUnitTestProject
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreditWithValidAmount_UpdatesBalance()
        {
            //Arrange
            double creditAmount = 5.77;
            double beginingBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 17.76;
            BankAccount account = new BankAccount("walton", beginingBalance);
            //Act
            account.Credit(creditAmount);
            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "account not credited correctly");
        }
        [Test]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginingBalance = 11.99;
            double creditamount = -100.00;
            BankAccount account = new BankAccount("walton", beginingBalance);
            //Act and Assert
            Assert.Throws<System.ArgumentOutOfRangeException>(() => account.Credit(creditamount));
        }
    }
    
}