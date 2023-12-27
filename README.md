# SoloChallengeGenerator (scg)
[![Build, test and publish](https://github.com/MadCowDevelopment/SoloChallengeGenerator/workflows/Build,%20test%20and%20publish/badge.svg)](https://github.com/MadCowDevelopment/SoloChallengeGenerator/actions?query=workflow%3A"Build%2C+test+and+publish")
[![GitHub](https://img.shields.io/github/license/MadCowDevelopment/SoloChallengeGenerator)](https://github.com/MadCowDevelopment/SoloChallengeGenerator/blob/master/LICENSE)
[![Nuget](https://img.shields.io/nuget/v/scg)](https://www.nuget.org/packages/scg/)

Generator and uploader for solo boardgame challenges posted to BoardGameGeek.

Currently supports the following games: 
* Agropolis
* Cartographers
* Cartographers Heroes
* Dinosaur Island: Rawr & Write
* Dungeon Academy
* Fleet: The Dice Game
* Fields of Arle
* Gentes
* Glass Road
* Kingdomino
* On The Underground
* Paper Dungeons
* Rolling Realms
* Sprawlopolis
* The Search for Planet X
* Tiny Towns
* Trails of Tucana
* Twilight Inscription
* Welcome To

## Installation

scg is built with .NET 8. The latest version of the SDK can be found [here](https://dotnet.microsoft.com/download).

After successful installation of .NET, open a command prompt and type the following:

| Install:                     | Upgrade:                    |
| ---------------------------- | --------------------------- |
| `dotnet tool install scg -g` | `dotnet tool update scg -g` |

This will install/update the latest version of scg as a global tool. Default folder for global tools on windows is: %USERPROFILE%\\.dotnet\tools

## Usage

### Generate posts

#### Generate and automatically upload
The following command will generate a new challenge, post a thread on BGG and add an entry to the Solo Challenges geeklist:

`scg generate [game] --publish --user [username]`

or short

`scg [game] -p -u [username]`

#### Generate file only
The following command will generate a new challenge, save it to a file ForumPost.txt and open the default text editor to show it. Nothing will be uploaded to BGG. This needs to be done manually.

`scg [game]`

### Customizing posts

All user data is stored in %LOCALAPPDATA%\MadCowDevelopment\scg\Games\\[game].

Each game contains the following files:
* ForumPost.template - This is the main challenge post template. Customizations can be done here.
* GeeklistPost.template - The template for the generated geeklist entry.
* PreviousChallenges.dat - Scores from previous challenges. Format is \<threadId>,\<score>,\<user>. Either change this file directly or use the command line arguments to add/remove scores.

### Manage scores

Add a new entry to the PreviousChallenges.dat:

`scg score [game] add`

Remove the last entry:

`scg score [game] remove`

List all scores:

`scg score [game] list`

### Configure settings

The following settings can be saved in a config file :
* Username - BGG user name used during publish.
* Password - BGG password used during publish (it's stored encrypted and should be safe as long as you don't give the settings file to anyone).
* DataFolder - By default this will point to %LOCALAPPDATA% but can be changed to any other folder. I'm using my OneDrive root for example.

Set one of the settings

`scg config set [setting] [value]` e.g. `scg config set Password Password123`

Get one of the settings

`scg config get [setting]`


### Migrating from grcg

Simply copy all folders from %LOCALAPPDATA%\MadCowDevelopment\grcg\Games to %LOCALAPPDATA%\MadCowDevelopment\scg\Games

## Acknowledgements

Thanks to everyone hosting solo challenges.

Thanks to the [1 Player Guild](https://boardgamegeek.com/guild/1303) for being a great place for solo players to hang out.
