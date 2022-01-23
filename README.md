# MAU-SA_Dotnet
ASP.net School Project


Anforderungen an das Projekt

# Idee
Überlege dir eine Web-Application, die du gerne einmal umsetzten würdest. Z.B. ein Webshop, ein Reservierungssystem für Freibadtermine, ein Ticketing System für Supportanfragen, ein Buchungssystem für Konzertkarten, eine Music-Share-Plattform, …

Entscheide dich für ein Datenbankmanagementsystem deiner Wahl. MS SQL, MySQL, SQLite, Local-DB. Am einfachsten ist es SQLite zu verwenden, allerdings hat es einen geringeren Funktionsumfang. Für den Unterricht ist es aber ausreichend.

# DB/Modellierung
Code First mit mindestens 5 Tabellen. Es können gerne auch mehr sein. Erstelle dabei alle Entitäten, deren Properties und den dazugehörigen DB-Context.
Die Spalten der DB werden in den Entitäten als Default-Properties abgebildet.
Achte darauf, ein Rich-Domain-Model zu erstellen.
Verwende zumindest einen record (Address, PhoneNumber, ...)
Achte auf private setter (Properties)
Achte auf "sichere" Listen
... Weiteres gelerntes
Befülle (seeding) die erstellte DB mit willkürlichen Dummy-Daten, damit die Applikation auch getestet werden kann. (z.B. Bogus)

# Services
Schreibe für mindestens 2 der Entitäten einen Service, der grundlegende CRUD-Operations anwendet. (Create, Read, Update, Delete) Der Service verwendet die zuvor angelegten Entitäten.
z.B.: Der Kunde im Shop kann sich einen Artikel in den Warenkorb legen (Create), Daten des Artikels ändern (Update) und den Artikel wieder aus dem Warenkorb löschen (Delete). Anschließend wird der Inhalt des Warenkorbes angezeigt (Read). Manche dieser Methoden wurden zwar noch nicht im Detail besprochen, aber versuche bitte dein bestes.
Achte darauf eine Teil (wie besprochen) der Business-Logik ins Model zu legen.

# Console
Diesen Teil bitte nur rudimentär umsetzen. Die Ausgabe kann so einfach wie möglich erfolgen. Eine Liste in der Console auszugeben ist absolut ausreichend. Selbstverständlich ist es willkommen, bereits jetzt eine simples Web-UI abzugeben. Eine Liste, die eine DB-Tabelle repräsentiert ist absolut ausreichend.


# Technologie-Stack:
C#
.netCore 5.0 or higher
