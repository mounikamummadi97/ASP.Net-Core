using Unit_testing_Sample;

namespace XUitTestProject
{
    public class XUnitTest1
    {
        [Fact]
        public void TestDebitWithvalidAmount()
        {//arrange
            double beginingBalnce = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("walton", beginingBalnce);
            //Act
            account.Debit(debitAmount);
            //Assert
            double actual = account.Balance;
            Assert.Equal(expected, actual);


        }
        [Fact]
        public void  TestDebitWithAmountGreaterThanBalance()
        {
            //Arrange
            double beginingBalance = 11.99;
            double debitamount = 112.99;
            BankAccount account = new BankAccount("walton", beginingBalance);
            //Act&Assert
            //Assert.NotEqual(debitamount, account.Balance);
            // Assert.Contains(exception BankAccount.Equals);
            var assert = Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitamount));// , BankAccount.DebitAmountExceedBalanceMessage);
            Assert.Contains(BankAccount.DebitAmountExceedBalanceMessage, assert.Message);
            
            
            //Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(), BankAccount.DebitAmountExceedBalanceMessage);
        }
        [Fact]
        public void TestCreditWithValidAmount()
        {
            //Arrange
            double beginingBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("walton", beginingBalance);
            account.Credit(creditAmount);
            //Assert
            double actual = account.Balance;
            Assert.Equal(expected, actual);
        }
    }
}