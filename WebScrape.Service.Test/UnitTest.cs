using SearchEngine.Library;
using WebScrape.Service.Commands;
using WebScrape.Service.Validator;

namespace WebScrape.Service.Test
{
    public class Tests
    {
        AddRankValidator validationRules;
        AddRankCommand command;

        [SetUp]
        public void Setup()
        {
            validationRules = new AddRankValidator();
            command = new AddRankCommand(0, "", "");
        }

        [Test]
        public void Test1()
        {
            Assert.That(validationRules.Validate(new AddRankCommand(SearchEngineType.Google, "", "")).IsValid, Is.EqualTo(false));
            Assert.That(validationRules.Validate(new AddRankCommand(SearchEngineType.LocalFile, "asdf", "dfa")).IsValid, Is.EqualTo(true));
            Assert.That(validationRules.Validate(new AddRankCommand(SearchEngineType.Bing, "", "sf")).IsValid, Is.EqualTo(false));
            Assert.That(validationRules.Validate(new AddRankCommand(SearchEngineType.Google, "asf", "")).IsValid, Is.EqualTo(false));
            Assert.That(validationRules.Validate(new AddRankCommand(SearchEngineType.LocalFile, "", "")).IsValid, Is.EqualTo(false));
            Assert.That(validationRules.Validate(new AddRankCommand(SearchEngineType.DuckDuckGo, "asfad", "asffsadf")).IsValid, Is.EqualTo(true));
            Assert.That(validationRules.Validate(new AddRankCommand(SearchEngineType.Yahoo, "", "")).IsValid, Is.EqualTo(false));
        }
    }
}