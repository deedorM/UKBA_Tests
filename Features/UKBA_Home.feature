@visa-checker
Feature: Apply UK visa checker

Background:
	Given I am on the UK visa checker website
	And I accept additional cookies
	And I click on the StartNow button

Scenario Outline: Nationality and Reason
	Then page title should be "What’s your nationality as shown on your passport or travel document?"
	When I provide nationality "<CountryName>"
	And I click continue
	And I select reason "<Reason>"
	And I click continue
	And I check duration question "<Duration>"
	And I click continue
	Then I should see "<Message>"

Examples:
	| CountryName | Reason | Duration         | Message                              |
	| Albania     | Study  | 6 months or less | You’ll need a visa to come to the UK |
	| Belarus     | Study  | 6 months or less | You’ll need a visa to come to the UK |


Scenario Outline: Duration - longer than 6 months
	When I provide nationality "<CountryName>"
	And I click continue
	And I select reason "<Reason>"
	And I click continue
	And I check duration question "<Duration>"
	And I click continue
	Then I select "<JobType>"
	And I click continue
	And information is displayed on "<ResultCard>"

Examples:
	| CountryName | Reason               | Duration             | JobType                      | ResultCard                                 |
	| Canada      | Work, academic visit | longer than 6 months | Health and care professional | You need a visa to work in health and care |


Scenario Outline: Visa outcome - Transit
	When I provide nationality "<CountryName>"
	And I click continue
	And I select reason "<Reason>"
	And I click continue
	And I select final destination "<Destination>"
	And I click continue
	Then "<Destination>" is presented as a transit destination
Examples:
	| CountryName | Reason                                  | Destination                    |
	| Ecuador     | Transit (on your way to somewhere else) | Channel Islands or Isle of Man |
	| Barbados    | Transit (on your way to somewhere else) | Rebulic of Ireland             |


Scenario Outline: Join partner or family for a long stay
  When I provide nationality "<CountryName>"
  And I click continue
  And I select reason "<Reason>"
  And I click continue
  Then I click "<Option>" option immigration status question
  And I click continue

Examples:
	| CountryName | Reason                                 | Option |
	| Fiji        | Join partner or family for a long stay | yes    |
	| Cambodia    | Join partner or family for a long stay | no     |

	Scenario Outline:  Get Married  or Stay with your child
  When I provide nationality "<CountryName>"
  And I click continue
  And I select reason "<Reason>"
  And I click continue
  Then I should see "<Message>"

Examples:
	| CountryName | Reason                                        | Message                                    |
	| Germany     | Get married or enter into a civil partnership | You’ll need a visa to come to the UK       |
	| Nigeria     | Stay with your child, if they’re at school    | You’ll need a visa to stay with your child |																