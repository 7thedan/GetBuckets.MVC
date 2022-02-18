👋 Hi, I’m @7thedan
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GETBUCKETS.MVC
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GetBuckets is a #C MVC to help, sort, and rate basketball courts, players, and teams.

The idea behind this project was to have any basketball players who would like to find a gym around their city or area to play public/private basketball courts which 
they can leave a review or inform other players about the gym. It even form a team at a certain location to play against any opposing team. 

our target audience is are basketball player of any experienced or unexperienced level.

Why did I build this? Basketball is one of my favorite hobbies and during COVID every basketball court I used to go to shut down and didn't know any outdoor courts that were 
availiable. Nor did I know anyone to play with. Upon my search for basketball courts I wish there were reviews that were left for conditions of the courts whether it's not 
playable or playable and if the players there are highly skilled or an average joe for people who would like to play with the same level. 


How it works:
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
GetBuckets is a fullly equipped CRUD that permits user log in, then create, view, update, delete a player, location, review, and team.

IMPORTANT: To add location, review, or team you must create a playerid first! And follow the following steps:
1. Player - If no player exists you cannot leave any reviews, create any locations, or form a team. CREATE a player!.
2. Team - If no team exist, or the team you want is not added, please add this after creating a player.
3. Location - PlayerID are required to create a location, as player would be the one to leave a information about the location. 
4. Review - LocationID are required to create review. Without a location there is no review to leave. 

WARNINGS:

1. If you delete Location you will delete all of the informatin regarding location and all the reviews that were left.
2. If you delete Player you will be deleting all of the information about the player on the team, location, and review.

Structure and Development
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Table breakdown: https://app.quickdatabasediagrams.com/#/d/f4n9Dc
Planning breakdown: https://docs.google.com/document/d/1jQosrVa_RaA69NQ_OKYvY22XjSuIgNPZks2YkPNxgoY/edit#heading=h.apyy2fblhnhk
