﻿Feature: Product
Test the product page functinalities

@mytag
Scenario: Create product and verify the details
  Given I click the Product menu
  And I click the "Create" link
  And I create product with following details
    | Name       | Description        | Price | ProductType |
    | Headphones | Noise cancellation | 300   | PERIPHARAL  |
  When I click the details link of the newly created product
  Then I see all the product details are created as expected