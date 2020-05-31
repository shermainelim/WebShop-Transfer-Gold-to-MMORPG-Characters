# WebShop-Transfer-Gold-to-MMORPG-Characters
Project file "ProjectFile_MMORPGMaker-MV-MMO_ABS" to edit for RPG MAKER MV ENGINE provided too. Includes plugins from various developers. File size is too large to upload on github, therefore download from my folder in this link: https://drive.google.com/open?id=19VaBwdiRiUJJvaIUIceAAWSNUbTNmbMA

Created webshop with C#, MSSQL, NodeJS & ReThinkDBto load game product pages and also a coin purchase that transfer gold to MMORPG game in real time. Look at video presentation to understand our whole project. Please also check either the WIKI or PDF for more information. 

Hi everyone, before reading this documentation, it is recommended that you see the presentation video to get a better idea of how everything works first. PDF documentation is include together with the code when you download. 

Our ASP.NET CORE is the connector to SQL database and another game database called ReThinkDB which we called this restful api coded inside C#. For this CA project, we have done something special, we have made an MMO(multiple player game) accessible via any browser or mobile.

# OUR MMO Game Created with Game Engine and Additional Plugins:
http://192.119.86.65/mmo/www/

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

Names:

Shermaine Lim Si Hui

Ling Teck Moh Benedict

KyawThiha
