﻿Feature: Create, read, update, delete product
	As a connected user
	I should be able to create, read, update and delete a product

Scenario: Create a new product
	Given I navigate to the 'Product/Edit' page
	And  I enter the product
		|Name			|Code		|Unit Price		|Units In Stock	 |
		|Bread			|1345		|3.2		    |400			 |
		
	When I click the 'saveProductBtn' button
	Then I should be redirected to the 'Product/GetProducts' page
	And I should have the product listed in the grid

Scenario: Update a product
	Given I have the products
		|Id		                                    |Name			|Code		|Unit Price		|Units In Stock	 |
		|362D6764-07A3-4A03-A430-00E21FFB4998		|Bread			|1345		|3.2		    |400			 |
    And I navigate to the 'Product/GetProducts' page
	And I click edit for the '362D6764-07A3-4A03-A430-00E21FFB4998' product
	And I enter the product
		|Id		                                    |Name			|Code		|Unit Price		|Units In Stock	 |
		|362D6764-07A3-4A03-A430-00E21FFB4998		|Onions			|1245		|1.2		    |100			 |
	When I click the 'saveProductBtn' button
	Then I should be redirected to the 'Product/GetProducts' page
	And I should have the product listed in the grid

Scenario: Delete a product
	Given I have the products
		|Id		                                    |Name			|Code		|Unit Price		|Units In Stock	 |
		|362D6764-07A3-4A03-A430-00E21FFB4998		|Bread			|1345		|3.2		    |400			 |
		|E244995A-BFDA-452D-A6DF-A2C8D24BAEAB		|Onions			|1245		|1.2		    |100			 |
    And I navigate to the 'Product/GetProducts' page
	When I click delete for the '362D6764-07A3-4A03-A430-00E21FFB4998' product
	Then The grid should not contain the '362D6764-07A3-4A03-A430-00E21FFB4998' product
