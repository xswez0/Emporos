# Emporos Code Test
The database script is in the class library Emporos.DB.Script

1. There are tables of Users, Roles, Tokens, UserRoles, you have to insert some testing data in those tables to be posible to generate the token.
2. The roles to get access to the methods of the controllers are: "ADMIN" or "USER", they are static in the top part of the controller, so when you create registrys in the Role Table, make sure that are equal to "ADMIN" or "USER", also, a user can have both roles. I have set it "USER" in ItemController and "ADMIN" in PharmacyInventoryController.

