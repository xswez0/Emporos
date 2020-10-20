# Emporos Code Test
The database script is in the class library Emporos.DB.Script

1. There are tables of Users, Roles, UserRoles, you have to insert some dummy data in those tables to be posible to generate the token. The token is saved in the Tokens table.
2. The roles to get access to the methods of the controllers are: "ADMIN" or "USER", there is the class attribute "[Authorize(Roles = "XXXXX")]" in the Controllers, so when you create records in the Role Table, make sure that are equal to "ADMIN" or "USER", a user can have both roles. I have set it "USER" in ItemController and "ADMIN" in PharmacyInventoryController.
3. You have to request a Token from the Authentication service before sendind data to the PharmacyInventory service, otherwise it will show Unauthorized. This token need to be sent in any request to the PharmacyInventory service.

[[https://www.dropbox.com/s/eza4apykiwjopie/arquitecture.png|alt=octocat]]
