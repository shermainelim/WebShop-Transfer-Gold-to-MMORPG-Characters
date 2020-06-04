# WebShop-Transfer-Gold-to-MMORPG-Characters

# Updates June 2020- Shermaine:
- Successfully deployed Game Web Shop to Cloud under HTTP-
- Successfully added domain name to IP for HTTP Encryption to HTTPS
- Both Game Web Shop and MMO Game now accessible via any web or mobile browser-

- Game Web Shop Link: https://nusteamfour.online/Login/Index

- MMO Game          : http://game.nusteamfour.online/ 

------------------------------------------------------------------------------------------------------------------------------------
# Important Note: 
Please note that this web shop does not use real money to purchase stuff and that we do not support real money gambling on loot boxes. The aim is to establish a link between a web shop to transfer game money to the MMO game itself.  

# Instructions how to Test Purchase Coins from Game Webshop to MMO Game Together Online. 
- Please refer to Section 5 in this GitHub Wiki - NEW Test Purchase Coins from Game Webshop to MMO Game Together Online Updated June 2020

-------------------------------------------------------------------------------------------------------------------------------------

# WebShop-Transfer-Gold-to-MMORPG-Characters
# Introduction

Created webshop with C#, MSSQL, NodeJS & ReThinkDBto load game product pages and also a coin purchase that transfer gold to MMORPG game in real time. Look at video presentation to understand our whole project. Please also check either the WIKI or PDF for more information. 

Hi everyone, before reading this documentation, it is recommended that you see the presentation video to get a better idea of how everything works first. PDF documentation is include together with the code when you download. 

Our ASP.NET CORE is the connector to SQL database and another game database called ReThinkDB which we called this restful api coded inside C#. For this CA project, we have done something special, we have made an MMO(multiple player game) accessible via any browser or mobile at this link: 

Our CA Project is a Game Webshop that sells games and coins. The coin product is the one that when purchased from our webshop can be transferred to the real MMO game. The issue is ReThinkDB has security concerns and that we can only localhost connection to it via our C# program unless we publish and deploy the C# code to the cloud server which we currently can't due to time constraints.

Video Presentation Link: https://www.youtube.com/watch?v=8fGmZzqksig

![mmo](https://user-images.githubusercontent.com/65886071/82803639-76577880-9eb3-11ea-9a23-fbebcd29438c.png)



The basic functionalities fulfilled are: 
1. Login 
2. List Products 
3. Search 
4. Add to Cart 
5. View Cart 
6. Price Calculation 
7. Manage Activation Codes 
8. View Purchase History 
9. Logout
10. Calling Rethink DB API to link to our C# Web shop to MMO Game with plugins from RPG MAKER MV plugin Developers
11. Transferring gold from web shop in VPS Server to game character in another IP address browser
12. Displaying Visual Equipment on the game character 

Links to the game Plugin Developers:

MMORPG Plugin Developer: https://github.com/samuelcardillo

ABS Visual Equipment Plugin Developer (Using Pro Version):  https://github.com/KageDesu/Alpha-ABS/wiki/Visual-Equipment

For windows users u can download rethinkDB 2.3.6 through this link in Nexus Repository Manager : https://download.rethinkdb.com/#browse/search=keyword%3Dwindows:c770169c0b2e3ed872bbbb55a6612794

# Project file "ProjectFile_MMORPGMaker-MV-MMO_ABS" to edit for RPG MAKER MV ENGINE provided
-Includes plugins from various developers. File size is too large to upload on github, therefore download from my folder in this link: https://drive.google.com/drive/folders/1iyDbCNvO0w3eUOqO_yem0hAQ0raItW3C?usp=sharing


Names:

Shermaine Lim Si Hui

Ling Teck Moh Benedict

KyawThiha
