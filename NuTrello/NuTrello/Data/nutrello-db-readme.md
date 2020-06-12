## För att rensa databasen helt på data.
    1. Ta bort databas filen (./kanban-meta-g2/NuTrello/NuTrello/data/nutrello.db)
    2. Öppna upp cmd / konsollen och skriv följande kommando i projekt mappen (./kanban-meta-g2/NuTrello/NuTrello)
    
    dotnet ef database update


## För att uppdatera databas strukturen.
    1. Ta bort databas filen (./kanban-meta-g2/NuTrello/NuTrello/data/nutrello.db)
    2. Ta bort mappen Migration (./kanban-meta-g2/NuTrello/NuTrello/Migration)
    3. Öppna upp cmd / konsollen och skriv följande kommando i projekt mappen (./kanban-meta-g2/NuTrello/NuTrello)
    
    dotnet ef migrations add initDb -o "Data/Migrations"
    dotnet ef database update

