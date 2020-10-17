# Emporos Code Test
The database script is in the class library Emporos.DB.Script

1. There are tables of Users, Roles, UserRoles, you have to insert some dummy data in those tables to be posible to generate the token. The token is saved in the Tokens table.
2. The roles to get access to the methods of the controllers are: "ADMIN" or "USER", they are static in the top part of the controller, so when you create records in the Role Table, make sure that are equal to "ADMIN" or "USER", a user can have both roles. I have set it "USER" in ItemController and "ADMIN" in PharmacyInventoryController.

