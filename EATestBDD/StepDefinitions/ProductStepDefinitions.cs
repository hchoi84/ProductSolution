using System;
using TechTalk.SpecFlow;

namespace EATestBDD.StepDefinitions
{
    [Binding]
    public class ProductStepDefinitions
    {
        [Given(@"I click the Product menu")]
        public void GivenIClickTheProductMenu()
        {
            throw new PendingStepException();
        }

        [Given(@"I click the ""([^""]*)"" link")]
        public void GivenIClickTheLink(string create)
        {
            throw new PendingStepException();
        }

        [Given(@"I create product with following details")]
        public void GivenICreateProductWithFollowingDetails(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"I click the details link of the newly created product")]
        public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct()
        {
            throw new PendingStepException();
        }

        [Then(@"I see all the product details are created as expected")]
        public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
        {
            throw new PendingStepException();
        }
    }
}
