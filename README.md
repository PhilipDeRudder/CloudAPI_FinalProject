<!-- TABLE OF CONTENTS -->
# Music API

<!-- ABOUT THE PROJECT -->
## About The Project
De Muziek api biedt mogelijkheden om informatie over Artiesten, Albums en Tracks op te verkrijgen, verwijderen, updaten en aaan te maken
### SWAGGER:
Omdat postman redelijk wat tijd inneemt om actions te testen heb ik swagger aan mijn project toegevoegd. Wanneer je de API opstart en vervolgens surft naar localhost:5001/swagger krijg je alle enpoints te zien van je API.
#### Examples:




### Classes:
De Api maakt gebruik van 3 klassen met volgende properties:
- Artist: Id(int), artistname(stringp
- Album: AlbumId(int), Title(string), Genre(string),release_date(DateTime), ArtistId(int), Artist(Artist)
- Track: Id(int), track_name(strin), genre(string), ArtistTrack(ArtistTrack)
- ArtistTrack

### Relations between klasses:
- 1 veel Relatie: Tussen Artist en Album met FK artistId bij Album
- Veel op Veel Relatie: Tussen Artist Tracks. Bekomen door een joint table te maken ArtistTrack met ArtistId en TrackId

### Controllers CRUD Actions:
#### AlbumC ontroller:
- Create: je kan een album aanmaken waar je een titel van de album, genre, artist id, en release date mee te geven.
- Read: Je kan alle albums te zien krijgen, of een bepaald aantal per pagina door het aantal mee te geven, sorteren op genre en title en filteren op genre en tile
- Update: je kan een album updaten op Album Id. je een titel van de album, genre, artist id, en release date mee te geven.
- Delete: je kan een album verwijderen door een id mee te geven.
##### Validation
In de Album klasse wordt er gebruikt gemaakt van enkele validations. Wanneer er niet aan wordt voldaan wordt er een badrequest teruggestuurd met een error message:
- Title: Required | Error message: title is required (custom)
- Genre: Required, Strinlength van 27 char | Error message Required: genre is required, Error message Stringlength: maximum lentgth of 27 char
- ArtistId: Range | error message: between 1 and 100
- release_date: Range(typeof(DateTime) | error message: waarde moet tussen 1/1/1860 en 27/05/2020 zijn.

#### Artist Controller:
- Create: je kan een artist aanmaken door  naam van de artist mee te geven
- Read: je kan een bepaalde artiest opvragen dmv zijn naam. 
- Update: je kan een Artist updaten door zijn id mee te geven en vervolgens zijn nieuwe naam mee te geven.
- Delete: je kan een artist verwijderen door zijn id mee te geven.
##### Validation
In de Artist klasse wordt er gebruikt gemaakt van enkele validations. Wanneer er niet aan wordt voldaan wordt er een badrequest teruggestuurd met een error message:
- artistname: Required | error message: artistname is required


#### Track Controller:
- Create: je kan een track aanmaken door  naam en genre  te geven
- Read: je kan een bepaalde artiest opvragen dmv zijn id. je kan alle tracks te zien krijgen, of een bepaald aantal per pagina door het aantal mee te geven, sorteren op name en filteren op genre en name
- Update: je kan een Artist updaten door zijn id mee te geven en vervolgens zijn nieuwe naam mee te geven.
- Delete: je kan een artist verwijderen door zijn id mee te geven.
##### Validation
In de track klasse wordt er gebruikt gemaakt van enkele validations. Wanneer er niet aan wordt voldaan wordt er een badrequest teruggestuurd met een error message:
- artistname: Required | error message: artistname is required




## Getting Started

instructies voor het lokaal opzetten van uw project. Volg deze eenvoudige voorbeeldstappen om een lokale kopie in gebruik te nemen.

### Prerequisites

list things you need to use the software and how to install them.
*Visual Studio Code/Visual Studio 2019
* npm
```sh
npm install npm@latest -g
```

### Installation

1. Clone the repo
```sh
git clone --> link van public github link normaal
```
2. Open Client folder

  2.1.Install NPM packages
```sh
npm install
```
  2.2. startup
```sh
ng serve
```
3. open Project Folder
  3.1.Install NPM packages
    ```sh
    dotnet run
    ```

## Usage Client



<!-- ROADMAP -->
