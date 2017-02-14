Feature: ProcessOrder
	Order life cycle

@mytag
Scenario: When an order is processed a Processing event should be published
	Given An order with 2 units of a given product (id 1)
	When I process the order 
	Then a processing event should be emited indicating that 2 units of product (id 1) are being processed
