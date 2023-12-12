using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using scg.Generators;
using scg.Utils;
using Xunit;

namespace scg.UnitTest.Generators;

public class EndDataGeneratorTest : UnitTest
{
    [Theory, AutoMoqData]
    public void SetEndDateToEndOfNextMonthIfTodaySixteenthOrLater([Frozen] Mock<IDateTime> dateTime, EndDateGenerator sut)
    {
        dateTime.Setup(p => p.Now).Returns(new DateTime(2020, 10, 16));
        var template = sut.Token;

        var result = sut.Apply(template, new[] {"1"});

        result.Should().Be("11/30/2020");
    }

    [Theory, AutoMoqData]
    public void SetEndDateToEndOfThisMonthIfTodayBeforeSixteenth([Frozen] Mock<IDateTime> dateTime, EndDateGenerator sut)
    {
        dateTime.Setup(p => p.Now).Returns(new DateTime(2020, 11, 15));
        var template = sut.Token;

        var result = sut.Apply(template, new[] { "1" });

        result.Should().Be("11/30/2020");
    }
}