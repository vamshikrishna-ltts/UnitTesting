using BankLibrary;
using System;
using Xunit;

namespace BankingUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TrueIsTrue()
        {
            Assert.True(true);
        }

        [Fact]
        public void CantWithdrawMoreThanDepositedMoney()
        {
            var account = new BankAccount("Vamshi", 5000);

            Assert.Throws<InvalidOperationException>(
                ()=> account.MakeWithdrawl(6000, 
                DateTime.Now,
                "Attempted Withdraw money more than exisiting deposited money")
            
            );

        }

        [Fact]

        public void CantDepositNegativeMoney()
        {
            Assert.Throws<ArgumentOutOfRangeException>(

                () => new BankAccount("Invalid deposit", -55)
                
                );
        }
    }
}
