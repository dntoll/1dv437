# Föreläsning 1 #

## Presentation av kursledning ##

[https://coursepress.lnu.se/kurs/grundlaggande-spelprogrammering/kursledning-2/](https://coursepress.lnu.se/kurs/grundlaggande-spelprogrammering/kursledning-2/)

## Kursens upplägg ##

 * Föreläsningar
 	* Kursinformation  
 	* Inspiration
 	* Förevisning
 	* Kod
 * Laborationer
 	* Individuellt
 	* Valfri miljö och språk
 		* Principerna är samma, APIér skiljer sig åt
 		* Ni skall kunna programmera i språket
 		* Det skall finnas API för grafik, interaktion och ljud
 	* Bygger på varandra
 	* Grundkod för projekt
 	* Laboration 1. Model -> View översättningar
 		* Studsande boll i fönster med ram som kan skalas om 
 	* Laboration 2. Simuleringar och Partiklar
 		* Olika typer av partikelsystem
 		* Interpolation
 		* 2D animering
 		* Sprites 
 	* Laboration 3. Interaktion
 		* Hur delar vi upp ett spel i olika komponenter
 		* Interaktion
 		* Minimalt spel 
* Projektet
	* Individuellt
	* Kravlista
	* Releaser 
	* Muntlig redovisning (inspelning)
	* Banor med stegrande svårighetsgrad och nya element.
	* Börja redan idag, börja att skissa på er "prototyp" 
* Studietakt
	* En laboration per vecka
	* Ingen handledning under julen

## Översikt Model View Controller ##

 * Spelidé Arkanoid
 	* Spelelement, Regler -> Model
 		* Spelets tillstånd 
 	* Visuellt/Audiellt -> View
 		* Bakgrundsmusik
 		* Storlek på fönster 
 	* Interaktion -> Controller
 		* Hur kan spelaren interagera med spelet?
### Model ###
* Domänregler, hur fungerar domänen
* Exempel på Model-klasser   
	* Game
	* Level
	* Ball
	* Brick
	* Pad
* Exempel på regler 
	* Fysik
	* AI
* Arbetar i logiska koordinater
    * Ex 16 * 16 tiles 
### View ###
 * Hur ritas spelet ut?
 * Exempel på View-klasser
 	* Assets
 		* Font, Textur, Ljud
 	* Core, speciella ritfunktioner
 	* LevelView
 	* PadView
 	* GameView
 	* Camera
 * Arbetar i skärmkoordinater
 	* Översätter logiska koordinater till skärmkoordinater och tillbaka.
 * Resurser
 * Utritning
 * Uppspelning av ljud
 * Force feedback 
 * Input

### Controller ###

 * Main Controller
 	* Vilket användningsfall är det som är aktivt?
 * Hur kan spelaren interaktera med spelet?
 * Subcontrollers
 * Hantera indata
 * Välja vyer


## Model View Controller Relationer ##

 * Model har inga relationer till View eller Controller
 * View känner bara till Model men "read only"
 	* För att kunna visualisera spelet 
 * Controller känner till både Model och View

