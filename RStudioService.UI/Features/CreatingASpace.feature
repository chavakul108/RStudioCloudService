Feature: CreatingASpace
	Inorder to load the RStudio IDE
	As a user on the cloud
	I need to Create a Space, project with in the space 


@mytag
Scenario: HomePageNavigation
	Given User selects Log In on the RStudio Cloud Hope page
	And User Enters Email in the text box
	When Click on Continue button
	Then RStudio Cloud Projects Page is displayed to the user

Scenario: Validate a Space is created
	Given User selects Log In on the RStudio Cloud Hope page
	And User Enters Email in the text box
	When Click on Continue button
	And User selects New Space
	Then New Space is created
		

Scenario: Validate a Project is created and IDE is loaded
	Given User selects Log In on the RStudio Cloud Hope page
	And User Enters Email in the text box
	When Click on Continue button
	And User Selects New Project from the drop down
	And Untitle Project is displayed to the user
	Then IDE is loaded successfully
	

