Feature: Create, read, update, delete product
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
		|Name			|Code		|Unit Price		|Units In Stock	 |
		|Bread			|1345		|3.2		    |400			 |
    And I navigate to the 'Product/GetProducts' page
	And I click on the product edit link
	And I enter the product
		|Name			|Code		|Unit Price		|Units In Stock	 |
		|Onions			|1245		|1.2		    |100			 |
	When I click the 'saveProductBtn' button
	Then I should be redirected to the 'Product/GetProducts' page
	And I should have the product listed in the grid

Scenario: Delete a product
	Given I have the products
		|Name			|Code		|Unit Price		|Units In Stock	 |
		|Bread			|1345		|3.2		    |400			 |
		|Onions			|1245		|1.2		    |100			 |
    And I navigate to the 'Product/GetProducts' page
	When I click delete for the 'Bread' product
	Then The grid should not contain the 'Bread' product
