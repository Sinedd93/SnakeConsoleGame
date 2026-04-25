Snake Console Game

Egyszerű konzolos Snake játék C# nyelven, amely teljes egészében konzol felületen működik.
A játék célja az étel összegyűjtése, a kígyó növelése és a túlélés minél hosszabb ideig.

Funkciók
Konzolos Snake játékmenet
Folyamatos mozgás
Nyílbillentyűs irányítás
Pontszám rendszer
Véletlenszerű étel generálás
Kígyó növekedése evés után
Akadályok generálása pontszám alapján
Falnak ütközés kezelése
Saját testtel való ütközés kezelése
Game Over képernyő
Újrajátszás lehetősége
Irányítás
↑ = Fel
↓ = Le
← = Balra
→ = Jobbra
Játékszabályok
A kígyó automatikusan mozog.
Az étel (O) elfogyasztásával pontot kapsz.
Minden étel növeli a kígyó hosszát.
5 pont után akadályok (H) jelennek meg.
Ha a kígyó:
falnak ütközik
saját testébe ütközik
akadályba ütközik

akkor a játék véget ér.

Technikai megoldások

A projekt a következő alapelvekre épül:

Konzolos renderelés (Console.SetCursorPosition)
Game Loop logika
Listák használata pozíciók tárolására
Tuple koordináták (x,y)
Random spawn rendszer
Collision Detection
Konzolos HUD (pontszám kijelzés)
Használt technológiák
C#
.NET Console Application
Visual Studio
