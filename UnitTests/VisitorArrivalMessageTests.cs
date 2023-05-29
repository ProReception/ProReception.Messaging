namespace UnitTests
{
    using ProReception.Messaging.Messages;
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using Xunit;

    public class VisitorArrivalMessageTests
    {
        public static IEnumerable<object[]> GetVisitPeriodTestData()
        {
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2020-04-12"), null, "12 April, 2020" };
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2020-04-13"), null, "12 - 13 April, 2020" };
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2020-05-09"), null, "12 April - 9 May, 2020" };
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2021-01-05"), null, "12 April, 2020 - 5 January, 2021" };
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2020-04-12"), "da-DK", "12 april, 2020" };
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2020-04-13"), "da-DK", "12 - 13 april, 2020" };
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2020-05-09"), "da-DK", "12 april - 9 maj, 2020" };
            yield return new object[] { DateTime.Parse("2020-04-12"), DateTime.Parse("2021-01-05"), "da-DK", "12 april, 2020 - 5 januar, 2021" };
        }

        public static IEnumerable<object[]> GetVisitorNameTestData()
        {
            yield return new object[] { "Test Testesen", "Test", "Testesen" };
            yield return new object[] { "Test Testesen Hansen", "Test", "Testesen Hansen" };
        }

        [Theory]
        [MemberData(nameof(GetVisitPeriodTestData))]
        public void TestVisitPeriod(DateTime checkinTime, DateTime expectedCheckout, string clientSiteLocale, string expectedResult)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var message = new VisitorArrivalMessage
            {
                CheckinTime = checkinTime,
                ExpectedCheckout = expectedCheckout,
                ClientSiteLocale = clientSiteLocale
            };

            message.VisitPeriod.ShouldBe(expectedResult);
        }

        [Theory]
        [MemberData(nameof(GetVisitorNameTestData))]
        public void TestVisitorName(string fullName, string firstName, string lastName)
        {
            var message = new VisitorArrivalMessage
            {
                VisitorName = fullName
            };

            message.VisitorFirstName.ShouldBe(firstName);
            message.VisitorLastName.ShouldBe(lastName);
        }
    }
}
