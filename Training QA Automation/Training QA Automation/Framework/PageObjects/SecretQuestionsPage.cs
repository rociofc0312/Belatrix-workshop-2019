using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Training_QA_Automation.Framework.PageObjects
{
    class SecretQuestionsPage
    {
        public IWebDriver driver;
        public SecretQuestionsForm secretQuestionsForm;

        public SecretQuestionsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            secretQuestionsForm = new SecretQuestionsForm(this);
        }

        [FindsBy(How = How.Id, Using = "secquestion1lg")]
        private IWebElement SecretQuestion1;

        [FindsBy(How = How.Id, Using = "SecretQuestion1_Answer")]
        public IWebElement SecretQuestion1Answer;

        [FindsBy(How = How.Id, Using = "secquestion2lg")]
        private IWebElement SecretQuestion2;

        [FindsBy(How = How.Id, Using = "SecretQuestion2_Answer")]
        public IWebElement SecretQuestion2Answer;

        [FindsBy(How = How.Id, Using = "secquestion3lg")]
        private IWebElement SecretQuestion3;

        [FindsBy(How = How.Id, Using = "SecretQuestion3_Answer")]
        public IWebElement SecretQuestion3Answer;

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        private IWebElement Next;

        private IList<string> Questions
        {
            get { return new SelectElement(SecretQuestion1).Options.Where(x => !x.GetText().Equals("")).Select(x => x.GetText()).ToList(); }
        }

        public void ClickNext()
        {
            Next.ClickOn(driver);
        }

        public class SecretQuestionsForm
        {
            private SecretQuestionsPage questionsPage;
            Faker faker;

            public SecretQuestionsForm(SecretQuestionsPage secretQuestionsPage)
            {
                this.questionsPage = secretQuestionsPage;
                faker = new Faker("en");
            }

            public void FillSecretQuestion1()
            {
                new SelectElement(questionsPage.SecretQuestion1).SelectByText(faker.PickRandom(questionsPage.Questions));
                questionsPage.SecretQuestion1Answer.Type(questionsPage.driver, faker.Random.AlphaNumeric(12));
            }

            public void FillSecretQuestion2()
            {
                new SelectElement(questionsPage.SecretQuestion2).SelectByText(faker.PickRandom(questionsPage.Questions));
                questionsPage.SecretQuestion2Answer.Type(questionsPage.driver, faker.Random.AlphaNumeric(12));
            }

            public void FillSecretQuestion3()
            {
                new SelectElement(questionsPage.SecretQuestion3).SelectByText(faker.PickRandom(questionsPage.Questions));
                questionsPage.SecretQuestion3Answer.Type(questionsPage.driver, faker.Random.AlphaNumeric(12));
            }

            public void PopulateQAFormAndClickNext()
            {
                FillSecretQuestion1();
                FillSecretQuestion2();
                FillSecretQuestion3();
                questionsPage.ClickNext();
            }
        }
    }
}
