namespace UnitTests
{
    using ProReception.Messaging.Messages;
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class VisitorArrivalMessageTests
    {
        public static IEnumerable<object[]> GetVisitPeriodTestData()
        {
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2020-04-12"), "12 April, 2020" };
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2020-04-13"), "12 - 13 April, 2020" };
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2020-05-09"), "12 April - 9 May, 2020" };
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2021-01-05"), "12 April, 2020 - 5 January, 2021" };
        }

        [Theory]
        [MemberData(nameof(GetVisitPeriodTestData))]
        public void TestVisitPeriod(DateTime checkinTime, DateTime expectedCheckout, string expectedResult)
        {
            var message = new VisitorArrivalMessage
            {
                CheckinTime = checkinTime,
                ExpectedCheckout = expectedCheckout
            };

            message.VisitPeriod.ShouldBe(expectedResult);
        }
    }
}
